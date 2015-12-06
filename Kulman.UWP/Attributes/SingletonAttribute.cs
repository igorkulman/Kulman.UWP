using System;

namespace Kulman.UWP.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class SingletonAttribute : Attribute
    {
    }
}
