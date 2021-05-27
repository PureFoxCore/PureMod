using UnityEngine;
using PureMod.API;
using PureModLoader.API;
using System.Diagnostics;
using PureModLoader.UIAPI.QM;

namespace PureMod.Modules
{
    public class QuitGame : ModuleBase
    {
        public override int LoadOrder => 1;
        public override string ModuleName => "Quit Game";

        public override void OnStart()
        {
            new SingleButton(QMmenu.mainMenuP1.GetMenuName(), 3, 1, true, "Quit", "ShutDown Game", delegate ()
             {
                 PopupAPI.CreateConfirmPopup("Quit?", "Are you sure to quit game?\nIt will kill game prosess", "Yes", "No", delegate ()
                 {
                     Process.GetCurrentProcess().Kill();
                 }, null, null, Color.red, Color.white, Color.red, Color.white);
             }, Color.red);
        }
    }
}
