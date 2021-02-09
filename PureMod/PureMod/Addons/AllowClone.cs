using VRC.Core;
using VRC.SDKBase;
using PureMod.API;
using PureMod.API.ButtonAPI;

namespace PureMod.Addons
{
    public class AllowClone : ModSystem
    {
        public override int LoadOrder => 3;
        public override string ModName => "Avatar clone";

        public override void OnStart()
        {
            new QuickMenuSingleHalfButton(QuickMenuMenu.mainMenuP1, 2, 0, "Allow Clone", delegate ()
            {
                for (int i = 0; i < 5; i++)
                    foreach (var apiUser in Utils.GetAPIUsers())
                        apiUser.allowAvatarCopying = true;
            }, "Allow avatar cloning for all players");
        }
    }
}
