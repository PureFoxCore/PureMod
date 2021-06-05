using UnityEngine;
using PureMod.Other;
using PureModLoader.API;

namespace PureMod.Modules
{
    public class ScreenInfo : ModuleBase
    {
        public override int LoadOrder => 0;
        public override string ModuleName => "On screen info";

        //public override void OnUpdate1()
        //{
            //foreach (var player in Utils.Players)
            //    ModUtils.PureModLogger.Trace($"{player.prop_APIUser_0.displayName}: [{Utils.GetPlayerPing(player.prop_VRCPlayer_0)}] [{Vector3.Distance(Utils.LocalPlayer.gameObject.transform.position, player.gameObject.transform.position)}]");
        //}
    }
}
