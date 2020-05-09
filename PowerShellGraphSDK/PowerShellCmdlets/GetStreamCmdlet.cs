

namespace BC.PowerShellGraphSDK.PowerShellCmdlets
{
    /// <summary>
    /// The common behavior between all OData PowerShell SDK cmdlets that retrieve data streams.
    /// </summary>
    public abstract class GetStreamCmdlet : ODataCmdletBase
    {
        internal override object ReadResponse(string content)
        {
            return content;
        }
    }
}
