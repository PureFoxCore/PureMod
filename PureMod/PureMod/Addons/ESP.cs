using UnityEngine;
using PureMod.API;
using PureMod.API.ButtonAPI;

namespace PureMod.Addons
{
    public class ESP : ModSystem
    {
        public override int LoadOrder => 17;

        public override string ModName => "ESP";

        public override void OnStart()
        {
            new ToggleButton(QMmenu.mainMenuP1.GetMenuName(), 1, 2, true, "ESP", "Wall hack", delegate (bool state)
            {
                var allPlayers = Utils.GetPlayerAPIs();

                foreach (var player in allPlayers)
                    if (!player.isLocal)
                    {
                        Transform sRegion = player.gameObject.transform.Find("SelectRegion");
                        sRegion.GetComponent<MeshRenderer>().sharedMaterial.SetColor("_Color", state ? Color.red : Color.cyan);

                        HighlightsFX.prop_HighlightsFX_0.Method_Public_Void_Renderer_Boolean_0(sRegion.GetComponent<MeshRenderer>(), state);
                    }
            }, Color.magenta, Color.white);
        }
    }
}
