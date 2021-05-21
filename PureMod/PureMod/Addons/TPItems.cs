using UnityEngine;
using PureMod.API;
using VRC.SDKBase;
using PureModLoader.API;
using PureModLoader.ButtonAPI;

namespace PureMod.Addons
{
    public class TPItems : ModSystem
    {
        public override int LoadOrder => 1;
        public override string ModName => "TP items";

        private bool m_State;

        private GameObject player;

        public override void OnStart()
        {
            new ToggleButton(QMmenu.mainMenuP1.GetMenuName(), 3, 2, true, "TP items", "tornado", delegate (bool state)
            {
                m_State = state;
                player = Utils.GetLocalPlayer().gameObject;
            }, Color.red, Color.white);
        }

        public override void OnLateUpdate()
        {
            if (m_State)
            {
                var objects = Object.FindObjectsOfType<VRC_Pickup>();

                for (int i = 0; i < objects.Count; i++)
                {
                    if (Networking.GetOwner(objects[i].gameObject) != Utils.GetLocalPlayer())
                        Networking.SetOwner(Networking.LocalPlayer, objects[i].gameObject);

                    objects[i].transform.position = player.transform.position + new Vector3(0.0f, i * 1.5f, 0.0f);
                    objects[i].transform.rotation = Quaternion.identity;
                }
            }
        }
    }
}
