﻿using System;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	/// <summary>
	/// Default payload for unknown authentication payloads.
	/// </summary>
	[WireDataContract]
	public sealed class DefaultAuthenticationServerPayload : AuthenticationServerPayload
	{
		/// <inheritdoc />
		public override bool isValid { get; } = false;

		[WireMember(1)]
		public byte[] Data { get; }

		/// <inheritdoc />
		public DefaultAuthenticationServerPayload([NotNull] byte[] data)
		{
			if(data == null) throw new ArgumentNullException(
				nameof(data));
			Data = data;
		}

		//Serializer ctor
		protected DefaultAuthenticationServerPayload()
		{
			
		}
	}
}
