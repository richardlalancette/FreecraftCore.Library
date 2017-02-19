﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreecraftCore.Serializer;

namespace FreecraftCore.Packet.Auth
{
	/// <summary>
	/// Enumeration of authentication destination codes.
	/// </summary>
	[WireDataContract]
	public enum AuthOperationDestinationCode : short
	{
		Default = 0,

		/// <summary>
		/// Indicates the destination should be the server.
		/// </summary>
		Server = 1,
		
		Client = 2,
	}
}
