using UnityEngine;
using VRC.SDKBase;
using PureModLoader.API;
using PureModLoader.API.UIAPI.QM;
using VRC;
using PureMod.Other;

namespace PureMod.Modules
{
    public class ESP : ModuleBase
    {
        public override int LoadOrder => 1;

        public override string ModuleName => "ESP";

        private bool m_PlayerState;
        private bool m_ObjectState;

        public override void OnStart()
        {
            var menu = new NestedButton(QMmenu.mainMenuP1.MenuPath, 1, 2, true, "ESP Menu", "ESP Menu");

            new ToggleButton(menu.MenuPath, 1, 0, true, "ESP Players", "To see all players", delegate (bool state)
            {
                m_PlayerState = state;
                Update();
            }, Color.magenta, Color.white);

            new ToggleButton(menu.MenuPath, 1, 1, true, "ESP Objects", "To see all objects", delegate (bool state)
            {
                m_ObjectState = state;
                Update();
            }, Color.magenta, Color.white);
        }

        private void Update()
        {
            var allPlayers = Utils.PlayerAPIs;
            var allObjects = Object.FindObjectsOfType<VRC_Pickup>();

            foreach (var player in allPlayers)
                if (!player.isLocal)
                    HighlightsFX.prop_HighlightsFX_0.Method_Public_Void_Renderer_Boolean_0(player.gameObject.transform.Find("SelectRegion").GetComponent<MeshRenderer>(), m_PlayerState);

            foreach (var pickup in allObjects)
                HighlightsFX.prop_HighlightsFX_0.Method_Public_Void_Renderer_Boolean_0(pickup.GetComponent<MeshRenderer>(), m_ObjectState);
        }

        public override void OnPlayerJoin(Player player) =>
            Update();
    }
}
