using UnityEngine;
using VRC.SDKBase;
using PureMod.API;

namespace PureMod.Addons
{
    public class Teleport : ModSystem
    {
        public override int LoadOrder => 5;
        public override string ModName => "Test teleport";

        private Il2CppSystem.Collections.Generic.List<VRCPlayerApi> playerList;
        private int playerCount;

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                playerList = Utils.GetPlayerAPIs();
                playerCount = Utils.GetPlayerCount();
            }
        }

        public override void OnGUI()
        {
            if (Input.GetKey(KeyCode.Tab))
            {
                var playerList = Utils.GetPlayerAPIs();

                for (int i = 0; i < playerCount; i++)
                    if (GUI.Button(new Rect(20, 20 + (i * 20), 220, 20), playerList[i].isMaster ? $"{playerList[i].displayName} || {playerList[i].playerId} || Master" : $"{playerList[i].displayName} || {playerList[i].playerId}"))
                        Utils.GetLocalPlayer().TeleportTo(playerList[i].GetPosition(), playerList[i].GetRotation());
            }
        }
    }
}
