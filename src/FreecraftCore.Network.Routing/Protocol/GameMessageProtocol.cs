﻿namespace FreecraftCore
{
	/// <summary>
	/// Strongly typed <see cref="IMessageProtocolStrategy"/> that provides the
	/// <see cref="ProtocolCode"/> for game messages.
	/// </summary>
	public sealed class GameMessageProtocol : IMessageProtocolStrategy
	{
		/// <inheritdoc />
		public ProtocolCode MessageProtocol => ProtocolCode.Game;

		public GameMessageProtocol()
		{
			
		}
	}
}
