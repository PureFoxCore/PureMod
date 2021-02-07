using UnityEngine;
using VRC.SDKBase;
using PureMod.API;

namespace PureMod.Addons
{
    public class Teleport : ModSystem
    {
        public override string ModName => "Test teleport";

        public override void OnGUI()
        {
            if (Input.GetKey(KeyCode.Tab))
            {
                var playerList = Utils.GetPlayerAPIs();

                for (int i = 0; i < VRCPlayerApi.GetPlayerCount(); i++)
                    if (GUI.Button(new Rect(20, 20 + (i * 20), 220, 20), playerList[i].isMaster ? $"{playerList[i].displayName} || {playerList[i].playerId} || Master" : $"{playerList[i].displayName} || {playerList[i].playerId}"))
                        Utils.GetLocalPlayer().TeleportTo(playerList[i].GetPosition(), playerList[i].GetRotation());
            }
        }
    }
}
