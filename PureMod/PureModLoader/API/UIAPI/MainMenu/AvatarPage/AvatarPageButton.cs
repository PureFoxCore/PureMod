using System;
using UnityEngine;
using UnityEngine.UI;

namespace PureModLoader.API.UIAPI.MainMenu.AvatarPage
{
    public class AvatarPageButton
    {
        internal AvatarPageButton(GameObject gObject, string text, string name, Vector3 position, Action action)
        {
            gameObject = gObject;
            Text = text;
            Name = name;
            Position = position;
            Action = action;
        }

        private Text TextComponent { get => gameObject.GetComponentInChildren<Text>(); }
        private Button ButtonComponent { get => gameObject.GetComponent<Button>(); }

        public GameObject gameObject { get; private set; }
        public string Name { get; private set; }

        public string Text
        {
            get => TextComponent.text;
            set => TextComponent.text = value;
        }


        public Vector3 Position
        {
            get => gameObject.transform.localPosition;
            set => gameObject.transform.localPosition += value;
        }

        public Action Action
        {
            set
            {
                ButtonComponent.onClick = new Button.ButtonClickedEvent();
                ButtonComponent.onClick.AddListener(value);
            }
        }
    }
}