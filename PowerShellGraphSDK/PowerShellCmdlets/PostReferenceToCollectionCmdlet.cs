

namespace BC.PowerShellGraphSDK.PowerShellCmdlets
{
    /// <summary>
    /// The common behavior between all OData PowerShell SDK cmdlets that create references from an OData resource to a collection.
    /// </summary>
    public abstract class PostReferenceToCollectionCmdlet : ODataCmdletBase
    {
        internal override string GetHttpMethod()
        {
            return "POST";
        }
    }
}
