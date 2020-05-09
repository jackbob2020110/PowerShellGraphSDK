

namespace BC.PowerShellGraphSDK
{
    using System;

    /// <summary>
    /// Indicates that the given property is used to specify an entity's main ID in the URL.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    internal class ResourceIdParameterAttribute : Attribute
    {
    }
}
