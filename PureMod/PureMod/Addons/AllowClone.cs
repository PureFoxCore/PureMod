using PureMod.API;

namespace PureMod.Addons
{
    public class AllowClone : ModSystem
    {
        public override int LoadOrder => 3;
        public override string ModName => "Avatar clone";

        public override void OnStart()
        {
            new ButtonAPI.SingleButton(QMmenu.mainMenuP1.GetMenuName(), 3, 0, true, "Allow Clone", "Allow avatar cloning for all players", delegate ()
            {
                for (int i = 0; i < 5; i++)
                    foreach (var apiUser in Utils.GetAPIUsers())
                        apiUser.allowAvatarCopying = true;
                Utils.CoreLogger.Info("Public avatar clone allowed!");
            });
        }
    }
}
