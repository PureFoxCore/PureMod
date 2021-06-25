using UnityEngine;
using PureModLoader.API;

namespace PureMod.Modules
{
    [Module]
    public class RayTeleport
    {
        public int loadOrder = 1;
        public string moduleName = "Ray Teleport";

        public void OnUpdate()
        {
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetMouseButtonDown(0))
                if (Physics.Raycast(Utils.LocalPlayerCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
                    Utils.LocalPlayer.gameObject.transform.position = hit.point;
        }
    }
}
