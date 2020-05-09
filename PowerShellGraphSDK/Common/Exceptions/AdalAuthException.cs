

namespace BC.PowerShellGraphSDK
{
    using Microsoft.IdentityModel.Clients.ActiveDirectory;

    internal class AdalAuthException : AuthException
    {
        internal AdalAuthException(string message, AdalException innerException) : base(message, innerException)
        {
        }
    }
}
