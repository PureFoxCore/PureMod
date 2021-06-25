using System;

namespace PureModLoader.API
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public class ModuleAttribute : Attribute { }
}
