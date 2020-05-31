using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.PowerShellGraphSDK
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;

    public static class Logger
    {
        private const string Delimiter = "\t";

        private const string LogFilePrefix = "MSGraphSDKPowershell";

        private static readonly object InitializeLock = new object();

        private static bool isInitialized;

        private static TextWriter logStream;

        private static LogLevel currentLogLevel = LogLevel.Info;

        private static string logPath;

        internal static string LogDirectory(string filePath = null)
        {
            if (string.IsNullOrEmpty(logPath) || logPath != filePath)
            {
                if (!string.IsNullOrWhiteSpace(filePath))
                {
                    logPath = filePath;
                }
                else
                {
                    string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    logPath = string.Format(CultureInfo.InvariantCulture, "{0}\\BC\\MSGraphSDK\\Powershell", new object[1]
                    {
                        localAppData
                    });
                }
            }
            return logPath;
        }

        public static void Initialize(LogLevel logLevel, string filePath = null, int historyLength = 10)
        {
            if (!isInitialized || logLevel != currentLogLevel || logPath != filePath)
            {
                lock (InitializeLock)
                {
                    if (!isInitialized || logLevel != currentLogLevel || logPath != filePath)
                    {
                        ContinueInitialization(logLevel, historyLength, filePath);
                    }
                }
            }
        }

        public static void WriteError(CallerInformation callerInfo, string message, params object[] args)
        {
            WriteMessage(LogLevel.Error, (callerInfo != null) ? callerInfo.ToString() : string.Empty, message, args);
        }

        public static void WriteError(Exception exception, string methodName, string moduleName)
        {
            Write(exception, moduleName + "." + methodName);
        }

        public static void WriteWarning(string methodName, string message)
        {
            WriteMessage(LogLevel.Warning, methodName, message, string.Empty);
        }

        public static void WriteInfo(CallerInformation callerInfo, string message, params object[] args)
        {
            WriteMessage(LogLevel.Info, (callerInfo != null) ? callerInfo.ToString() : string.Empty, message, args);
        }

        public static void WriteInfo(string cmdletName, string methodName, string message, params object[] args)
        {
            WriteMessage(LogLevel.Info, cmdletName + "." + methodName, message, args);
        }

        public static void WriteInfo(string methodName, string message, params object[] args)
        {
            WriteMessage(LogLevel.Info, methodName, message, args);
        }

        private static void Write(Exception exception, string moduleName)
        {
            WriteMessage(LogLevel.Error, moduleName, "{0} - {1}. {2}", exception.GetType(), exception.Message, exception.StackTrace);
            if (exception.InnerException != null)
            {
                Write(exception.InnerException, "InnerException");
            }
        }

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "We don't want the logger to throw exceptions.")]
        private static void WriteMessage(LogLevel level, string caller, string message, params object[] args)
        {
            if (isInitialized)
            {
                if (caller == null)
                {
                    caller = string.Empty;
                }
                if (message == null)
                {
                    message = string.Empty;
                }
                try
                {
                    if (level >= currentLogLevel)
                    {
                        string prefix = string.Format(CultureInfo.InvariantCulture, "{0}{1}{2,-10}{3}{4,-40}{5}", DateTime.UtcNow.ToString("o"), "\t", level, "\t", caller, "\t");
                        logStream.WriteLine(prefix + message, args);
                        logStream.Flush();
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private static void ContinueInitialization(LogLevel logLevel, int historyLength, string filePath = null)
        {
            try
            {
                if (!Directory.Exists(LogDirectory(filePath)))
                {
                    Directory.CreateDirectory(LogDirectory(filePath));
                }
                DateTime now = DateTime.Now.ToLocalTime();
                string baseLogFileName = string.Format(CultureInfo.InvariantCulture, "{0}_{1}", new object[2]
                {
                    Path.Combine(LogDirectory(filePath), "MSGraphSDKPowershell"),
                    now.ToString("yyyyMMddHHmmss", DateTimeFormatInfo.InvariantInfo)
                });
                string logFileName = baseLogFileName;
                Random random = new Random();
                while (File.Exists(logFileName + ".log"))
                {
                    logFileName = string.Format(CultureInfo.InvariantCulture, "{0}_{1:D2}", new object[2]
                    {
                        baseLogFileName,
                        random.Next(0, 99)
                    });
                }
                logStream = TextWriter.Synchronized(new StreamWriter(logFileName + ".log", append: false));
                isInitialized = true;
            }
            catch (IOException)
            {
                isInitialized = false;
                return;
            }
            catch (UnauthorizedAccessException)
            {
                isInitialized = false;
                return;
            }
            currentLogLevel = logLevel;
            CleanupOldLogFiles(historyLength, filePath);
            WriteMessage(LogLevel.Info, "Logger.Initialize", "Logging initialized at level: {0}", currentLogLevel);
            WriteMessage(LogLevel.Info, "Logger.Initialize", "Logged in at: {0}", Environment.MachineName);
        }

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "We don't want the logger to throw exceptions.")]
        private static void CleanupOldLogFiles(int historyLength, string filePath)
        {
            DateTime oldestFileTimeToKeep = DateTime.Now.Subtract(new TimeSpan(historyLength, 0, 0, 0));
            try
            {
                string[] files = Directory.GetFiles(LogDirectory(filePath), "MSGraphSDKPowershell*.log", SearchOption.TopDirectoryOnly);
                foreach (string fileName in files)
                {
                    if (File.GetLastWriteTime(fileName).CompareTo(oldestFileTimeToKeep) < 0)
                    {
                        try
                        {
                            File.Delete(fileName);
                        }
                        catch (Exception e)
                        {
                            WriteMessage(LogLevel.Info, "CleanupOldLogFiles: Exception while deleting {0}", fileName);
                            WriteMessage(LogLevel.Error, "CleanupOldLogFiles: {0}", e.Message);
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
