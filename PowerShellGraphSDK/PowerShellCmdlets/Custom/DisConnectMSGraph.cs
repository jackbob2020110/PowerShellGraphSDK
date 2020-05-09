using System;
using System.Management.Automation;
namespace Microsoft.Intune.PowerShellGraphSDK.PowerShellCmdlets
{
    [Cmdlet(CmdletVerb, CmdletNoun,SupportsShouldProcess = true)]
    public class DisConnectMSGraph:PSCmdlet
    {
        /// <summary>
        /// Cmdlet name's verb.
        /// </summary>
        public const string CmdletVerb = VerbsCommunications.Disconnect;

        /// <summary>
        /// Cmdlet name's noun.
        /// </summary>
        public const string CmdletNoun = "MSGraph";

        protected override void ProcessRecord()
        {
            try
            {
                AuthUtils.ClearSessionState();
                //Logger.WriteInfo("Disconnect-MSGraph", "ProcessRecord", "User logged out PowerShell session.");
            }
            catch (Exception exception)
            {

                //while (exception != null)
                //{
                //    Logger.WriteError(exception, "ProcessRecord", "Disconnect-MSGraph");
                //    WriteError(new ErrorRecord(exception, "Disconnect-MSGraph", ErrorCategory.AuthenticationError, null));
                //    exception = exception.InnerException;
                //}
                throw;
            }
            
        }
    }
}
