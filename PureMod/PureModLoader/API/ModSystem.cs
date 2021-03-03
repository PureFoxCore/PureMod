namespace PureMod.API
{
    public class ModSystem
    {
        public virtual int LoadOrder => 0;
        public virtual bool ShowName => true;
        public virtual string ModName => "Default Mod";
        public virtual void OnEarlierStart() { }
        public virtual void OnStart() { }
        public virtual void OnUpdate() { }
        public virtual void OnFixedUpdate() { }
        public virtual void OnLateUpdate() { }
        public virtual void OnGUI() { }
        public virtual void OnQuit() { }
        public virtual void OnUpdate10() { }
    }
}