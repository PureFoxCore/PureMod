using System;
using UnityEngine;
using PureModLoader.API;
using PureMod.Other;
using PureModLoader.API.UIAPI.QM;

namespace PureMod.Modules
{
    [Module]
    public class Fly
    {
        public int loadOrder = 1;
        public string moduleName = "Fly";

        public static int flySpeed = 2;
        public static bool isFly = false;

        private GameObject player;
        private GameObject playerCamera;

        private NestedButton flyMenu;
        private ToggleButton flyButton;
        private SingleButton speedResetButton;

        public void OnStart()
        {
            flyMenu = new NestedButton(QMmenu.mainMenuP1.MenuPath, 1, 0, true, "Fly", "Fly menu");

            flyButton = new ToggleButton(flyMenu.MenuPath, 1, 0, true, "Fly", "Toggle fly", delegate (bool state)
            {
                isFly = !isFly;
                Utils.LocalPlayer.gameObject.GetComponent<CharacterController>().enabled = !isFly;
                ModUtils.PureModLogger.Trace(isFly ? "Fly enabled" : "Fly Disabled");

                player = Utils.LocalPlayer.gameObject;
                playerCamera = Utils.LocalPlayerCamera;
            }, Color.magenta, Color.white);

            new SingleButton(flyMenu.MenuPath, 2, 0, true, "▲", "Speed Up", delegate ()
            {
                flySpeed++;

                speedResetButton.SetButtonText($"Speed [{flySpeed}]");
            });

            new SingleButton(flyMenu.MenuPath, 2, 1, true, "▼", "Speed Down", delegate ()
            {
                flySpeed--;

                if (flySpeed <= 0)
                    flySpeed = 1;
                speedResetButton.SetButtonText($"Speed [{flySpeed}]");
            });

            speedResetButton = new SingleButton(flyMenu.MenuPath, 1, 1, true, $"Speed [{flySpeed}]", "Reset fly Speed", delegate ()
            {
                flySpeed = 2;
                speedResetButton.SetButtonText($"Speed [{flySpeed}]");
            });
        }

        public void OnUpdate()
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