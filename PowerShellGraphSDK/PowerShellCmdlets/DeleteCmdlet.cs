

namespace BC.PowerShellGraphSDK.PowerShellCmdlets
{
    /// <summary>
    /// The common behavior between all OData PowerShell SDK cmdlets that remove OData resources.
    /// </summary>
    public abstract class DeleteCmdlet : ODataCmdletBase
    {
        internal override string GetHttpMethod()
        {
            return "DELETE";
        }
    }
}
