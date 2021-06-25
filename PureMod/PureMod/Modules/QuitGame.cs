using UnityEngine;
using PureModLoader.API;
using System.Diagnostics;
using PureModLoader.API.UIAPI.QM;

namespace PureMod.Modules
{
    [Module]

    public class QuitGame
    {
        public int loadOrder = 1;
        public string moduleName = "Quit Game";

        public void OnStart()
        {
            new SingleButton(QMmenu.mainMenuP1.MenuPath, 3, 1, true, "Quit", "ShutDown Game", delegate ()
             {
                 PopupAPI.CreateConfirmPopup("Quit?", "Are you sure to quit game?\nIt will kill game prosess", "Yes", "No", delegate ()
                 {
                     Process.GetCurrentProcess().Kill();
                 }, null, null, Color.red, Color.white, Color.red, Color.white);
             }, Color.red);
        }
    }
}
