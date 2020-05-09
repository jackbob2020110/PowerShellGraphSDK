

namespace BC.PowerShellGraphSDK
{
    using System;

    internal class MsiAuthException : AuthException
    {
        internal MsiAuthException(string message) : base(message)
        {
        }

        internal MsiAuthException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
