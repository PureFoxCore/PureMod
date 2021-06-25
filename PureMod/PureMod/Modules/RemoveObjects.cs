using UnityEngine;
using PureModLoader.API;
using VRC.SDKBase;

namespace PureMod.Modules
{
    [Module]
    public class RemoveObjects
    {
        public int loadOrder = 1;
        public string moduleName = "Remove Objects";

        public void OnUpdate()
        {
            if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.Mouse2))
                if (Physics.Raycast(Utils.LocalPlayerCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
                {
                    Networking.SetOwner(Utils.LocalPlayer.field_Private_VRCPlayerApi_0, hit.collider.gameObject);
                    Networking.Destroy(hit.collider.gameObject);
                }
        }
    }
}
