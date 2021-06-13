using UnityEngine;
using PureMod.Config;
using PureModLoader.API;
using PureModLoader.API.UIAPI.QM;
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
            teleportMenu = new NestedButton(QMmenu.mainMenuP1.MenuPath, 4, 1, true, "Players", "Player list", delegate ()
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

            int x = 1, y = 0;

            foreach (var player in Utils.Players)
            {
                playerButtons.Add(new SingleButton(teleportMenu.MenuPath, x, y, true, player?.prop_APIUser_0.displayName, $"Select {player?.prop_APIUser_0.displayName}", delegate ()
                {
                    Utils.QMSelectPlayer(player);
                }, ModColors.TrustColor(player?.prop_APIUser_0), player.prop_APIUser_0.isFriend ? Color.yellow : ModColors.ButtonDefaultBackground));

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