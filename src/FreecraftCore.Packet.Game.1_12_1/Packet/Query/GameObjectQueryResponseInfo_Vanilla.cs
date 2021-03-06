﻿using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	[WireDataContract]
	public sealed class GameObjectQueryResponseInfo_Vanilla
	{
		//TODO: Get enum for this
		[WireMember(1)]
		public int GameObjectType { get; }

		[WireMember(2)]
		public int DisplayId { get; }

		[Encoding(EncodingType.ASCII)]
		[KnownSize(4)]
		[WireMember(3)]
		public string[] Names { get; }

		[Encoding(EncodingType.ASCII)]
		[WireMember(6)]
		public string UnkString { get; }

		[WireMember(7)]
		[KnownSize(sizeof(int) * 24)]
		public byte[] Data { get; }

		/// <inheritdoc />
		public GameObjectQueryResponseInfo_Vanilla(int gameObjectType, int displayId, string[] names, string unkString, byte[] data)
		{
			GameObjectType = gameObjectType;
			DisplayId = displayId;
			Names = names;
			UnkString = unkString;
			Data = data;
		}

		protected GameObjectQueryResponseInfo_Vanilla()
		{

		}
	}
}