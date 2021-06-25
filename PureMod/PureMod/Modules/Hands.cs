using PureModLoader.API;
using UnityEngine;
using PureModLoader.API.UIAPI.QM;

namespace PureMod.Modules
{
    [Module]
    public class Hands
    {
        public int loadOrder = 1;

        public string moduleName = "Hands";

        private NestedButton HandsMenu;

        private bool m_LeftState = false;
        private bool m_RightState = false;
        private RootMotion.FinalIK.VRIK controller;

        public void OnStart()
        {
            HandsMenu = new NestedButton(QMmenu.mainMenuP1.MenuPath, 2, 2, true, "Hands", "HandsMenu", delegate()
            {
                controller = Utils.LocalPlayer.gameObject.GetComponentInChildren<RootMotion.FinalIK.VRIK>();
            });

            new ToggleButton(HandsMenu.MenuPath, 1, 0, true, "Left", "Control left hand in PC", delegate (bool state)
            {
                m_LeftState = state;
            }, Color.green, Color.white);

            new ToggleButton(HandsMenu.MenuPath, 1, 1, true, "Right", "Control right hand in PC", delegate (bool state)
            {
                m_RightState = state;
            }, Color.green, Color.white);
        }

        public void OnLateUpdate() 
        {
            if (controller != null)
            {
                if (m_LeftState)
                {
                    controller.solver.leftArm.positionWeight = 1;
                    controller.solver.leftArm.rotationWeight = 1;
                }
                else
                {
                    controller.solver.leftArm.positionWeight = 0;
                    controller.solver.leftArm.rotationWeight = 0;
                }

                if (m_RightState)
                {
                    controller.solver.rightArm.positionWeight = 1;
                    controller.solver.rightArm.rotationWeight = 1;
                }
                else
                {
                    controller.solver.rightArm.positionWeight = 0;
                    controller.solver.rightArm.rotationWeight = 0;
                }
            }
        }
    }
}
