

namespace BC.PowerShellGraphSDK
{
    using System;

    /// <summary>
    /// Indicates that the class represents a cmdlet that retrieves a resource that can be referenced in a "$ref" cmdlet.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    internal class ResourceReferenceAttribute : Attribute {}
}
