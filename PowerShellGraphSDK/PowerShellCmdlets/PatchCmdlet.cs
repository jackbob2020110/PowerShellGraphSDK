

namespace BC.PowerShellGraphSDK.PowerShellCmdlets
{
    /// <summary>
    /// The common behavior between all OData PowerShell SDK cmdlets that update OData resources.
    /// </summary>
    public abstract class PatchCmdlet : PostOrPatchCmdlet
    {
        internal override string GetHttpMethod()
        {
            return "PATCH";
        }
    }
}
