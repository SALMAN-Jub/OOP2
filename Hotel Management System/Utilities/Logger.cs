using System;
using System.IO;

namespace Hotel_Management_System.Utilities
{
    public static class Logger
    {
        private static readonly string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");

        public static void Log(string message)
        {
            try
            {
                if (!Directory.Exists(logPath)) Directory.CreateDirectory(logPath);
                var file = Path.Combine(logPath, "application.log");
                var line = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";
                File.AppendAllLines(file, new[] { line });
            }
            catch
            {
                // swallow logging errors
            }
        }

        public static void LogError(string message, Exception ex)
        {
            Log(message + " - " + ex.ToString());
        }
    }
}
