using VRC.SDKBase;
using PureModLoader.API;
using UnityEngine;

namespace PureMod.Modules
{
    [Module]
    public class ObjectTeleport
    {
        public int loadOrder = 1;
        public string moduleName = "Object teleport";

        public void OnUpdate()
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
