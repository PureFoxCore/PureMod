using UnityEngine;
using PureMod.API;
using PureModLoader.API;

namespace PureMod.Addons
{
    public class TestTeleport : ModBase
    {
        public override int LoadOrder => 1;
        public override string ModName => "Test teleport";

        public override void OnGUI()
        {
            var playerList = Utils.GetPlayerAPIs();
            var playerCount = Utils.GetPlayerCount();
            if (Input.GetKey(KeyCode.Tab))
            {
                for (int i = 0; i < playerCount; i++)
                    if (GUI.Button(new Rect(20, 20 + (i * 20), 220, 20), playerList[i].isMaster ? $"{playerList[i].displayName} || {playerList[i].playerId} || Master" : $"{playerList[i].displayName} || {playerList[i].playerId}"))
                        Utils.GetLocalPlayer().gameObject.transform.position = playerList[i].GetPosition();
            }
        }
    }
}
