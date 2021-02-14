using UnityEngine;
using VRC.SDKBase;
using PureMod.API;

namespace PureMod.Addons
{
    public class Pizdec : ModSystem
    {
        public override int LoadOrder => 15;

        public override string ModName => "Pizdec";

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Mouse2))
                if (Physics.Raycast(Utils.GetLocalPlayerCamera().GetComponent<Camera>().ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
                {
                    GameObject obj = hit.collider.gameObject;
                    if (obj.active)
                    {
                        Networking.SetOwner(Utils.GetLocalPlayer(), obj);
                        obj.transform.position += new Vector3(0.0f, 500.0f, 0.0f);
                    }
                }
        }
    }
}
