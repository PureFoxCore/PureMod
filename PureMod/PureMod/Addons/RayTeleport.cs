using UnityEngine;
using PureMod.API;

namespace PureMod.Addons
{
    public class RayTeleport : ModSystem
    {
        public override int LoadOrder => 4;
        public override string ModName => "Ray Teleport";

        public override void OnUpdate()
        {
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetMouseButtonDown(0))
                if (Physics.Raycast(Utils.GetLocalPlayerCamera().GetComponent<Camera>().ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
                    Utils.GetLocalPlayer().TeleportTo(hit.point, Utils.GetLocalPlayer().GetRotation());
        }
    }
}
