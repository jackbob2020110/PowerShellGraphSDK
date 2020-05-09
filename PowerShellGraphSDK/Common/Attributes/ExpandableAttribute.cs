

namespace BC.PowerShellGraphSDK
{
    using System;

    /// <summary>
    /// Indicates that this property is able to be included in the list of properties for the $expand
    /// query parameter when retrieving the entity from Graph.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    internal class ExpandableAttribute : Attribute { }
}
