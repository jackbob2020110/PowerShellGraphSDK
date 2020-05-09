

namespace BC.PowerShellGraphSDK
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Indicates that the parameter or cmdlet was generated from an OData property of the given type.
    /// </summary>
    [AttributeUsage(
        AttributeTargets.Property | AttributeTargets.Class,
        AllowMultiple = false,
        Inherited = true)]
    internal class ODataTypeAttribute : Attribute
    {
        /// <summary>
        /// The name of the OData type.
        /// </summary>
        internal string TypeFullName { get; }

        /// <summary>
        /// The names of all the subtypes of the given type.
        /// </summary>
        internal IEnumerable<string> SubTypeFullNames { get; }

        /// <summary>
        /// Creates a new <see cref="ODataTypeAttribute"/>.
        /// </summary>
        /// <param name="oDataTypeFullName">The name of the OData type.</param>
        /// <param name="oDataSubTypeFullNames">The names of all the subtypes of the given type.</param>
        internal ODataTypeAttribute(string oDataTypeFullName, params string[] oDataSubTypeFullNames)
        {
            this.TypeFullName = oDataTypeFullName ?? throw new ArgumentNullException(nameof(oDataTypeFullName));
            this.SubTypeFullNames = oDataSubTypeFullNames != null
                ? new HashSet<string>(oDataSubTypeFullNames) as IEnumerable<string>
                //: Array.Empty<string>(); for .net 4.7
                : Enumerable.Empty<string>().ToArray();
        }
    }
}
