using UnityEngine;
using PureMod.API;

namespace PureMod.Addons
{
    public class RayTeleport : ModSystem
    {
        public override string ModName => "Ray Teleport";

        public override void OnUpdate()
        {
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetMouseButtonDown(0))
            {
                GameObject playerCamera = Utils.GetLocalPlayerCamera();

                Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
                RaycastHit[] hits = Physics.RaycastAll(ray);
                if (hits.Length > 0)
                {
                    RaycastHit raycastHit = hits[0];
                    Utils.GetLocalPlayer().TeleportTo(raycastHit.point, Utils.GetLocalPlayer().GetRotation());
                }
            }
        }
    }
}
