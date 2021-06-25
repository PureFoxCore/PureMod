using System;
using VRC.Core;
using System.IO;
using UnityEngine;
using System.Linq;
using PureMod.Other;
using UnityEngine.UI;
using Newtonsoft.Json;
using PureModLoader.API;
using System.Collections.Generic;

namespace PureMod.Modules
{
    [Module]
    public class AvatarFav
    {
        public int loadOrder = 2;
        public string moduleName = "Avatar fav";

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

        public void OnAwake() =>
            LoadConfig();

        public void OnStart()
        {
            GameObject.Find("UserInterface/MenuContent/Screens/Avatar/Stats Button/").transform.position += Vector3.one * 99999;

            var originalList = GameObject.Find("UserInterface/MenuContent/Screens/Avatar/Vertical Scroll View/Viewport/Content/Favorite Avatar List");
            var createdList = GameObject.Instantiate(originalList, originalList.transform.parent);
            createdList.transform.name = "PureModFavList";
            var aviList = createdList.GetComponent<UiAvatarList>();
            aviList.field_Private_Dictionary_2_String_ApiAvatar_0.Clear();
            aviList.field_Public_EnumNPublicSealedvaInPuMiFaSpClPuLiCrUnique_0 = UiAvatarList.EnumNPublicSealedvaInPuMiFaSpClPuLiCrUnique.SpecificList;
            aviList.StopAllCoroutines();

            createdList.transform.Find("Button").GetComponentInChildren<Text>().text = $"[PureMod] Favorites ({avatars.Count})";

            createdList.GetComponent<UiAvatarList>().field_Private_Dictionary_2_String_ApiAvatar_0.Clear();
            foreach (var t in avatars.ToArray().Reverse().ToArray())
            {
                if (!createdList.GetComponent<UiAvatarList>().field_Private_Dictionary_2_String_ApiAvatar_0.ContainsKey(t))
                    createdList.GetComponent<UiAvatarList>().field_Private_Dictionary_2_String_ApiAvatar_0.Add(t, null);
            }
            createdList.GetComponent<UiAvatarList>().field_Public_ArrayOf_0 = avatars.ToArray().Reverse().ToArray();
            createdList.GetComponent<UiAvatarList>().Method_Protected_Virtual_Void_Int32_0(0);
            createdList.transform.SetSiblingIndex(1);

            var originalButton = GameObject.Find("UserInterface/MenuContent/Screens/Avatar/Change Button/");
            var createdButton = GameObject.Instantiate(originalButton, originalButton.transform.parent);
            createdButton.transform.name = "PureModFav";
            createdButton.transform.localPosition += new Vector3(0, -160, 0);
            createdButton.GetComponentInChildren<Text>().text = "[PureMod] Unfavorite";
            createdButton.GetComponentInChildren<Button>().onClick = new Button.ButtonClickedEvent();
            createdButton.GetComponentInChildren<Button>().onClick.AddListener(new Action(() =>
            {
                if (!CheckAndSave(createdList.GetComponent<UiAvatarList>().field_Public_SimpleAvatarPedestal_0.field_Internal_ApiAvatar_0))
                    ModUtils.PureModLogger.Warn("Can't save private avatar!");

                createdList.transform.Find("Button").GetComponentInChildren<Text>().text = $"[PureMod] Favorites ({avatars.Count})";

                createdList.GetComponent<UiAvatarList>().field_Private_Dictionary_2_String_ApiAvatar_0.Clear();
                foreach (var t in avatars.ToArray().Reverse().ToArray())
                {
                    if (!createdList.GetComponent<UiAvatarList>().field_Private_Dictionary_2_String_ApiAvatar_0.ContainsKey(t))
                        createdList.GetComponent<UiAvatarList>().field_Private_Dictionary_2_String_ApiAvatar_0.Add(t, null);
                }
                createdList.GetComponent<UiAvatarList>().field_Public_ArrayOf_0 = avatars.ToArray().Reverse().ToArray();
                createdList.GetComponent<UiAvatarList>().Method_Protected_Virtual_Void_Int32_0(0);
            }));

            createdList.GetComponent<UiAvatarList>().field_Public_SimpleAvatarPedestal_0.field_Internal_Action_3_String_GameObject_AvatarPerformanceStats_0 = new Action<string, GameObject, VRC.SDKBase.Validation.Performance.Stats.AvatarPerformanceStats>((x, y, z) =>
            {
                if (avatars.Any(avatar => avatar == createdList.GetComponent<UiAvatarList>().field_Public_SimpleAvatarPedestal_0.field_Internal_ApiAvatar_0.id))
                    createdButton.GetComponentInChildren<Text>().text = "[PureMod] Unfavorite";
                else
                    createdButton.GetComponentInChildren<Text>().text = "[PureMod] Favorite";
                createdList.transform.Find("Button").GetComponentInChildren<Text>().text = $"[PureMod] Favorites ({avatars.Count})";
            });
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
