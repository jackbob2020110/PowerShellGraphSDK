

namespace BC.PowerShellGraphSDK
{
    using System;

    /// <summary>
    /// Indicates that the given property is used to specify a type cast in the URL.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    internal class TypeCastParameterAttribute : Attribute
    {
    }
}
