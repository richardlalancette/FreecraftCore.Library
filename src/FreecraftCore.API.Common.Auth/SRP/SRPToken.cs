﻿using FreecraftCore.Serializer;


namespace FreecraftCore
{
	/// <summary>
	/// SRP token based on Trinitycore/Mangos/WoW authentication protocol.
	/// Review http://srp.stanford.edu/design.html for more information
	/// </summary>
	[WireDataContract]
	public class SRPToken 
	{
		/// <summary>
		/// Half of the ephemerial public key.
		/// </summary>
		[KnownSize(32)] //The size is not sent. It is known by both clients
		[WireMember(1)]
		public byte[] B { get; private set; }

		/// <summary>
		/// A generator modulo N.
		/// (I don't really know what that means)
		/// </summary>
		[SendSize(SendSizeAttribute.SizeType.Byte)] //Size is sent as a uint8. Trinitycore always sends 1
		[WireMember(2)]
		public byte[] g { get; private set; }

		/// <summary>
		/// A large safe prime (N = 2q+1, where q is prime)
		/// </summary>
		[SendSize(SendSizeAttribute.SizeType.Byte)] //Trinitycore always send 32
		[WireMember(3)]
		public byte[] N { get; private set; }

		//SRP_6_S
		/// <summary>
		/// User salt (randomly generated by server. Used to make data ephemeral)
		/// </summary>
		[KnownSize(32)] //trinitycore sends 32 byte salt
		[WireMember(4)]
		public byte[] salt { get; private set; }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="b">SRP6: B (server random)</param>
		/// <param name="g">SRP6: g (generator modulo N)</param>
		/// <param name="n">SRP6: N (large safe prime)</param>
		/// <param name="salt">SRP6: s (salt)</param>
		public SRPToken(byte[] b, byte[] g, byte[] n, byte[] salt)
		{
			//TODO: Validate lengths

			B = b;
			this.g = g;
			N = n;
			this.salt = salt;
		}

		//Serializer ctor
		protected SRPToken()
		{
			
		}
	}
}
