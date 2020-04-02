using System;

namespace Common
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class MainFormAttribute : Attribute
    {
        public string Name;
    }
}
