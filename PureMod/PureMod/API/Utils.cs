using VRC;
using VRC.Core;
using UnityEngine;
using VRC.SDKBase;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace PureMod.API
{
    public class Utils
    {
        public static Logger.Logger CoreLogger = new Logger.Logger("PureMod", Logger.LogLevel.Trace);

        public static GameObject[] GetAllGameObjects()
        {
            return SceneManager.GetActiveScene().GetRootGameObjects();
        }

        public static List<GameObject> GetAllObjectsInSceneTree()
        {
            List<GameObject> objectsInScene = new List<GameObject>();

            foreach (GameObject go in Resources.FindObjectsOfTypeAll<GameObject>())
                objectsInScene.Add(go);

            return objectsInScene;
        }

        public static VRCPlayerApi GetLocalPlayer()
        {
            int ID = 0;

            foreach (var player in VRCPlayerApi.AllPlayers)
                if (player.isLocal)
                    ID = player.playerId;

            return VRCPlayerApi.GetPlayerById(ID);
        }

        public static PlayerManager GetPlayerManager()
        {
            return GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        }

        public static Il2CppSystem.Collections.Generic.List<Player> GetPlayers()
        {
            return GetPlayerManager().field_Private_List_1_Player_0;
        }

        public static Il2CppSystem.Collections.Generic.List<APIUser> GetAPIUsers()
        {
            var list = new Il2CppSystem.Collections.Generic.List<APIUser>();

            foreach (var player in GetPlayers())
                list.Add(player.prop_APIUser_0);

            return list;
        }

        public static GameObject GetLocalPlayerCamera()
        {
            return GameObject.Find("Camera (eye)"); // Success
        }

        public static Il2CppSystem.Collections.Generic.List<VRCPlayerApi> GetPlayerAPIs()
        {
            return VRCPlayerApi.AllPlayers;
        }
    }
}
