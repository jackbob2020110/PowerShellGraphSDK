

namespace BC.PowerShellGraphSDK
{
    using System;

    /// <summary>
    /// Specifies the name of the property whose value can be used as an input to type cast parameters.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    internal class ResourceTypePropertyNameAttribute : Attribute
    {
        internal string ResourceTypePropertyName { get; }

        internal ResourceTypePropertyNameAttribute(string propertyName)
        {
            if (propertyName == null)
            {
                throw new ArgumentNullException(nameof(propertyName));
            }
            if (string.IsNullOrWhiteSpace(propertyName))
            {
                throw new ArgumentException("Resource type property name cannot be empty or whitespace");
            }

            this.ResourceTypePropertyName = propertyName;
        }
    }
}
