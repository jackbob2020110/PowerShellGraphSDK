using System.Runtime.CompilerServices;

namespace BC.PowerShellGraphSDK
{
    public class CallerInformation
    {
        private string memberName;

        private string filePath;

        private int lineNumber;

        public CallerInformation([CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            this.memberName = memberName;
            filePath = sourceFilePath;
            lineNumber = sourceLineNumber;
        }

        public override string ToString()
        {
            return $"{memberName}, {filePath}#{lineNumber}";
        }
    }
}
