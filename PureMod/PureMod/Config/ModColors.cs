using VRC.Core;
using UnityEngine;

namespace PureMod.Config
{
    public class ModColors
    {
        public static Color TrustColor(APIUser user)
        {
            if (user.id == "usr_77979962-76e0-4b27-8ab7-ffa0cda9e223" || user.id == "usr_39c054aa-1f3d-4791-9a9e-6e796d035f32") // Dev IDs
                return new Color32(255, 105, 105, 255);
            else if (user.tags.Contains("system_legend"))
                return new Color32(255, 128, 172, 255);
            else if (user.hasLegendTrustLevel)
                return new Color32(255, 236, 128, 255);
            else if (user.hasVeteranTrustLevel)
                return new Color32(192, 153, 255, 255);
            else if (user.hasTrustedTrustLevel)
                return new Color32(255, 201, 153, 255);
            else if (user.hasKnownTrustLevel)
                return new Color32(153, 255, 156, 255);
            else if (user.hasBasicTrustLevel)
                return new Color32(153, 209, 255, 255);
            else if (user.isUntrusted)
                return new Color32(184, 184, 184, 255);
            else
                return new Color(1f, 0f, 0f, 1f);
        }

        public static Color ButtonDefaultBackground { get => new Color(0.03f, 0.4f, 0.4f, 1); }
        public static Color DefaultMicColor { get => new Color32(255, 128, 0, 1); }
    }
}
