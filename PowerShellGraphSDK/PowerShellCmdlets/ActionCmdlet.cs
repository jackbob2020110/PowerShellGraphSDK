﻿

namespace BC.PowerShellGraphSDK.PowerShellCmdlets
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Reflection;

    /// <summary>
    /// The common behavior between all OData PowerShell SDK cmdlets that call actions on OData resources.
    /// </summary>
    public abstract class ActionCmdlet : ODataCmdletBase
    {
        internal override string GetHttpMethod()
        {
            return "POST";
        }

        internal override object GetContent()
        {
            // Get the properties that were set by the user in this invocation of the PowerShell cmdlet
            IEnumerable<PropertyInfo> boundProperties = this.GetBoundProperties(includeInherited: false)
                // Make sure all the properties have an [ODataType] attribute
                .Where(prop => prop.GetCustomAttribute<ODataTypeAttribute>() != null);

            // Create the JSON string
            string jsonBody = this.WriteJsonFromProperties(boundProperties);

            return jsonBody;
        }

        internal override HttpContent WriteContent(object content)
        {
            // This should already be a serialized JSON string (provided by the GetContent() method)

            return content is string stringContent ? new StringContent(stringContent) : null;
        }
    }
}
