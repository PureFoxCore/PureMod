namespace PureMod.API
{
    /// <summary>
    /// Virtual mod system base (use for creating mods :D)
    /// </summary>
    public class ModuleBase
    {
        /// <summary>
        /// Load order for mod (by default 0)
        /// </summary>
        public virtual int LoadOrder => 0;
        /// <summary>
        /// Show mod name in console when loading
        /// </summary>
        public virtual bool ShowName => true;
        /// <summary>
        /// Mod name (shows in console when loading current mod)
        /// </summary>
        public virtual string ModuleName => "Default Mod";
        /// <summary>
        /// Calls when application starts
        /// </summary>
        public virtual void OnEarlierStart() { }
        /// <summary>
        /// Calls when VRChat UI initialize (setup buttons and menu stuff here)
        /// </summary>
        public virtual void OnStart() { }
        /// <summary>
        /// Calls every frame
        /// </summary>
        public virtual void OnUpdate() { }
        /// <summary>
        /// Calls every 0.02 seconds
        /// </summary>
        public virtual void OnFixedUpdate() { }
        /// <summary>
        /// Calls after OnUpdate function
        /// </summary>
        public virtual void OnLateUpdate() { }
        /// <summary>
        /// Use this method to draw ImGUI (on screen stuff)
        /// </summary>
        public virtual void OnGUI() { }
        /// <summary>
        /// Calls when player exits VRChat
        /// </summary>
        public virtual void OnQuit() { }
        /// <summary>
        /// Calls every 10 seconds
        /// </summary>
        public virtual void OnUpdate10() { }
        /// <summary>
        /// Calls when player joins room
        /// </summary>
        /// <param name="player">VRCPlayer witch you can modify</param>
        public virtual void OnPlayerJoin(VRC.Player player) { }
        /// <summary>
        /// Calls when player leaves room
        /// </summary>
        /// <param name="player">VRCPlayer witch you can modify</param>
        public virtual void OnPlayerLeave(VRC.Player player) { }
    }
}