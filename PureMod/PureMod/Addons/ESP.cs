using UnityEngine;
using VRC.SDKBase;
using PureMod.API;

namespace PureMod.Addons
{
    public class ESP : ModSystem
    {
        public override int LoadOrder => 1;

        public override string ModName => "ESP";

        private bool m_PlayerState;
        private bool m_ObjectState;

        public override void OnStart()
        {
            var menu = new ButtonAPI.NestedButton(QMmenu.mainMenuP1.GetMenuName(), 1, 2, true, "ESP Menu", "ESP Menu");

            new ButtonAPI.ToggleButton(menu.GetMenuName(), 1, 0, true, "ESP Players", "To see all players", delegate (bool state)
            {
                m_PlayerState = state;
                Update();
            }, Color.magenta, Color.white);

            new ButtonAPI.ToggleButton(menu.GetMenuName(), 1, 1, true, "ESP Objects", "To see all objects", delegate (bool state)
            {
                m_ObjectState = state;
                Update();
            }, Color.magenta, Color.white);
        }

        private void Update()
        {
            var allPlayers = Utils.GetPlayerAPIs();
            var allObjects = Object.FindObjectsOfType<VRC_Pickup>();

            foreach (var player in allPlayers)
                if (!player.isLocal)
                    HighlightsFX.prop_HighlightsFX_0.Method_Public_Void_Renderer_Boolean_0(player.gameObject.transform.Find("SelectRegion").GetComponent<MeshRenderer>(), m_PlayerState);

            foreach (var pickup in allObjects)
                HighlightsFX.prop_HighlightsFX_0.Method_Public_Void_Renderer_Boolean_0(pickup.GetComponent<MeshRenderer>(), m_ObjectState);
        }

        public override void OnUpdate10()
        {
            Update();
        }
    }
}
