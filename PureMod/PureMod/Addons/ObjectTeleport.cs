using VRC.SDKBase;
using PureMod.API;
using UnityEngine;
using PureModLoader.API;

namespace PureMod.Addons
{
    public class ObjectTeleport : ModBase
    {
        public override int LoadOrder => 1;
        public override string ModName => "Object teleport";

        public override void OnUpdate()
        {
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Alpha2))
                foreach (var pickup in Resources.FindObjectsOfTypeAll<VRC_Pickup>())
                {
                    if (pickup.gameObject.active)
                        Networking.SetOwner(Utils.GetLocalPlayer(), pickup.gameObject);
                    if (Physics.Raycast(Utils.GetLocalPlayerCamera().GetComponent<Camera>().ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
                        pickup.transform.position = hit.point;
                }
        }
    }
}
