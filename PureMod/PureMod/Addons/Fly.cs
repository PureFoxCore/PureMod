using System;
using UnityEngine;
using PureMod.API;
using PureModLoader.API;
using PureModLoader.ButtonAPI;

namespace PureMod.Addons
{
    public class Fly : ModBase
    {
        public override int LoadOrder => 1;
        public override string ModName => "Fly";

        public static int flySpeed = 2;
        public static bool isFly = false;

        private GameObject player;
        private GameObject playerCamera;

        private NestedButton flyMenu;
        private ToggleButton flyButton;
        private SingleButton speedResetButton;

        public override void OnStart()
        {
            flyMenu = new NestedButton(QMmenu.mainMenuP1.GetMenuName(), 1, 0, true, "Fly", "Fly menu");

            flyButton = new ToggleButton(flyMenu.GetMenuName(), 1, 0, true, "Fly", "Toggle fly", delegate (bool state)
            {
                isFly = !isFly;
                Utils.GetLocalPlayer().gameObject.GetComponent<CharacterController>().enabled = !isFly;
                ModUtils.PureModLogger.Trace(isFly ? "Fly enabled" : "Fly Disabled");

                player = Utils.GetLocalPlayer().gameObject;
                playerCamera = Utils.GetLocalPlayerCamera();
            }, Color.magenta, Color.white);

            new SingleButton(flyMenu.GetMenuName(), 2, 0, true, "▲", "Speed Up", delegate ()
            {
                flySpeed++;

                speedResetButton.SetButtonText($"Speed [{flySpeed}]");
            });

            new SingleButton(flyMenu.GetMenuName(), 2, 1, true, "▼", "Speed Down", delegate ()
            {
                flySpeed--;

                if (flySpeed <= 0)
                    flySpeed = 1;
                speedResetButton.SetButtonText($"Speed [{flySpeed}]");
            });

            speedResetButton = new SingleButton(flyMenu.GetMenuName(), 1, 1, true, $"Speed [{flySpeed}]", "Reset fly Speed", delegate ()
            {
                flySpeed = 2;
                speedResetButton.SetButtonText($"Speed [{flySpeed}]");
            });
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.F))
                flyButton.Invoke();

            if (isFly)
            {
                if (Input.mouseScrollDelta.y != 0)
                {
                    flySpeed += (int)Input.mouseScrollDelta.y;

                    if (flySpeed <= 0)
                        flySpeed = 1;

                    speedResetButton.SetButtonText($"Speed [{flySpeed}]");
                }

                if (Input.GetKey(KeyCode.W))
                    player.transform.position += playerCamera.transform.forward * flySpeed * Time.deltaTime;
                if (Input.GetKey(KeyCode.A))
                    player.transform.position -= playerCamera.transform.right * flySpeed * Time.deltaTime;
                if (Input.GetKey(KeyCode.S))
                    player.transform.position -= playerCamera.transform.forward * flySpeed * Time.deltaTime;
                if (Input.GetKey(KeyCode.D))
                    player.transform.position += playerCamera.transform.right * flySpeed * Time.deltaTime;

                if (Input.GetKey(KeyCode.E))
                    player.transform.position += Vector3.up * flySpeed * Time.deltaTime;
                if (Input.GetKey(KeyCode.Q))
                    player.transform.position -= Vector3.up * flySpeed * Time.deltaTime;

                if (Math.Abs(Input.GetAxis("Joy1 Axis 2")) > 0f)
                    player.transform.position += playerCamera.transform.forward * flySpeed * Time.deltaTime * (Input.GetAxis("Joy1 Axis 2") * -1f);
                if (Math.Abs(Input.GetAxis("Joy1 Axis 1")) > 0f)
                    player.transform.position += playerCamera.transform.right * flySpeed * Time.deltaTime * Input.GetAxis("Joy1 Axis 1");
            }
        }
    }
}