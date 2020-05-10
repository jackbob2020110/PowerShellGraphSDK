using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;

namespace BC.PowerShellGraphSDK.PowerShellCmdlets
{
    /// <summary>
    ///  获取组织信息
    /// </summary>
    [Cmdlet("Get", "Organization", DefaultParameterSetName = @"Search")]
    [ODataType("microsoft.graph.organization")]
    [ResourceTypePropertyName("organizationODataType")]
    public class Get_Organization : GetOrSearchCmdlet
    {


        /// <summary>
        /// 
        /// </summary>
        [ValidateNotNullOrEmpty]
        [Parameter(ParameterSetName = @"Get", Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The ID for a &quot;microsoft.graph.organization&quot; object in the &quot;organization&quot; collection.")]
        public System.String organizationId { get; set; }

        internal override System.String GetResourcePath()
        {
            return $"organization/{organizationId ?? string.Empty}";
        }
    }

 
}
