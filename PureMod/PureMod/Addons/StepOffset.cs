using UnityEngine;
using PureMod.API;
using PureMod.API.ButtonAPI;

namespace PureMod.Addons
{
    public class StepOffset : ModSystem
    {
        public override int LoadOrder => 13;
        public override string ModName => "Step Offset";

        public override void OnStart()
        {
            new ToggleButton(QMmenu.mainMenuP1.GetMenuName(), 4, 1, true, "Step Offset", "Allows you climb without jump", delegate (bool state)
            {
                CharacterController characterController = Utils.GetLocalPlayer().gameObject.GetComponent<CharacterController>();

                characterController.stepOffset = state && characterController.isGrounded ? 1.6f : 0.5f;
                characterController.slopeLimit = state && characterController.isGrounded ? 90 : 60;
            }, Color.green, Color.white);
        }
    }
}
