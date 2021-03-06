﻿using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	public sealed class InitialSpellDataBlock<TSpellType>
		where TSpellType : struct
	{
		//TODO:W hat is this?
		//TC always sets this to 0.
		/// <summary>
		/// UNK
		/// </summary>
		[WireMember(1)]
		public byte UnkByte { get; } = 0;

		//TODO: Hide behind readonly collection.
		//TC sends this as a short prefixed array
		/// <summary>
		/// Array of spell ids sent as the inital spells
		/// </summary>
		[SendSize(SendSizeAttribute.SizeType.UShort)]
		[WireMember(2)]
		public InitialSpellData<TSpellType>[] SpellIds { get; }

		/// <summary>
		/// Spell cooldowns.
		/// </summary>
		[SendSize(SendSizeAttribute.SizeType.UShort)]
		[WireMember(3)]
		public InitialSpellCooldown<TSpellType>[] SpellCooldowns { get; }

		//TODO: Can cooldown be null?
		/// <inheritdoc />
		public InitialSpellDataBlock([NotNull] InitialSpellData<TSpellType>[] spellIds, InitialSpellCooldown<TSpellType>[] spellCooldowns)
		{
			SpellIds = spellIds ?? throw new ArgumentNullException(nameof(spellIds));
			SpellCooldowns = spellCooldowns;
		}

		public InitialSpellDataBlock([NotNull] InitialSpellData<TSpellType>[] spellIds)
		{
			SpellIds = spellIds ?? throw new ArgumentNullException(nameof(spellIds));
			SpellCooldowns = Array.Empty<InitialSpellCooldown<TSpellType>>();
		}

		protected InitialSpellDataBlock()
		{
			
		}
	}
}
