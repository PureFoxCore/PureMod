using PureModLoader.API;
using VRC;

namespace PureMod.Modules
{
    public class JoinNotifier : ModuleBase
    {
        public override int LoadOrder => 0;
        public override string ModuleName => "Join notifier";

        public override void OnPlayerJoin(Player player)
        {
            if (player != null)
                MGUI.LogText($"[{player.prop_APIUser_0.displayName}] joined!");
        }

        public override void OnPlayerLeave(Player player)
        {
            if (player != null)
                MGUI.LogText($"[{player.prop_APIUser_0.displayName}] leaved!");
        }
    }
}
