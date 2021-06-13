using VRC;
using UnityEngine;
using PureMod.Config;
using PureModLoader.API;
using PureMod.Other;

namespace PureMod.Modules
{
    public class CustomNameplates : ModuleBase
    {
        public override int LoadOrder => 0;
        public override string ModuleName => "Custom nameplates";

        public override void OnPlayerJoin(Player player)
        {
            if (player == null || player == Utils.LocalPlayer.prop_Player_0)
                return;

            if (GameObject.Find($"{player.gameObject.name}/Player Nameplate/Canvas/Nameplate/Contents/Main/Background") != null)
                GameObject.Find($"{player.gameObject.name}/Player Nameplate/Canvas/Nameplate/Contents/Main/Background").GetComponent<ImageThreeSlice>().m_Color = ModColors.TrustColor(player.prop_APIUser_0);
        }
    }
}