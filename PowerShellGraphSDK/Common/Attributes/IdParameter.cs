

namespace BC.PowerShellGraphSDK
{
    using System;

    /// <summary>
    /// Indicates that the given property is used to specify an ID in the URL.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    internal class IdParameterAttribute : Attribute
    {
    }
}
