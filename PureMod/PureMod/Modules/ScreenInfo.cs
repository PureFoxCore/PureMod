using UnityEngine;
using PureMod.Other;
using PureModLoader.API;

namespace PureMod.Modules
{
    [Module]
    public class ScreenInfo
    {
        public int loadOrder = 0;
        public string moduleName = "On screen info";

        //public override void OnUpdate1()
        //{
            //foreach (var player in Utils.Players)
            //    ModUtils.PureModLogger.Trace($"{player.prop_APIUser_0.displayName}: [{Utils.GetPlayerPing(player.prop_VRCPlayer_0)}] [{Vector3.Distance(Utils.LocalPlayer.gameObject.transform.position, player.gameObject.transform.position)}]");
        //}
    }
}
