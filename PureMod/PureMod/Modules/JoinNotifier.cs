using VRC;
using PureModLoader.API;

namespace PureMod.Modules
{
    [Module]
    public class JoinNotifier
    {
        public int loadOrder = 0;
        public string moduleName = "Join notifier";

        public void OnPlayerJoin(Player player) =>
            MGUI.LogText($"[{player?.prop_APIUser_0.displayName}] [{player?.prop_APIUser_0.username}] joined!");

        public void OnPlayerLeave(Player player) =>
            MGUI.LogText($"[{player?.prop_APIUser_0.displayName}] [{player?.prop_APIUser_0.username}] left!");
    }
}
