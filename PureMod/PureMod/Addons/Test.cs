using UnityEngine;
using VRC.SDKBase;
using PureMod.API;

namespace PureMod.Addons
{
    public class Test : ModSystem
    {
        public override bool ShowName => false;

        public override void OnUpdate()
        {
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.T))
            {
                foreach (var player in VRCPlayerApi.AllPlayers)
                    Core.CoreLogger.Trace($"Player: {player.displayName} || ID: {player.playerId}");

                foreach (var player in VRCPlayerApi.AllPlayers)
                {
                    if (player.isMaster)
                        Core.CoreLogger.Trace($"Master: {player.displayName}");
                    if (player.isLocal)
                        Core.CoreLogger.Trace($"Local: {player.displayName}");
                    if (player.isModerator)
                        Core.CoreLogger.Warn($"Moderator: {player.displayName}");
                    if (player.isSuper)
                        Core.CoreLogger.Warn($"Super: {player.displayName}");
                }
            }

            //if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.U))
            //    foreach (var player in Utils.GetPlayers())
            //        player.TeleportTo(Utils.GetLocalPlayer().GetPosition(), Utils.GetLocalPlayer().GetRotation());
        }
    }
}
