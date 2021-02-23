using UnityEngine;

namespace PureMod.ButtonAPI
{
    public class NestedButton
    {
        protected ButtonAPI.SingleButton mainButton;
        protected ButtonAPI.SingleButton backButton;
        protected string menuName;
        protected string btnQMLoc;
        protected string btnType;

        public NestedButton(string btnMenu, int btnXLocation, int btnYLocation, bool btnHalf, string btnText, string btnToolTip, System.Action action = null, Color? btnBackgroundColor = null, Color? btnTextColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null)
        {
            btnQMLoc = btnMenu;
            initButton(btnXLocation, btnYLocation, btnHalf, btnText, btnToolTip, action, btnBackgroundColor, btnTextColor, backbtnBackgroundColor, backbtnTextColor);
        }

        public void initButton(int btnXLocation, int btnYLocation, bool btnHalf, string btnText, string btnToolTip, System.Action action = null, Color? btnBackgroundColor = null, Color? btnTextColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null)
        {
            btnType = "NestedButton";

            Transform menu = Object.Instantiate<Transform>(QMStuff.NestedMenuTemplate(), QMStuff.GetQuickMenuInstance().transform);
            menuName = "PureMOD" + btnQMLoc + "_" + btnXLocation + "_" + btnYLocation;
            menu.name = menuName;

            mainButton = new ButtonAPI.SingleButton(btnQMLoc, btnXLocation, btnYLocation, btnHalf, btnText, btnToolTip, delegate() 
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
            backButton = new ButtonAPI.SingleButton(menuName, 5, 5, true, "Back", "Go Back", delegate ()
            { 
                QMStuff.ShowQuickmenuPage(btnQMLoc);
            }, backbtnTextColor, backbtnBackgroundColor);
        }

        public string GetMenuName() =>
            menuName;

        public ButtonAPI.SingleButton GetMainButton() =>
            mainButton;

        public SingleButton GetBackButton() =>
            backButton;

        public void DestroyMe()
        {
            mainButton.DestroyMe();
            backButton.DestroyMe();
        }
    }
}
