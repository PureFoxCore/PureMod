using System;
using UnityEngine;
using PureMod.API;
using PureMod.API.Logger;

namespace PureMod.Addons
{
    public class Fly : ModSystem
    {
        public override int LoadOrder => 1;
        public override string ModName => "Fly";

        public static int flySpeed = 2;
        public static bool isFly = false;

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                isFly = !isFly;
                Utils.GetLocalPlayer().gameObject.GetComponent<CharacterController>().enabled = !isFly;
                Utils.CoreLogger.Log(isFly ? "Fly enabled" : "Fly Disabled", isFly ? LogLevel.Warn : LogLevel.Info);
            }

            if (isFly)
            {
                GameObject player = Utils.GetLocalPlayer().gameObject;
                GameObject playerCamera = Utils.GetLocalPlayerCamera();

                if (Input.mouseScrollDelta.y != 0)
                {
                    flySpeed += (int)Input.mouseScrollDelta.y;

                    if (flySpeed <= 0)
                        flySpeed = 1;
                    Utils.CoreLogger.Trace($"Speed: {flySpeed}");
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