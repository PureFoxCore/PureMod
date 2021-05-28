using UnityEngine;
using PureMod.API;
using PureMod.Other;
using PureModLoader.API;
using PureModLoader.UIAPI.QM;
using System.Collections.Generic;

namespace PureMod.Modules
{
    public class PlayerList : ModuleBase
    {
        public override int LoadOrder => 1;

        public override string ModuleName => "Player list";

        private NestedButton teleportMenu;
        private List<SingleButton> playerButtons = new List<SingleButton>();

        public override void OnStart()
        {
            teleportMenu = new NestedButton(QMmenu.mainMenuP1.GetMenuName(), 4, 1, true, "Players", "Player list", delegate ()
            {
                UpdateList();
            });
        }

        public override void OnPlayerJoin(VRC.Player player) =>
            UpdateList();

        public override void OnPlayerLeave(VRC.Player player) =>
            UpdateList();

        private void UpdateList()
        {
            foreach (var button in playerButtons)
                button.Destroy();

            var players = Utils.Players;
            int x = 1, y = 0;

            foreach (var player in players)
            {
                playerButtons.Add(new SingleButton(teleportMenu.GetMenuName(), x, y, true, player.prop_APIUser_0.displayName, $"Select {player.prop_APIUser_0.displayName}", delegate ()
                {
                    Utils.QMSelectPlayer(player);
                }, player.prop_APIUser_0.isFriend ? Color.yellow : Color.white));

                if (x < 4)
                    x++;
                else
                {
                    x = 1;
                    y++;
                }
            }
        }
    }
}