using UnityEngine;
using MelonLoader;
using PureMod.API;
using PureModLoader.API;
using PureModLoader.UIAPI.QM;

namespace PureMod.Modules
{
    public class InfinityJumps : ModuleBase
    {
        public override int LoadOrder => 1;

        public override string ModuleName => "Infinity jump";

        public override void OnStart()
        {
            new ToggleButton(QMmenu.mainMenuP1.GetMenuName(), 4, 2, true, ModuleName, ModuleName, delegate (bool state)
            {
                MelonCoroutines.Start(Active(state));
            }, Color.cyan, Color.white);
        }

        private System.Collections.IEnumerator Active(bool state)
        {
            while (true)
            {
                try
                {
                    if (state && Input.GetAxis("Jump") != 0f)
                    {
                        if (!Utils.LocalPlayer.IsPlayerGrounded())
                        {
                            GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Plane);
                            gameObject.GetComponent<Renderer>().enabled = false;
                            gameObject.transform.position = Utils.LocalPlayer.gameObject.transform.position;
                            GameObject.Destroy(gameObject, 0.5f);
                        }
                    }
                }
                catch { }
                yield return new WaitForSeconds(0.01f);
            }
        }
    }
}
