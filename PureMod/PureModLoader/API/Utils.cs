using VRC;
using VRC.Core;
using UnityEngine;
using VRC.SDKBase;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace PureModLoader.API
{
    /// <summary>
    /// Some utils to code easier :3
    /// </summary>
    public class Utils
    {
        /// <summary>
        /// Quick menu is "ESC" menu in VRChat
        /// </summary>
        /// <returns>QuickMenu in front of player</returns>
        public static QuickMenu GetQuickMenu() =>
            GameObject.Find("UserInterface/QuickMenu").GetComponent<QuickMenu>();

        /// <summary>
        /// Gets selected player when "ESC" menu is open
        /// </summary>
        /// <returns>Selected player in "ESC" menu</returns>
        public static Player GetSelectedPlayer() =>
            GetQuickMenu().field_Private_Player_0;

        /// <summary>
        /// Gets all game objects in scene (only base objects not in children)
        /// </summary>
        /// <returns>Main game objects</returns>
        public static GameObject[] GetAllGameObjects()=>
            SceneManager.GetActiveScene().GetRootGameObjects();

        /// <summary>
        /// Gets all game objects (with children)
        /// </summary>
        /// <returns>all game objects (with children)</returns>
        public static List<GameObject> GetAllObjectsInSceneTree() =>
            Resources.FindObjectsOfTypeAll<GameObject>().ToList();

        /// <summary>
        /// Gets from api player count
        /// </summary>
        /// <returns>Player count in active world [for loops]</returns>
        public static int GetPlayerCount() =>
            VRCPlayerApi.GetPlayerCount();

        /// <summary>
        /// Main character (witch you control)
        /// </summary>
        /// <returns>Local player</returns>
        public static VRCPlayerApi GetLocalPlayer() =>
            Networking.LocalPlayer;

        /// <summary>
        /// Gets player from photon ID
        /// </summary>
        /// <param name="ID">photon ID</param>
        /// <returns>VRCPlayerApi</returns>
        public static VRCPlayerApi GetVRCPlayerApiByID(int ID) =>
            VRCPlayerApi.GetPlayerById(ID);

        /// <summary>
        /// Player manager is VRChat default manager witch u can select player and manipulate them (or get info :3)
        /// </summary>
        /// <returns>VRChat PlayerManager</returns>
        public static PlayerManager GetPlayerManager() =>
            GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        
        /// <summary>
        /// Gets from player manager all players
        /// </summary>
        /// <returns>List of [Player]</returns>
        public static Il2CppSystem.Collections.Generic.List<Player> GetPlayers() =>
            GetPlayerManager().field_Private_List_1_Player_0;

        /// <summary>
        /// Gets from player manager all APIUsers (to interact with VRChat user API)
        /// </summary>
        /// <returns>List of [APIUser]</returns>
        public static Il2CppSystem.Collections.Generic.List<APIUser> GetAPIUsers()
        {
            var list = new Il2CppSystem.Collections.Generic.List<APIUser>();

            foreach (var player in GetPlayers())
                list.Add(player.prop_APIUser_0);

            return list;
        }

        /// <summary>
        /// Selects player from "ESC" menu [NOT WORKING CORRECTLY, I'LL FIX THAT]
        /// </summary>
        /// <param name="player">Player to select</param>
        public static void QMSelectPlayer(Player player) =>
            GetQuickMenu().Method_Public_Void_Player_0(player);

        /// <summary>
        /// Gets player local camera (eye)
        /// </summary>
        /// <returns>GameObject witch contains camera component</returns>
        public static GameObject GetLocalPlayerCamera() =>
            GameObject.Find("Camera (eye)");

        /// <summary>
        /// Gets all players from VRChat player APIs
        /// </summary>
        /// <returns>List of all player [VRCPlayerApi]</returns>
        public static Il2CppSystem.Collections.Generic.List<VRCPlayerApi> GetPlayerAPIs() =>
            VRCPlayerApi.AllPlayers;
    }
}
