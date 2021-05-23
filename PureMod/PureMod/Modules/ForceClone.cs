using VRC;
using VRC.UI;
using VRC.Core;
using PureMod.API;
using PureMod.Other;
using PureModLoader.API;
using PureModLoader.ButtonAPI;

namespace PureMod.Modules
{
    public class ForceClone : ModuleBase
    {
        public override string ModName => "Force Clone";
        public override int LoadOrder => 1;

        public override void OnStart()
        {
            new SingleButton(QMmenu.userMenuP1.GetMenuName(), 1, 0, true, "ForceClone", "Force clone public avatar", delegate ()
            {
                ApiAvatar avatar = Utils.GetSelectedPlayer().prop_ApiAvatar_0;

                if (avatar.releaseStatus != "private")
                {
                    new PageAvatar
                    {
                        field_Public_SimpleAvatarPedestal_0 = new SimpleAvatarPedestal
                        {
                            field_Internal_ApiAvatar_0 = new ApiAvatar
                            {
                                id = avatar.id
                            }
                        }
                    }.ChangeToSelectedAvatar();
                    ModUtils.PureModLogger.Trace($"Changed to avatar: {avatar.id}");
                }
                else
                    ModUtils.PureModLogger.Warn($"Avatar release status is PRIVATE! ID: {avatar.id}");
            });
        }
    }
}
