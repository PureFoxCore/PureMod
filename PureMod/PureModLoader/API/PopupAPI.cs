using System;
using UnityEngine;
using UnityEngine.UI;
using Il2CppSystem.Collections.Generic;

namespace PureModLoader.API
{
    public static class PopupAPI
    {
        public static void CloseCurrentPopup()
        {
            GameObject.Find("UserInterface/MenuContent/Popups/StandardPopup/BodyText").GetComponent<Text>().color = Color.white;
            GameObject.Find("UserInterface/MenuContent/Popups/StandardPopup/ButtonMiddle/Text").GetComponent<Text>().color = Color.white;

            GameObject.Find("UserInterface/MenuContent/Popups/StandardPopupV2/Popup/TitleText").GetComponent<Text>().color = Color.yellow;
            GameObject.Find("UserInterface/MenuContent/Popups/StandardPopupV2/Popup/InfoText").GetComponent<Text>().color = Color.white;
            GameObject.Find("UserInterface/MenuContent/Popups/StandardPopupV2/Popup/Buttons/LeftButton/Text").GetComponent<Text>().color = Color.white;
            GameObject.Find("UserInterface/MenuContent/Popups/StandardPopupV2/Popup/Buttons/RightButton/Text").GetComponent<Text>().color = Color.yellow;

            GameObject.Find("UserInterface/MenuContent/Popups/InputPopup/ButtonLeft/Text").GetComponent<Text>().text = "Cancel";
            GameObject.Find("UserInterface/MenuContent/Popups/InputPopup/TitleText").GetComponent<Text>().color = Color.white;
            GameObject.Find("UserInterface/MenuContent/Popups/InputPopup/ButtonLeft/Text").GetComponent<Text>().color = Color.white;
            GameObject.Find("UserInterface/MenuContent/Popups/InputPopup/ButtonRight/Text").GetComponent<Text>().color = Color.white;
            GameObject.Find("UserInterface/MenuContent/Popups/InputPopup/InputField/Text").GetComponent<Text>().color = Color.white;

            VRCUiPopupManager.field_Private_Static_VRCUiPopupManager_0.Method_Public_Void_4();
        }

        public static void CreateSimplePopup(string title, string description, string confirmButtonText, Action confirm, Action<VRCUiPopup> open, Color? confirmButtonTextColor = null, Color? descriptionColor = null)
        {
            VRCUiPopupManager.field_Private_Static_VRCUiPopupManager_0.Method_Public_Void_String_String_String_Action_Action_1_VRCUiPopup_0(title, description, confirmButtonText, new Action(() =>
            {
                if (confirm != null)
                    confirm.Invoke();
                CloseCurrentPopup();
            }), new Action<VRCUiPopup>((VRCUiPopup popup) =>
            {
                if (open != null)
                    open.Invoke(popup);
                CloseCurrentPopup();
            }));

            if (confirmButtonTextColor != null)
                GameObject.Find("UserInterface/MenuContent/Popups/StandardPopup/ButtonMiddle/Text").GetComponent<Text>().color = (Color)confirmButtonTextColor;
            if (descriptionColor != null)
                GameObject.Find("UserInterface/MenuContent/Popups/StandardPopup/BodyText").GetComponent<Text>().color = (Color)descriptionColor;
        }

        public static void CreateConfirmPopup(string title, string description, string confirmButtonText, string cancelButtonText, Action confirm, Action cancel, Action<VRCUiPopup> open, Color? confirmButtonTextColor = null, Color? cancelButtonTextColor = null, Color? titleTextColor = null, Color? descriptionTextColor = null)
        {
            VRCUiPopupManager.field_Private_Static_VRCUiPopupManager_0.Method_Public_Void_String_String_String_Action_String_Action_Action_1_VRCUiPopup_0(title, description, cancelButtonText, new Action(() =>
            {
                if (cancel != null)
                    cancel.Invoke();
                CloseCurrentPopup();
            }), confirmButtonText, new Action(() =>
            {
                if (confirm != null)
                    confirm.Invoke();
                CloseCurrentPopup();
            }), new Action<VRCUiPopup>((VRCUiPopup popup) =>
            {
                if (open != null)
                    open.Invoke(popup);
                CloseCurrentPopup();
            }));

            if (titleTextColor != null)
                GameObject.Find("UserInterface/MenuContent/Popups/StandardPopupV2/Popup/TitleText").GetComponent<Text>().color = (Color)titleTextColor;
            if (descriptionTextColor != null)
                GameObject.Find("UserInterface/MenuContent/Popups/StandardPopupV2/Popup/InfoText").GetComponent<Text>().color = (Color)descriptionTextColor;
            if (cancelButtonTextColor != null)
                GameObject.Find("UserInterface/MenuContent/Popups/StandardPopupV2/Popup/Buttons/LeftButton/Text").GetComponent<Text>().color = (Color)cancelButtonTextColor;
            if (confirmButtonTextColor != null)
                GameObject.Find("UserInterface/MenuContent/Popups/StandardPopupV2/Popup/Buttons/RightButton/Text").GetComponent<Text>().color = (Color)confirmButtonTextColor;
        }

        public static void CreateInputPopup(string title, string text, string placeHolder, string cancelButtonText, string confirmButtonText, InputField.InputType inputType, bool numberKeyboard, Action<string> confirm, Action cancel, Action<VRCUiPopup> open)
        {
            VRCUiPopupManager.field_Private_Static_VRCUiPopupManager_0.Method_Public_Void_String_String_InputType_Boolean_String_Action_3_String_List_1_KeyCode_Text_Action_String_Boolean_Action_1_VRCUiPopup_Boolean_Int32_0(title, text, inputType, numberKeyboard, confirmButtonText, new Action<string, List<KeyCode>, Text>((string inputText, List<KeyCode> keycodes, Text textComponent) =>
            {
                if (confirm != null)
                    confirm.Invoke(inputText);
                CloseCurrentPopup();
            }), new Action(() =>
            {
                if (cancel != null)
                    cancel.Invoke();
                CloseCurrentPopup();
            }), placeHolder, true, new Action<VRCUiPopup>((VRCUiPopup popup) =>
            {
                if (open != null)
                    open.Invoke(popup);
                CloseCurrentPopup();
            }));

            GameObject.Find("UserInterface/MenuContent/Popups/InputPopup/ButtonLeft/Text").GetComponent<Text>().text = cancelButtonText;
        }
    }
}
