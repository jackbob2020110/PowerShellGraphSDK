
using System.Management.Automation;

namespace BC.PowerShellGraphSDK.PowerShellCmdlets
{
    /// <summary>
    /// 获取登录的租户信息
    /// </summary>
    [Cmdlet("Get", "AADTenantDetail", DefaultParameterSetName = @"Search")]
    [ODataType("microsoft.graph.organization")]
    [ResourceTypePropertyName("organizationODataType")]
    public class GetTenantDetails : GetOrSearchCmdlet
    {
      
        internal override string GetResourcePath()
        {
            return $"organization";
        }
    }
}
