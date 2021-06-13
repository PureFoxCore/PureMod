using VRC;
using PureModLoader.API;

namespace PureMod.Modules
{
    public class JoinNotifier : ModuleBase
    {
        public override int LoadOrder => 0;
        public override string ModuleName => "Join notifier";

        public override void OnPlayerJoin(Player player) =>
            MGUI.LogText($"[{player?.prop_APIUser_0.displayName}] [{player?.prop_APIUser_0.username}] joined!");

        public override void OnPlayerLeave(Player player) =>
            MGUI.LogText($"[{player?.prop_APIUser_0.displayName}] [{player?.prop_APIUser_0.username}] left!");
    }
}
