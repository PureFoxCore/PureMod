using UnityEngine;
using UnityEngine.UI;

namespace PureModLoader.API.UIAPI.QM
{
    public class SingleButton : ButtonBase
    {
        public Button Button { get; internal set; }

        /// <summary>
        /// Create simple button
        /// </summary>
        /// <param name="btnMenu">Where to place this button</param>
        /// <param name="btnXLocation">X location of button (1 means place where worlds button in "ESC" menu)</param>
        /// <param name="btnYLocation">Y location of button (0 means place where worlds button in "ESC" menu)</param>
        /// <param name="btnHalf">Make half button horizontally</param>
        /// <param name="btnText">Button text</param>
        /// <param name="btnToolTip">Button tooltip (shows on top tooltip panel when you hower button)</param>
        /// <param name="btnAction">What to do when you press button</param>
        /// <param name="btnTextColor">Button text color (optional)</param>
        /// <param name="btnBackgroundColor">Button background color (optional)</param>
        public SingleButton(string btnMenu, int btnXLocation, int btnYLocation, bool btnHalf, string btnText, string btnToolTip, System.Action btnAction, Color? btnTextColor = null, Color? btnBackgroundColor = null)
        {
            btnQMLoc = btnMenu;
            initButton(btnXLocation, btnYLocation, btnHalf, btnText, btnAction, btnToolTip, btnBackgroundColor, btnTextColor);
        }

        private void initButton(int btnXLocation, int btnYLocation, bool btnHalf, string btnText, System.Action btnAction, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null)
        {
            btnType = "SingleButton";
            button = Object.Instantiate(QMStuff.SingleButtonTemplate(), QMStuff.GetQuickMenuInstance().transform.Find(btnQMLoc), true);

            Button = button.GetComponent<Button>();

            initShift[0] = -1;
            initShift[1] = 0;
            SetLocation(btnXLocation, btnYLocation, btnHalf);
            SetButtonText(btnText);
            SetToolTip(btnToolTip);
            SetAction(btnAction);


            if (btnBackgroundColor != null)
                SetBackgroundColor((Color)btnBackgroundColor);
            else
                OrigBackground = button.GetComponentInChildren<Image>().color;

            if (btnTextColor != null)
                SetTextColor((Color)btnTextColor);
            else
                OrigText = button.GetComponentInChildren<Text>().color;

            SetActive(true);
        }

        /// <summary>
        /// Change current button text
        /// </summary>
        /// <param name="buttonText">New text</param>
        public void SetButtonText(string buttonText) =>
            button.GetComponentInChildren<Text>().text = buttonText;

        /// <summary>
        /// Change current button action
        /// </summary>
        /// <param name="buttonAction">New action</param>
        public void SetAction(System.Action buttonAction)
        {
            button.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
            if (buttonAction != null)
                button.GetComponent<Button>().onClick.AddListener(buttonAction);
        }

        /// <summary>
        /// Change current button background color
        /// </summary>
        /// <param name="buttonBackgroundColor">New background color</param>
        /// <param name="save">Override new color? (by default true)</param>
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

        /// <summary>
        /// Change current button text color
        /// </summary>
        /// <param name="buttonTextColor">New text color</param>
        /// <param name="save">Override new color? (by default true)</param>
        public override void SetTextColor(Color buttonTextColor, bool save = true)
        {
            button.GetComponentInChildren<Text>().color = buttonTextColor;
            if (save)
                OrigText = buttonTextColor;
        }
    }
}
