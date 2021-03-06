﻿using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	/// <summary>
	/// Send by the server in response to a <see cref="NetworkOperationCode.CMSG_PLAYED_TIME"/>
	/// </summary>
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.SMSG_PLAYED_TIME)]
	public sealed class SMSG_PLAYED_TIME_Payload : GamePacketPayload
	{
		/// <summary>
		/// The total play time for the character.
		/// </summary>
		[WireMember(1)]
		public uint TotalPlayTime { get; }
		
		/// <summary>
		/// The playtime for the character at the current level.
		/// </summary>
		[WireMember(2)]
		public uint PlaytimeAtLevel { get; }

		/// <summary>
		/// Indicates if the played time should be written to the chat
		/// frame.
		/// </summary>
		[WireMember(3)]
		public bool ShowInChatFrame { get; } = false;

		/// <inheritdoc />
		public SMSG_PLAYED_TIME_Payload(uint totalPlayTime, uint playtimeAtLevel)
		{
			//TODO: Assert played time
			TotalPlayTime = totalPlayTime;
			PlaytimeAtLevel = playtimeAtLevel;
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public SMSG_PLAYED_TIME_Payload()
		{
			
		}
	}
}
