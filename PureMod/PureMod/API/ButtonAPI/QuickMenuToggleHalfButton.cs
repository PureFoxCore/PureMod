using System;
using UnityEngine;
using UnityEngine.UI;

namespace PureMod.API.ButtonAPI
{
    public class QuickMenuToggleHalfButton : QuickMenuHalfButtonBase
    {
        public bool m_State { get; private set; }

        public QuickMenuToggleHalfButton(QuickMenuNestedButton buttonMenu, int xLocation, int yLocation, string text, string toolTip, Action<bool> action, Color textColorOn, Color textColorOff, bool state = false, Color? backgroundColor = null)
        {
            buttonQuickMenuLocation = buttonMenu.menuName;
            initializeButton(xLocation, yLocation, text, toolTip, action, state, textColorOn, textColorOff, backgroundColor);
        }

        public QuickMenuToggleHalfButton(QuickMenuNestedHalfButton buttonMenu, int xLocation, int yLocation, string text, string toolTip, Action<bool> action, Color textColorOn, Color textColorOff, bool state = false, Color? backgroundColor = null)
        {
            buttonQuickMenuLocation = buttonMenu.menuName;
            initializeButton(xLocation, yLocation, text, toolTip, action, state, textColorOn, textColorOff, backgroundColor);
        }

        public QuickMenuToggleHalfButton(string buttonMenu, int xLocation, int yLocation, string text, string toolTip, Action<bool> action, Color textColorOn, Color textColorOff, bool state = false, Color? backgroundColor = null)
        {
            buttonQuickMenuLocation = buttonMenu;
            initializeButton(xLocation, yLocation, text, toolTip, action, state, textColorOn, textColorOff, backgroundColor);
        }

        private void initializeButton(int xLocation, int yLocation, string text, string toolTip, Action<bool> action, bool state, Color textColorOn, Color textColorOff, Color? backgroundColor = null)
        {
            buttonType = "ToggleButton";
            button = UnityEngine.Object.Instantiate(s_SingleButton, s_QuickMenu.transform.Find(buttonQuickMenuLocation), true);

            initShift[0] = -1;
            initShift[1] = 0;

            SetLocation(xLocation, yLocation);
            SetButtonText(text);
            SetToolTip(toolTip);
            SetButtonAction(action, textColorOn, textColorOff);

            m_State = state;

            if (backgroundColor != null)
                SetBackgroundColor((Color)backgroundColor);
            else
                OriginalBackgroundColor = button.GetComponentInChildren<Image>().color;

            if (state)
                SetTextColor(textColorOn);
            else if (!state)
                SetTextColor(textColorOff);

            else
                OriginalTextColor = button.GetComponentInChildren<Text>().color;

            SetActive(true);
        }

        public void SetButtonText(string text) =>
            button.GetComponentInChildren<Text>().text = text;

        public void SetButtonAction(Action<bool> action, Color colorOn, Color colorOff)
        {
            button.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();

            if (action != null)
            {
                button.GetComponent<Button>().onClick.AddListener(new Action(() =>
                {
                    m_State = !m_State;
                    SetTextColor(m_State ? colorOn : colorOff);
                    action.Invoke(m_State);
                }));
            }
        }

        public override void SetTextColor(Color color, bool save = true)
        {
            button.GetComponentInChildren<Text>().color = color;

            if (save)
                OriginalTextColor = color;
        }

        public override void SetBackgroundColor(Color color, bool save = true)
        {
            if (save)
                OriginalBackgroundColor = color;

            button.GetComponentInChildren<Button>().colors = new ColorBlock()
            {
                colorMultiplier = 1f,
                disabledColor = Color.gray,
                highlightedColor = color * 1.5f,
                normalColor = color / 1.5f,
                pressedColor = Color.gray
            };
        }
    }
}
