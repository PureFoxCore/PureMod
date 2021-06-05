using System;
using VRC.Core;
using System.IO;
using UnityEngine;
using System.Linq;
using PureModLoader.API;
using PureMod.Other;
using Newtonsoft.Json;
using System.Collections.Generic;
using PureModLoader.API.UIAPI.MainMenu.AvatarPage;

namespace PureMod.Modules
{
    public class AvatarFav : ModuleBase
    {
        public override int LoadOrder => 2;
        public override string ModuleName => "Avatar fav";

        public static List<string> avatars = new List<string>();
        public string avatarsPath = $"{Utils.ConfigsDirectory}\\PureModAvatars.json";

        public void SaveAvatars()
        {
            if (avatars != null)
                File.WriteAllText(avatarsPath, JsonConvert.SerializeObject(avatars, Formatting.Indented));
        }

        public void LoadConfig()
        {
            if (File.Exists(avatarsPath))
                avatars = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(avatarsPath));
            else
                SaveAvatars();
        }

        public override void OnEarlierStart() =>
            LoadConfig();

        public override void OnStart()
        {
            GameObject.Find("UserInterface/MenuContent/Screens/Avatar/Stats Button/").transform.position += Vector3.one * 99999;
            //var list = AvatarPage.CreateList(1, $"[PureMod] Favorites ({avatars.Count})", avatars);

            //var button = AvatarPage.CreateButton(new Vector2(0, -160), "[PureMod] Favorite", delegate ()
            //{
            //    if (!CheckAndSave(list.UiAvatarListComponent.field_Public_SimpleAvatarPedestal_0.field_Internal_ApiAvatar_0))
            //        ModUtils.PureModLogger.Warn("Can't save private avatar!");

            //    ModUtils.PureModLogger.Trace(avatars.Count);
            //    list.AvatarList = avatars;
            //});

            //list.UiAvatarListComponent.field_Public_SimpleAvatarPedestal_0.field_Internal_Action_3_String_GameObject_AvatarPerformanceStats_0 = new Action<string, GameObject, VRC.SDKBase.Validation.Performance.Stats.AvatarPerformanceStats>((x, y, z) =>
            //{
            //    if (avatars.Any(avatar => avatar == list.UiAvatarListComponent.field_Public_SimpleAvatarPedestal_0.field_Internal_ApiAvatar_0.id))
            //        button.Text = "[PureMod] Unfavorite";
            //    else
            //        button.Text = "[PureMod] Favorite";
            //    list.Text = $"[PureMod] Favorites ({avatars.Count})";
            //});
        }

        private bool CheckAndSave(ApiAvatar avatar)
        {
            if (avatar.releaseStatus == "private" || avatar == null)
                return false;

            if (!avatars.Any(av => av == avatar.id))
                avatars.Add(avatar.id);
            else
                avatars.RemoveAll(av => av == avatar.id);

            SaveAvatars();
            return true;
        }
    }
}
