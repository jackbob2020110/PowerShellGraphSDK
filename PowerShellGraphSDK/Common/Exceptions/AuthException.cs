

namespace BC.PowerShellGraphSDK
{
    using System;

    internal abstract class AuthException : Exception
    {
        internal AuthException(string message) : base(message)
        {
        }

        internal AuthException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
