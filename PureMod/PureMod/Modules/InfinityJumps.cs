using UnityEngine;
using MelonLoader;
using PureModLoader.API;
using PureModLoader.API.UIAPI.QM;

namespace PureMod.Modules
{
    [Module]
    public class InfinityJumps
    {
        public int loadOrder = 1;

        public string moduleName = "Infinity jump";

        private static bool m_State = false;

        public void OnStart()
        {
            new ToggleButton(QMmenu.mainMenuP1.MenuPath, 4, 2, true, moduleName, moduleName, delegate (bool state)
            {
                m_State = state;
            }, Color.cyan, Color.white);
            MelonCoroutines.Start(Active());
        }

        private System.Collections.IEnumerator Active()
        {
            while (true)
            {
                try
                {
                    if (m_State && Input.GetAxis("Jump") != 0f)
                    {
                        if (!Utils.LocalPlayer.field_Private_VRCPlayerApi_0.IsPlayerGrounded())
                        {
                            GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Plane);
                            gameObject.GetComponent<Renderer>().enabled = false;
                            gameObject.transform.position = Utils.LocalPlayer.gameObject.transform.position;
                            GameObject.Destroy(gameObject, 0.3f);
                        }
                    }
                }
                catch { }
                yield return new WaitForSeconds(0.01f);
            }
        }
    }
}
