using VRC.Core;
using UnityEngine;

namespace PureMod.Config
{
    class ModColors
    {
		public static Color TrustColor(APIUser user)
		{
			if (user.id == "usr_77979962-76e0-4b27-8ab7-ffa0cda9e223")
				return new Color(0.7f, 1f, 0f, 1f);
			if (user.tags.Contains("system_legend"))
				return new Color(0.99f, 0.67f, 0.83f, 1f);
			if (user.hasLegendTrustLevel)
				return new Color(0.81f, 0.71f, 0.32f, 1f);
			if (user.hasVeteranTrustLevel)
				return new Color(0.75f, 0.1f, 0.51f, 1f);
			if (user.hasTrustedTrustLevel)
				return new Color(0.62f, 0.29f, 0.034f, 1f);
			if (user.hasKnownTrustLevel)
				return new Color(0.24f, 0.68f, 0.27f, 1f);
			if (user.hasBasicTrustLevel)
				return new Color(0.35f, 0.54f, 0.71f, 1f);
			if (user.isUntrusted)
				return new Color(0.7f, 0.7f, 0.7f, 1f);
			return new Color(1f, 0f, 0f, 1f);
		}

		public static Color ButtonDefaultBackground { get => new Color(0.03f, 0.4f, 0.4f, 1); }
		public static Color DefaultMicColor { get => new Color32(255, 128, 0, 1); }
	}
}
