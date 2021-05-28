using VRC.Core;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

namespace PureModLoader.API.UIAPI.MainMenu.AvatarPage
{
    public class AvatarScroll
    {
        internal AvatarScroll(int index, GameObject gObject, string text, List<string> avatars)
        {
            Text = text;
            //Index = index;
            gameObject = gObject;
            AvatarList = avatars;
            gameObject.transform.SetSiblingIndex(index);
        }

        public GameObject gameObject { get; private set; }

        private Text TextComponent { get => gameObject.transform.Find("Button").GetComponentInChildren<Text>(); }
        public UiAvatarList UiAvatarListComponent { get => gameObject.GetComponent<UiAvatarList>(); }

        public string Text
        {
            //get => TextComponent.text;
            //set => TextComponent.text = value;
            get; set;
        }

        public int Index { set => gameObject.transform.SetSiblingIndex(value); }

        public List<string> AvatarList
        {
            set
            {
                UiAvatarListComponent.field_Private_Dictionary_2_String_ApiAvatar_0.Clear();
                foreach (var t in value.ToArray().Reverse().ToArray())
                {
                    if (!UiAvatarListComponent.field_Private_Dictionary_2_String_ApiAvatar_0.ContainsKey(t))
                        UiAvatarListComponent.field_Private_Dictionary_2_String_ApiAvatar_0.Add(t, null);
                }
                UiAvatarListComponent.field_Public_ArrayOf_0 = value.ToArray().Reverse().ToArray();
                UiAvatarListComponent.Method_Protected_Virtual_Void_Int32_0(0);
            }
        }
    }
}
