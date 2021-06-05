using VRC.SDKBase;
using PureModLoader.API;
using UnityEngine;

namespace PureMod.Modules
{
    public class ObjectTeleport : ModuleBase
    {
        public override int LoadOrder => 1;
        public override string ModuleName => "Object teleport";

        public override void OnUpdate()
        {
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Alpha2))
                foreach (var pickup in Resources.FindObjectsOfTypeAll<VRC_Pickup>())
                {
                    if (pickup.gameObject.active)
                        Networking.SetOwner(Utils.LocalPlayer.field_Private_VRCPlayerApi_0, pickup.gameObject);
                    if (Physics.Raycast(Utils.LocalPlayerCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
                        pickup.transform.position = hit.point;
                }
        }
    }
}
