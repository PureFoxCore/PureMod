using UnityEngine;
using VRC.SDKBase;
using PureMod.API;

namespace PureMod.Addons
{
    public class Test : ModSystem
    {
        public override int LoadOrder => 7;
        public override bool ShowName => false;

        public override void OnUpdate()
        {
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.T))
            {
                foreach (var player in VRCPlayerApi.AllPlayers)
                    Utils.CoreLogger.Trace($"Player: {player.displayName} || ID: {player.playerId}");

                foreach (var player in VRCPlayerApi.AllPlayers)
                {
                    if (player.isMaster)
                        Utils.CoreLogger.Trace($"Master: {player.displayName}");
                    if (player.isLocal)
                        Utils.CoreLogger.Trace($"Local: {player.displayName}");
                    if (player.isModerator)
                        Utils.CoreLogger.Warn($"Moderator: {player.displayName}");
                    if (player.isSuper)
                        Utils.CoreLogger.Warn($"Super: {player.displayName}");
                }
            }

            //if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.U))
            //    foreach (var player in Utils.GetPlayers())
            //        player.TeleportTo(Utils.GetLocalPlayer().GetPosition(), Utils.GetLocalPlayer().GetRotation());
        }
    }
}
