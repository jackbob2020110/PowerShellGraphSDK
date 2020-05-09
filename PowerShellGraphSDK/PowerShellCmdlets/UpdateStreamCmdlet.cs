

namespace BC.PowerShellGraphSDK.PowerShellCmdlets
{
    using System.Management.Automation;

    /// <summary>
    /// The common behavior between all OData PowerShell SDK cmdlets that update a stream.
    /// </summary>
    public abstract class UpdateStreamCmdlet : ODataCmdletBase
    {
        /// <summary>
        /// <para type="description">The new data.</para>
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Data { get; set; }

        /// <summary>
        /// <para type="description">The MIME type (content type) of the data. See https://technet.microsoft.com/en-us/library/cc995276.aspx for a list of MIME types.</para>
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string ContentType { get; set; }

        internal override string GetHttpMethod()
        {
            return "PUT";
        }

        internal override object GetContent()
        {
            return this.Data;
        }

        internal override string GetContentType()
        {
            return this.ContentType;
        }
    }
}
