using Serilog;

namespace ShellApp.Constants
{
    public static class LoggerManager
    {
        public static void Create(string fileName)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File(fileName, rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        public static void Debug(string message)
        {
            Log.Debug(message);
        }

        public static void Info(string message)
        {
            Log.Information(message);
        }

        public static void Error(string message)
        {
            Log.Error(message);
        }

        public static void Warn(string message)
        {
            Log.Warning(message);
        }

        public static void Fatal(string message)
        {
            Log.Fatal(message);
        }
    }
}
