
using System.Management.Automation;

namespace BC.PowerShellGraphSDK.PowerShellCmdlets
{
    /// <summary>
    /// 获取订阅
    /// </summary>
    [Cmdlet("Get", "AADSubscribedSku", DefaultParameterSetName = @"Search")]
    [ODataType("microsoft.graph.subscribedSku")]
    [ResourceTypePropertyName("subscribedSkuODataType")]
    public class GetSubscribedSku : GetOrSearchCmdlet
    {
        [Selectable]
        [Expandable]
        [IdParameter]
        [ResourceIdParameter]
        [ValidateNotNullOrEmpty]
        [Parameter(ParameterSetName = @"Get", Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"provide SkuID")]
        public System.String skuId { get; set; }

        internal override string GetResourcePath()
        {
            return $"subscribedSkus/{skuId ?? string.Empty}";
        }
    }
}
