using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;


namespace BC.PowerShellGraphSDK.PowerShellCmdlets
{
    /// <summary>
    /// 
    /// </summary>
    [Cmdlet("Get", "Users", DefaultParameterSetName = @"Search")]
    public class Get_Users : GetOrSearchCmdlet
    {
        /// <summary>
        /// 
        /// </summary>
        [ValidateNotNullOrEmpty]
        [Parameter(ParameterSetName = @"Get", Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The ID for a &quot;microsoft.graph.group&quot; object in the &quot;groups&quot; collection.")]
        public System.String UserId { get; set; }


        internal override System.String GetResourcePath()
        {
            return $"users/{UserId ?? string.Empty}";
        }
    }
}
