using UnityEngine;
using PureMod.API;
using VRC.SDKBase;
using PureModLoader.API;

namespace PureMod.Modules
{
    public class RemoveObjects : ModuleBase
    {
        public override int LoadOrder => 1;
        public override string ModuleName => "Remove Objects";

        public override void OnUpdate()
        {
            if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.Mouse2))
                if (Physics.Raycast(Utils.LocalPlayerCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
                {
                    Networking.SetOwner(Utils.LocalPlayer, hit.collider.gameObject);
                    Networking.Destroy(hit.collider.gameObject);
                }
        }
    }
}
