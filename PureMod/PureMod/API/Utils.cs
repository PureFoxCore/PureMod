using UnityEngine;
using VRC.SDKBase;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace PureMod.API
{
    public class Utils
    {
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

        //public static Player GetSelectedPlayerOrNull()
        //{
        //    Player Foundplayer = null;

        //    foreach (GameObject playerObject in GetAllPlayers())
        //        if (playerObject.GetComponent<Player>().field_Private_APIUser_0.id == GameObject.Find("/UserInterface/QuickMenu/ShortcutMenu").transform.parent.GetComponent<QuickMenu>().field_Private_APIUser_0.id)
        //            Foundplayer = playerObject.GetComponent<Player>();

        //    return Foundplayer;
        //}

        public static GameObject GetLocalPlayerCamera()
        {
            return GameObject.Find("Camera (eye)"); // Success
        }

        public static Il2CppSystem.Collections.Generic.List<VRCPlayerApi> GetPlayers()
        {
            return VRCPlayerApi.AllPlayers;
        }
    }
}
