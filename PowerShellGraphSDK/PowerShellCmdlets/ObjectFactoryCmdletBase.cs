﻿
namespace BC.PowerShellGraphSDK.PowerShellCmdlets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Reflection;
    using PowerShellGraphSDK;
    using PowerShellGraphSDK.PowerShellCmdlets.Utils;

    /// <summary>
    /// The common behavior between all cmdlets that are used to create PowerShell objects which represent entities in the OData schema.
    /// </summary>
    public abstract class ObjectFactoryCmdletBase : PSCmdlet
    {
        /// <summary>
        /// The method that the PowerShell runtime will call.  This is the entry point for the cmdlet.
        /// </summary>
        protected override void ProcessRecord()
        {
            try
            {
                // Try to run the cmdlet behavior
                this.Run();
            }
            catch (Exception ex)
            {
                // Write any errors to the console
                this.WriteError(ex);
            }
        }

        private void Run()
        {
            // Get the bound properties for this cmdlet
            IEnumerable<PropertyInfo> boundProperties = this.GetBoundProperties();

            // Iterate over each property
            IDictionary<string, object> resultProperties = new Dictionary<string, object>();
            foreach (PropertyInfo property in boundProperties)
            {
                // Check if this is an OData type selector switch property
                if (IsODataTypeSelectorSwitch(property, out string selectedODataType))
                {
                    // Make sure that we don't allow more than 1 parameter set selector to be applied by the user
                    if (resultProperties.ContainsKey(ODataConstants.RequestProperties.ODataType))
                    {
                        // Throw an error if we found more than 1 type selector property provided by the user (the PowerShell runtime should never allow this to happen)
                        IEnumerable<PropertyInfo> oDataTypeProperties = boundProperties.Where(prop => IsODataTypeSelectorSwitch(prop, out string temp));
                        throw new PSArgumentException($"Only one type selector switch may be applied at a time.  The following type selector switch parameters were applied: {string.Join(", ", oDataTypeProperties.Select(type => $"\"type\""))}");
                    }
                    else
                    {
                        // This is the first time we've seen an OData type selector switch property, so add an "@odata.type" property to the result object
                        resultProperties.Add(ODataConstants.RequestProperties.ODataType, selectedODataType);
                    }
                }
                else
                {
                    // Get the value of the property
                    object value = property.GetValue(this);

                    // TODO: Convert the property value into something that can be serialized as JSON
                    // This currently only satisfies the case where the property is a byte array - it does not satisfy other cases such as nested objects
                    if (value is byte[] bytes)
                    {
                        value = System.Convert.ToBase64String(bytes);
                    }

                    // Add the serializable value as a property in the result object
                    resultProperties.Add(property.Name, value);
                }
            }

            // If there is no "@odata.type" property, add one based on the ODataType attribute applied to this class
            if (!resultProperties.ContainsKey(ODataConstants.RequestProperties.ODataType))
            {
                string selectedODataType = this.GetType().GetCustomAttribute<ODataTypeAttribute>()?.TypeFullName;
                if (selectedODataType != null)
                {
                    resultProperties.Add(ODataConstants.RequestProperties.ODataType, "#" + selectedODataType);
                }
            }

            // Convert to a PowerShell object
            object result = resultProperties.ToPowerShellObject();

            // Send the object to the pipeline
            this.WriteObject(result);
        }

        /// <summary>
        /// Determines whether a given property is a parameter set switch which selects the OData type.
        /// </summary>
        /// <param name="property">The property</param>
        /// <param name="selectedParameterSet">The OData type that this switch would select</param>
        /// <returns>True if the given property is a OData type selector switch, otherwise false.</returns>
        private bool IsODataTypeSelectorSwitch(PropertyInfo property, out string selectedParameterSet)
        {
            return 
                // Prepend the type name with a "#" and set it as the result
                (selectedParameterSet = property.GetCustomAttribute<ParameterSetSelectorAttribute>()?.ParameterSetName?.Insert(0, "#")) != null &&
                // If this property has the ParameterSetSelector attribute, make sure it is also a SwitchParameter
                property.PropertyType == typeof(SwitchParameter);
        }
    }
}
