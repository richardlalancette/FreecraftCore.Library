﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreecraftCore.Serializer;

namespace FreecraftCore.API.Common
{
	[DefaultChild(typeof(UnhandledChatTypeMessage))]
	[WireDataContractBaseType((int)ChatMessageType.CHAT_MSG_GUILD, typeof(GuildChatNetworkMesage))]
	[WireDataContract(WireDataContractAttribute.KeyType.Byte, InformationHandlingFlags.DontConsumeRead)]
	public abstract class NetworkChatMessage
	{
		/// <summary>
		/// Indicates the message type of the chat message.
		/// </summary>
		[WireMember(1)]
		public ChatMessageType MessageType { get; private set; }

		/// <summary>
		/// Indicates the language of the chat message.
		/// </summary>
		[WireMember(2)]
		public ChatLanguage Language { get; private set; }

		/// <summary>
		/// The <see cref="ObjectGuid"/> of the entity that sent the message.
		/// </summary>
		[WireMember(3)]
		public ObjectGuid SenderGuid { get; private set; }

		//TODO: Find out what this is
		[WireMember(4)]
		private int UnknownOne { get; set; }

		protected NetworkChatMessage()
		{
			//serializer ctor
		}
	}
}
