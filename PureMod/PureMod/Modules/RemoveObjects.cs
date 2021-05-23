using UnityEngine;
using PureMod.API;
using VRC.SDKBase;
using PureModLoader.API;

namespace PureMod.Modules
{
    public class RemoveObjects : ModuleBase
    {
        public override int LoadOrder => 1;
        public override string ModName => "Remove Objects";

        public override void OnUpdate()
        {
            if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.Mouse2))
                if (Physics.Raycast(Utils.GetLocalPlayerCamera().GetComponent<Camera>().ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
                {
                    Networking.SetOwner(Utils.GetLocalPlayer(), hit.collider.gameObject);
                    Networking.Destroy(hit.collider.gameObject);
                }
        }
    }
}
