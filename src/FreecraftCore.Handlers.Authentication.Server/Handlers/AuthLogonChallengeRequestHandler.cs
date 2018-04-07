﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common.Logging;
using FreecraftCore;
using FreecraftCore.API.Common;
using FreecraftCore.API.Common.Auth;
using FreecraftCore.Crypto;
using FreecraftCore.Packet.Auth;
using GladNet;
using JetBrains.Annotations;

namespace Authentication.TestServer
{
	//TODO: This is just a test/demo handler
	public sealed class AuthLogonChallengeRequestHandler : IPeerPayloadSpecificMessageHandler<AuthLogonChallengeRequest, AuthenticationServerPayload>
	{
		private ILog Logger { get; }

		private int Count = 0;

		/// <summary>
		/// Repository service.
		/// </summary>
		private IRepositoryServiceFactory<IAuthenticationUserAccountRepository> AccountRepository { get; }

		/// <inheritdoc />
		public AuthLogonChallengeRequestHandler([NotNull] ILog logger, [NotNull] IRepositoryServiceFactory<IAuthenticationUserAccountRepository> accountRepository)
		{
			if(logger == null) throw new ArgumentNullException(nameof(logger));
			if(accountRepository == null) throw new ArgumentNullException(nameof(accountRepository));

			Logger = logger;
			AccountRepository = accountRepository;
		}

		/// <inheritdoc />
		public async Task HandleMessage(IPeerMessageContext<AuthenticationServerPayload> context, AuthLogonChallengeRequest payload)
		{
			int currentCount = Interlocked.Add(ref Count, 1);

			//This is just demo code
			if(Logger.IsDebugEnabled)
				Logger.Debug($"ClientBuild: {payload.Build} Count: {currentCount}");

			using(var repo = AccountRepository.Create())
			{
				bool accountExists = await repo.DoesAccountExists(payload.Identity)
					.ConfigureAwait(false);

				if(Logger.IsDebugEnabled)
					Logger.Debug($"Account: {payload.Identity} Exists: {accountExists}");

				//Depending on if it exists we build an appropriate response
				AuthLogonChallengeResponse response = accountExists
					? BuildSuccessResponse(await repo.GetAccount(payload.Identity).ConfigureAwait(false))
					: BuildFailureResponse();

				await context.PayloadSendService.SendMessage(response)
					.ConfigureAwait(false);
			}
		}

		//TODO: Handle all failure scenarios like ban/lock/etc
		private AuthLogonChallengeResponse BuildFailureResponse()
		{
			return new AuthLogonChallengeResponse(AuthenticationResult.FailUnknownAccount);
		}

		private AuthLogonChallengeResponse BuildSuccessResponse([NotNull] Account account)
		{
			if(account == null) throw new ArgumentNullException(nameof(account));

			//TODO: unit test this
			using(WoWSRP6ServerCryptoServiceProvider srp = new WoWSRP6ServerCryptoServiceProvider(account.V))
			{
				//TODO: Add a hexstring extension method
				BigInteger B = srp.GenerateB();
				byte[] salt = BigInteger.Parse(account.S, NumberStyles.HexNumber).ToByteArray();
				byte[] G = WoWSRP6ServerCryptoServiceProvider.G.ToByteArray();
				byte[] N = WoWSRP6ServerCryptoServiceProvider.N.ToByteArray();

				SRPToken srpToken = new SRPToken(B.ToByteArray(), G, N, salt);

				return new AuthLogonChallengeResponse(srpToken);
			}
		}
	}
}