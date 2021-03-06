﻿using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.SMSG_CREATURE_QUERY_RESPONSE)]
	public sealed class SMSG_CREATURE_QUERY_RESPONSE_Payload_Vanilla : GamePacketPayload, IQueryResponsePayload<CreatureQueryResponseInfo_Vanilla>
	{
		[WireMember(1)]
		private uint PackedResponseId { get; }

		/// <inheritdoc />
		public int QueryId => (int)(PackedResponseId & ~0x80000000);

		/// <summary>
		/// Indicates if the query was successful.
		/// </summary>
		public bool IsSuccessful => (PackedResponseId & 0x80000000) == 0;

		[Optional(nameof(IsSuccessful))]
		[WireMember(2)]
		public CreatureQueryResponseInfo_Vanilla Result { get; }

		/// <inheritdoc />
		public SMSG_CREATURE_QUERY_RESPONSE_Payload_Vanilla(int queryId, [NotNull] CreatureQueryResponseInfo_Vanilla result)
		{
			//No bitwise math needed since success if 0x0
			PackedResponseId = (uint)queryId;
			Result = result ?? throw new ArgumentNullException(nameof(result));
		}

		/// <summary>
		/// Creates a failing response.
		/// </summary>
		/// <param name="queryId">The query id.</param>
		public SMSG_CREATURE_QUERY_RESPONSE_Payload_Vanilla(uint queryId)
		{
			PackedResponseId = queryId & 0x80000000;
		}

		public SMSG_CREATURE_QUERY_RESPONSE_Payload_Vanilla()
		{

		}
	}
}
