using VRC;
using UnityEngine;
using PureMod.Config;
using PureModLoader.API;
using PureMod.Other;

namespace PureMod.Modules
{
    [Module]
    public class CustomNameplates
    {
        public int loadOrder = 0;
        public string moduleName = "Custom nameplates";

        public void OnPlayerJoin(Player player)
        {
            if (player == null || player == Utils.LocalPlayer.prop_Player_0)
                return;

            if (GameObject.Find($"{player.gameObject.name}/Player Nameplate/Canvas/Nameplate/Contents/Main/Background") != null)
                GameObject.Find($"{player.gameObject.name}/Player Nameplate/Canvas/Nameplate/Contents/Main/Background").GetComponent<ImageThreeSlice>().m_Color = ModColors.TrustColor(player.prop_APIUser_0);
        }
    }
}