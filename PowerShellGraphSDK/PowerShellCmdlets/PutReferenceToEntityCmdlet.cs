

namespace BC.PowerShellGraphSDK.PowerShellCmdlets
{
    /// <summary>
    /// The common behavior between all OData PowerShell SDK cmdlets that create references from an OData resource to a single entity.
    /// </summary>
    public abstract class PutReferenceToEntityCmdlet : ODataCmdletBase
    {
        internal override string GetHttpMethod()
        {
            return "PUT";
        }
    }
}
