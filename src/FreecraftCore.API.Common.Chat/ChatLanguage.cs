﻿namespace FreecraftCore
{
	/// <summary>
	/// Enumeration of all valid chat languages.
	/// </summary>
	public enum ChatLanguage : uint
	{
		LANG_UNIVERSAL = 0,
		LANG_ORCISH = 1,
		LANG_DARNASSIAN = 2,
		LANG_TAURAHE = 3,
		LANG_DWARVISH = 6,
		LANG_COMMON = 7,
		LANG_DEMONIC = 8,
		LANG_TITAN = 9,
		LANG_THALASSIAN = 10,
		LANG_DRACONIC = 11,
		LANG_KALIMAG = 12,
		LANG_GNOMISH = 13,
		LANG_TROLL = 14,
		LANG_GUTTERSPEAK = 33,
		LANG_DRAENEI = 35,
		LANG_ZOMBIE = 36,
		LANG_GNOMISH_BINARY = 37,
		LANG_GOBLIN_BINARY = 38,
		LANG_ADDON = 0xFFFFFFFF                        // used by addons, in 2.4.0 not exist, replaced by messagetype?
	}
}
