using PureMod.API;
using UnityEngine;
using PureModLoader.API;
using PureModLoader.ButtonAPI;

namespace PureMod.Addons
{
    public class Hands : ModBase
    {
        public override int LoadOrder => 1;

        public override string ModName => "Hands";

        private NestedButton HandsMenu;

        private bool m_LeftState = false;
        private bool m_RightState = false;
        private RootMotion.FinalIK.VRIK controller;

        public override void OnStart()
        {
            HandsMenu = new NestedButton(QMmenu.mainMenuP1.GetMenuName(), 2, 2, true, "Hands", "HandsMenu", delegate()
            {
                controller = Utils.GetLocalPlayer().gameObject.GetComponentInChildren<RootMotion.FinalIK.VRIK>();
            });

            new ToggleButton(HandsMenu.GetMenuName(), 1, 0, true, "Left", "Control left hand in PC", delegate (bool state)
            {
                m_LeftState = state;
            }, Color.green, Color.white);

            new ToggleButton(HandsMenu.GetMenuName(), 1, 1, true, "Right", "Control right hand in PC", delegate (bool state)
            {
                m_RightState = state;
            }, Color.green, Color.white);
        }

        public override void OnLateUpdate() 
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
