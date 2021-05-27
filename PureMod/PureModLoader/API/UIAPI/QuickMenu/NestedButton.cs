using UnityEngine;

namespace PureModLoader.UIAPI.QM
{
    public class NestedButton
    {
        protected SingleButton mainButton;
        protected SingleButton backButton;
        protected string menuName;
        protected string btnQMLoc;
        protected string btnType;

        /// <summary>
        /// Create menu button (when you click you can create new menu for your buttons)
        /// </summary>
        /// <param name="btnMenu">Where to place this button</param>
        /// <param name="btnXLocation">X location of button (1 means place where worlds button in "ESC" menu)</param>
        /// <param name="btnYLocation">Y location of button (0 means place where worlds button in "ESC" menu)</param>
        /// <param name="btnHalf">Make half button horizontally</param>
        /// <param name="btnText">Button text</param>
        /// <param name="btnToolTip">Button tooltip (shows on top tooltip panel when you hower button)</param>
        /// <param name="action">What to do when you press button (optional)</param>
        /// <param name="btnBackgroundColor">Main button background color (optional)</param>
        /// <param name="btnTextColor">Main button text color (optional)</param>
        /// <param name="backbtnBackgroundColor">Back button background color (optional)</param>
        /// <param name="backbtnTextColor">Back button text color (optional)</param>
        public NestedButton(string btnMenu, int btnXLocation, int btnYLocation, bool btnHalf, string btnText, string btnToolTip, System.Action action = null, Color? btnBackgroundColor = null, Color? btnTextColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null)
        {
            btnQMLoc = btnMenu;
            initButton(btnXLocation, btnYLocation, btnHalf, btnText, btnToolTip, action, btnBackgroundColor, btnTextColor, backbtnBackgroundColor, backbtnTextColor);
        }

        private void initButton(int btnXLocation, int btnYLocation, bool btnHalf, string btnText, string btnToolTip, System.Action action = null, Color? btnBackgroundColor = null, Color? btnTextColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null)
        {
            btnType = "NestedButton";

            Transform menu = Object.Instantiate<Transform>(QMStuff.NestedMenuTemplate(), QMStuff.GetQuickMenuInstance().transform);
            menuName = "PureMOD" + btnQMLoc + "_" + btnXLocation + "_" + btnYLocation;
            menu.name = menuName;

            mainButton = new SingleButton(btnQMLoc, btnXLocation, btnYLocation, btnHalf, btnText, btnToolTip, delegate() 
            {
                if (action != null)
                    action.Invoke();
                QMStuff.ShowQuickmenuPage(menuName);
            }, btnBackgroundColor, btnTextColor);

            Il2CppSystem.Collections.IEnumerator enumerator = menu.transform.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Il2CppSystem.Object obj = enumerator.Current;
                Transform btnEnum = obj.Cast<Transform>();
                if (btnEnum != null)
                    Object.Destroy(btnEnum.gameObject);
            }

            if (backbtnTextColor == null)
                backbtnTextColor = Color.yellow;
            backButton = new SingleButton(menuName, 5, 5, true, "Back", "Go Back", delegate ()
            { 
                QMStuff.ShowQuickmenuPage(btnQMLoc);
            }, backbtnTextColor, backbtnBackgroundColor);
        }

        /// <summary>
        /// Needed to set buttons in to this menu [Menu ID]
        /// </summary>
        /// <returns>Menu path as string</returns>
        public string GetMenuName() =>
            menuName;

        /// <summary>
        /// Main button [menu button]
        /// </summary>
        /// <returns>Single button</returns>
        public SingleButton GetMainButton() =>
            mainButton;

        /// <summary>
        /// Back button
        /// </summary>
        /// <returns>Back button</returns>
        public SingleButton GetBackButton() =>
            backButton;

        /// <summary>
        /// Remove this button
        /// </summary>
        public void DestroyMe()
        {
            mainButton.Destroy();
            backButton.Destroy();
        }
    }
}
