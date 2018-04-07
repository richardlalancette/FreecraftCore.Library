﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FreecraftCore
{
	/// <summary>
	/// Database implementation of <see cref="IAuthenticationUserAccountRepository"/>.
	/// </summary>
	public sealed class AuthenticationDatabaseUserAccountAccountRepository : IAuthenticationUserAccountRepository
	{
		/// <summary>
		/// The database context for the auth database.
		/// </summary>
		private authContext AuthenticationDatabaseContext { get; }

		/// <inheritdoc />
		public AuthenticationDatabaseUserAccountAccountRepository(authContext authenticationDatabaseContext)
		{
			if(authenticationDatabaseContext == null) throw new ArgumentNullException(nameof(authenticationDatabaseContext));

			AuthenticationDatabaseContext = authenticationDatabaseContext;
		}

		/// <inheritdoc />
		public Task<bool> DoesAccountExists(string accountName)
		{
			if(string.IsNullOrWhiteSpace(accountName)) throw new ArgumentException("Value cannot be null or whitespace.", nameof(accountName));

			return AuthenticationDatabaseContext
				.Account
				.AnyAsync(a => a.Username == accountName);
		}

		/// <inheritdoc />
		public Task<Account> GetAccount(string accountName)
		{
			if(string.IsNullOrWhiteSpace(accountName)) throw new ArgumentException("Value cannot be null or whitespace.", nameof(accountName));

			return AuthenticationDatabaseContext
				.Account
				.Where(a => a.Username == accountName)
				.SingleAsync();
		}

		/// <inheritdoc />
		public void Dispose()
		{
			AuthenticationDatabaseContext?.Dispose();
		}
	}
}