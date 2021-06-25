﻿using VRC;
using VRC.UI;
using VRC.Core;
using PureModLoader.API;
using PureMod.Other;
using PureModLoader.API.UIAPI.QM;

namespace PureMod.Modules
{
    [Module]
    public class ForceClone
    {
        public string moduleName = "Force Clone";
        public int loadOrder = 1;

        public void OnStart()
        {
            new SingleButton(QMmenu.userMenuP1.MenuPath, 1, 0, true, "ForceClone", "Force clone public avatar", delegate ()
            {
                ApiAvatar avatar = Utils.SelectedPlayer.prop_ApiAvatar_0;

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
