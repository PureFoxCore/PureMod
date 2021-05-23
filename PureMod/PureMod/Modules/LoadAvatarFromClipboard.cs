using VRC;
using VRC.UI;
using VRC.Core;
using PureMod.API;
using PureMod.Other;
using System.Windows.Forms;
using PureModLoader.ButtonAPI;

namespace PureMod.Modules
{
    public class LoadAvatarFromClipboard : ModuleBase
    {
        public override int LoadOrder => 1;
        public override string ModName => "Load Avatar From Clipboard";

        public override void OnStart()
        {
            new SingleButton(QMmenu.mainMenuP1.GetMenuName(), 3, 0, true, "Load Avatar", "Load Avatar From Clipboard", delegate ()
            {
                string text = Clipboard.GetText();

                if (text.StartsWith("avtr_"))
                    new PageAvatar
                    {
                        field_Public_SimpleAvatarPedestal_0 = new SimpleAvatarPedestal
                        {
                            field_Internal_ApiAvatar_0 = new ApiAvatar
                            {
                                id = text
                            }
                        }
                    }.ChangeToSelectedAvatar();
                else
                    ModUtils.PureModLogger.Error("Clipboard does not contains Avatar ID!");
            });
        }
    }
}
