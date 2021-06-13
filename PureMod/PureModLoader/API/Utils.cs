using VRC;
using System;
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
        /// Modules directory where you can save your module or read other one
        /// </summary>
        public static string ModulesDirectory { get => $"{Environment.CurrentDirectory}\\PureMod\\Modules"; }

        /// <summary>
        /// Modules directory where you can save your confuguration file or read other one
        /// </summary>
        public static string ConfigsDirectory { get => $"{Environment.CurrentDirectory}\\PureMod\\Configs"; }

        /// <summary>
        /// Quick menu is "ESC" menu in VRChat
        /// </summary>
        /// <returns>QuickMenu in front of player</returns>
        public static QuickMenu QuickMenuInstance { get => GameObject.Find("UserInterface/QuickMenu").GetComponent<QuickMenu>(); }

        /// <summary>
        /// Gets selected player when "ESC" menu is open
        /// </summary>
        /// <returns>Selected player in "ESC" menu</returns>
        public static Player SelectedPlayer { get => QuickMenuInstance.field_Private_Player_0; }

        /// <summary>
        /// Gets all game objects in scene (only base objects not in children)
        /// </summary>
        /// <returns>Main game objects</returns>
        public static GameObject[] AllGameObjects { get => SceneManager.GetActiveScene().GetRootGameObjects(); }

        /// <summary>
        /// Gets all game objects (with children)
        /// </summary>
        /// <returns>all game objects (with children)</returns>
        public static List<GameObject> AllObjectsInSceneTree { get => Resources.FindObjectsOfTypeAll<GameObject>().ToList(); }

        /// <summary>
        /// Gets from api player count
        /// </summary>
        /// <returns>Player count in active world [for loops]</returns>
        public static int PlayerCount { get => VRCPlayerApi.GetPlayerCount(); }

        /// <summary>
        /// Main character (witch you control)
        /// </summary>
        /// <returns>Local player</returns>
        public static VRCPlayer LocalPlayer { get => VRCPlayer.field_Internal_Static_VRCPlayer_0; }

        /// <summary>
        /// Gets player from photon ID
        /// </summary>
        /// <param name="ID">photon ID</param>
        /// <returns>VRCPlayerApi</returns>
        public static VRCPlayerApi GetVRCPlayerApiByID(int ID) => VRCPlayerApi.GetPlayerById(ID);

        /// <summary>
        /// Player manager is VRChat default manager witch u can select player and manipulate them (or get info :3)
        /// </summary>
        /// <returns>VRChat PlayerManager</returns>
        public static PlayerManager PlayerManager { get => GameObject.Find("PlayerManager").GetComponent<PlayerManager>(); }

        /// <summary>
        /// Gets from player manager all players
        /// </summary>
        /// <returns>List of [Player]</returns> 
        public static List<Player> Players { get => PlayerManager.field_Private_List_1_Player_0.ToArray().ToList(); }

        /// <summary>
        /// Gets from player manager all APIUsers (to interact with VRChat user API)
        /// </summary>
        /// <returns>List of [APIUser]</returns>
        public static List<APIUser> APIUsers { get => Players.ToArray().Select(player => player.prop_APIUser_0).ToList(); }

        /// <summary>
        /// Selects player from "ESC" menu
        /// </summary>
        /// <param name="player">Player to select</param>
        public static void QMSelectPlayer(Player player)
        {
            UIAPI.QM.QMStuff.ShowQuickmenuPage(""); // DUMB ASS FIX
            QuickMenuInstance.Method_Public_Void_Player_PDM_0(player);
        }

        /// <summary>
        /// Get ping from player
        /// </summary>
        /// <param name="player">VRC.Player player</param>
        /// <returns>int ping of pleyer</returns>
        public static int GetPlayerPing(Player player) => player.prop_Int32_0;

        /// <summary>
        /// Get ping from player
        /// </summary>
        /// <param name="player">VRCPlayer player</param>
        /// <returns>int ping of pleyer</returns>
        public static int GetPlayerPing(VRCPlayer player) => player.prop_Int32_1;

        /// <summary>
        /// Gets player local camera (eye)
        /// </summary>
        /// <returns>GameObject witch contains camera component</returns>
        public static GameObject LocalPlayerCamera { get => GameObject.Find("Camera (eye)"); }

        /// <summary>
        /// Gets all players from VRChat player APIs
        /// </summary>
        /// <returns>List of all player [VRCPlayerApi]</returns>
        public static List<VRCPlayerApi> PlayerAPIs { get => VRCPlayerApi.AllPlayers.ToArray().ToList(); }
    }
}
