using UnityEngine;
using UnityEngine.UI;

namespace PureMod.ButtonAPI
{
    public class ToggleButton : ButtonBase
    {
        private bool m_State;

        public ToggleButton(string btnMenu, int btnXLocation, int btnYLocation, bool btnHalf, string btnText, string btnToolTip, System.Action<bool> btnAction, Color btnTextColorOn, Color btnTextColorOff, bool state = false, Color? btnBackgroundColor = null)
        {
            btnQMLoc = btnMenu;
            initButton(btnXLocation, btnYLocation, btnHalf, btnText, btnAction, btnToolTip, btnBackgroundColor, btnTextColorOn, state, btnTextColorOff);
        }

        private void initButton(int btnXLocation, int btnYLocation, bool btnHalf, string btnText, System.Action<bool> btnAction, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColorOn = null, bool state = false, Color? btnTextColorOff = null)
        {
            btnType = "SingleButton";
            button = Object.Instantiate(QMStuff.SingleButtonTemplate(), QMStuff.GetQuickMenuInstance().transform.Find(btnQMLoc), true);

            initShift[0] = -1;
            initShift[1] = 0;
            SetLocation(btnXLocation, btnYLocation, btnHalf);
            SetButtonText(btnText);
            SetToolTip(btnToolTip);
            SetAction(btnAction, (Color)btnTextColorOn, (Color)btnTextColorOff);

            if (btnBackgroundColor != null)
                SetBackgroundColor((Color)btnBackgroundColor);
            else
                OrigBackground = button.GetComponentInChildren<Image>().color;

            m_State = state;

            if (state)
                SetTextColor((Color)btnTextColorOn);
            else
                SetTextColor((Color)btnTextColorOff);

            SetActive(true);
        }

        public void SetButtonText(string buttonText) =>
            button.GetComponentInChildren<Text>().text = buttonText;

        public void SetAction(System.Action<bool> buttonAction, Color colorOn, Color colorOff)
        {
            button.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
            if (buttonAction != null)
                button.GetComponent<Button>().onClick.AddListener(new System.Action(() =>
                {
                    m_State = !m_State;
                    SetTextColor(m_State ? colorOn : colorOff);
                    buttonAction.Invoke(m_State);
                }));
        }

        public void Invoke() =>
            button.GetComponent<Button>().onClick.Invoke();

        public override void SetBackgroundColor(Color buttonBackgroundColor, bool save = true)
        {
            if (save)
                OrigBackground = buttonBackgroundColor;

            button.GetComponentInChildren<Button>().colors = new ColorBlock()
            {
                colorMultiplier = 1f,
                disabledColor = Color.grey,
                highlightedColor = buttonBackgroundColor * 1.5f,
                normalColor = buttonBackgroundColor / 1.5f,
                pressedColor = Color.grey * 1.5f
            };
        }

        public override void SetTextColor(Color buttonTextColor, bool save = true)
        {
            button.GetComponentInChildren<Text>().color = buttonTextColor;
            if (save)
                OrigText = buttonTextColor;
        }
    }
}
