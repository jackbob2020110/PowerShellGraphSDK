

namespace BC.PowerShellGraphSDK
{
    using System;

    /// <summary>
    /// Indicates that this property is able to be included in the list of properties for the $select
    /// query parameter when retrieving the entity from Graph.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    internal class SelectableAttribute : Attribute { }
}
