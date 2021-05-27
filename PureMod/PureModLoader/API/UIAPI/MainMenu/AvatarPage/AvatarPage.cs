using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRC.Core;

namespace PureModLoader.API.UIAPI.MainMenu.AvatarPage
{
    public static class AvatarPage
    {
        public static AvatarPageButton CreateButton(Vector2 position, string text, Action action)
        {
            var originalButton = GameObject.Find("UserInterface/MenuContent/Screens/Avatar/Change Button/");
            var createdButton = GameObject.Instantiate(originalButton, originalButton.transform.parent);
            createdButton.transform.name = $"[{position.x}_{position.y}]__{text}";
            return new AvatarPageButton(createdButton, text, createdButton.transform.name, position, action);
        }

        public static AvatarScroll CreateList(int index, string text, List<string> avatars)
        {
            var originalList = GameObject.Find("UserInterface/MenuContent/Screens/Avatar/Vertical Scroll View/Viewport/Content/Favorite Avatar List");
            var createdList = GameObject.Instantiate(originalList, originalList.transform.parent);
            createdList.transform.name = $"{index}_{text}";
            var aviList = createdList.GetComponent<UiAvatarList>();
            aviList.field_Private_Dictionary_2_String_ApiAvatar_0.Clear();
            aviList.field_Public_EnumNPublicSealedvaInPuMiFaSpClPuLiCrUnique_0 = UiAvatarList.EnumNPublicSealedvaInPuMiFaSpClPuLiCrUnique.SpecificList;
            aviList.StopAllCoroutines();

            return new AvatarScroll(index, createdList, text, avatars);
        }
    }
}
