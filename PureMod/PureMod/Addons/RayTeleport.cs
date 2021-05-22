using UnityEngine;
using PureMod.API;
using PureModLoader.API;

namespace PureMod.Addons
{
    public class RayTeleport : ModBase
    {
        public override int LoadOrder => 1;
        public override string ModName => "Ray Teleport";

        public override void OnUpdate()
        {
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetMouseButtonDown(0))
                if (Physics.Raycast(Utils.GetLocalPlayerCamera().GetComponent<Camera>().ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
                    Utils.GetLocalPlayer().gameObject.transform.position = hit.point;
        }
    }
}
