using VRC;
using VRC.UI;
using VRC.Core;
using PureMod.API;

namespace PureMod.Addons
{
    public class ForceClone : ModSystem
    {
        public override string ModName => "Force Clone";
        public override int LoadOrder => 1;

        public override void OnStart()
        {
            new ButtonAPI.SingleButton(QMmenu.userMenuP1.GetMenuName(), 1, 0, true, "ForceClone", "Force clone public avatar0", delegate ()
            {
                ApiAvatar avatar = Utils.GetSelectedPlayer().field_Internal_VRCPlayer_0.prop_ApiAvatar_0;

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
                    Utils.CoreLogger.Trace($"Changed to avatar: {avatar.id}");
                }
                else
                    Utils.CoreLogger.Warn($"Avatar release status is PRIVATE! ID: {avatar.id}");
            });
        }
    }
}
