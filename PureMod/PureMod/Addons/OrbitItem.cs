using UnityEngine;
using VRC.SDKBase;
using PureMod.API;

namespace PureMod.Addons
{
    public class OrbitItem : ModSystem
    {
        public override int LoadOrder => 19;

        public override string ModName => "Orbit items";

        private bool m_State;

        public override void OnStart()
        {
            new ButtonAPI.ToggleButton(QMmenu.mainMenuP1.GetMenuName(), 3, 2, true, "Orbit items", "tornado", delegate (bool state)
            {
                m_State = state;
            }, Color.red, Color.white);
        }

        public override void OnLateUpdate()
        {
            if (!m_State || Utils.GetLocalPlayer() == null || Object.FindObjectsOfType<VRC_Pickup>() == null)
                return;

            GameObject gameObject = new GameObject();

            if (!m_State)
            {
                Transform transform = gameObject.transform;
                transform.position = (((Utils.GetLocalPlayer() != null) ? Utils.GetLocalPlayer() : null) ?? Networking.LocalPlayer).GetTrackingData(0).position;
            }
            else
            {
                Transform transform2 = gameObject.transform;
                transform2.position = ((Utils.GetLocalPlayer() != null) ? Utils.GetLocalPlayer().gameObject.transform.position : Utils.GetLocalPlayer().gameObject.transform.position) + new Vector3(0f, 0.2f, 0f);
            }
            gameObject.transform.Rotate(new Vector3(0f, 360f * Time.time * 1.0f, 0f));
            foreach (VRC_Pickup vrc_Pickup in Object.FindObjectsOfType<VRC_Pickup>())
            {
                if (Networking.GetOwner(vrc_Pickup.gameObject) != Networking.LocalPlayer)
                    Networking.SetOwner(Networking.LocalPlayer, vrc_Pickup.gameObject);
                vrc_Pickup.transform.position = gameObject.transform.position + gameObject.transform.forward * 1f;
                gameObject.transform.Rotate(new Vector3(0f, 360f / 3.0f, 0f));
            }
            Object.Destroy(gameObject);
        }
    }
}
