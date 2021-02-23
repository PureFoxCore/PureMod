using PureMod.API;

namespace PureMod.Addons
{
    public class HandController : ModSystem
    {
        public override int LoadOrder => 18;

        public override string ModName => "Hand Controller";

        public override void OnStart()
        {
            new ButtonAPI.SingleButton(QMmenu.mainMenuP1.GetMenuName(), 2, 2, true, "Hands", "Control hands in PC", delegate ()
            {
                //var controller = Utils.GetLocalPlayer().prop_VRCAvatarManager_0.prop_GameObject_0.GetComponent<RootMotion.FinalIK.VRIK>();
                //if (Input.GetMouseButton(1))
                //{
                //    if (controller != null)
                //    {
                //        switch (hand)
                //        {
                //            case Hand.Left:
                //                controller.solver.leftArm.positionWeight = 1;
                //                controller.solver.leftArm.rotationWeight = 1;
                //                break;
                //            case Hand.Right:
                //                controller.solver.rightArm.positionWeight = 1;
                //                controller.solver.rightArm.rotationWeight = 1;
                //                break;
                //            case Hand.Both:
                //                controller.solver.leftArm.positionWeight = 1;
                //                controller.solver.leftArm.rotationWeight = 1;
                //                controller.solver.rightArm.positionWeight = 1;
                //                controller.solver.rightArm.rotationWeight = 1;
                //                break;
                //            default:
                //                break;
                //        }
                //    }
                //}
            });
        }
    }
}
