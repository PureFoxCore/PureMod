using UnityEngine;
using VRC.SDKBase;
using PureMod.API;

namespace PureMod.Addons
{
    public class AllowClone : ModSystem
    {
        public override string ModName => "Avatar clone";

        public override void OnUpdate()
        {
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.Alpha5))
                foreach (var player in VRCPlayerApi.AllPlayers)
                {

                }
        }
    }
}
