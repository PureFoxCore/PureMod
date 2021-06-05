using UnityEngine;
using PureModLoader.API;

namespace PureMod.Modules
{
    public class RayTeleport : ModuleBase
    {
        public override int LoadOrder => 1;
        public override string ModuleName => "Ray Teleport";

        public override void OnUpdate()
        {
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetMouseButtonDown(0))
                if (Physics.Raycast(Utils.LocalPlayerCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
                    Utils.LocalPlayer.gameObject.transform.position = hit.point;
        }
    }
}
