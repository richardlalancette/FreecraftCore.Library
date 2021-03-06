﻿using System;
using System.Threading.Tasks;
using Common.Logging;
using FreecraftCore;
using GladNet;
using JetBrains.Annotations;

namespace Authentication.TestServer
{
	public sealed class AuthDefaultRequestHandler : IPeerPayloadSpecificMessageHandler<AuthenticationClientPayload, AuthenticationServerPayload, IPeerSessionMessageContext<AuthenticationServerPayload>>
	{
		private ILog Logger { get; }

		/// <inheritdoc />
		public AuthDefaultRequestHandler([NotNull] ILog logger)
		{
			if(logger == null) throw new ArgumentNullException(nameof(logger));

			Logger = logger;
		}

		/// <inheritdoc />
		public Task HandleMessage(IPeerSessionMessageContext<AuthenticationServerPayload> context, AuthenticationClientPayload payload)
		{
			if(Logger.IsWarnEnabled)
				Logger.Warn($"Recieved unhandable Payload: {payload.GetType().Name} ConnectionId: {context.Details.ConnectionId}");

			return Task.CompletedTask;
		}
	}
}
