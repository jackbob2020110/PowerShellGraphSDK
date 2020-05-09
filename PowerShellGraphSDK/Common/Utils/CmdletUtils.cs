﻿

namespace BC.PowerShellGraphSDK
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Reflection;

    internal static class CmdletUtils
    {
        /// <summary>
        /// Gets the noun part of a cmdlet's name.
        /// </summary>
        /// <param name="cmdlet">The cmdlet</param>
        /// <returns>The noun part of the cmdlet's name</returns>
        internal static string GetCmdletNoun(this Cmdlet cmdlet)
        {
            if (cmdlet == null)
            {
                throw new ArgumentNullException(nameof(cmdlet));
            }

            return cmdlet.GetType().GetCustomAttribute<CmdletAttribute>()?.NounName;
        }

        /// <summary>
        /// Gets the properties that are bound (set by the user) in the current invocation of this cmdlet.
        /// </summary>
        /// <param name="cmdlet">The cmdlet to get the properties from</param>
        /// <param name="includeInherited">Whether or not to include inherited properties</param>
        /// <returns>The properties that are bound in the current invocation of this cmdlet.</returns>
        internal static IEnumerable<PropertyInfo> GetBoundProperties(this PSCmdlet cmdlet, bool includeInherited = true)
        {
            // Get the cmdlet's properties
            IEnumerable<PropertyInfo> cmdletProperties = cmdlet.GetProperties(includeInherited);

            // Get only the properties that were set from PowerShell
            IEnumerable<string> boundParameterNames = cmdlet.MyInvocation.BoundParameters.Keys;
            IEnumerable<PropertyInfo> boundProperties = cmdletProperties.Where(prop =>
                boundParameterNames.Contains(prop.Name) ||
                prop.GetCustomAttribute<AliasAttribute>()?.AliasNames?.Intersect(boundParameterNames)?.Any() == true);

            return boundProperties;
        }

        /// <summary>
        /// Gets all the properties declared on this class.
        /// </summary>
        /// <param name="cmdlet">The cmdlet to get the properties from</param>
        /// <param name="includeInherited">Whether or not to include inherited properties (defaults to true)</param>
        /// <returns>The properties that are defined on this cmdlet.</returns>
        internal static IEnumerable<PropertyInfo> GetProperties(this PSCmdlet cmdlet, bool includeInherited)
        {
            // Create the binding flags
            BindingFlags bindingFlags =
                BindingFlags.Instance | // ignore static/const properties
                BindingFlags.Public; // only include public properties
            if (!includeInherited)
            {
                bindingFlags |= BindingFlags.DeclaredOnly; // ignore inherited properties
            }

            // Get the properties on this cmdlet
            IEnumerable<PropertyInfo> result = cmdlet.GetType().GetProperties(bindingFlags);

            return result;
        }
    }
}
