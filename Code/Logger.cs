namespace HouseApp.Code
{
    public static class Logger
    {
        public static log4net.ILog FileLogger = log4net.LogManager.GetLogger("FileLogger");
        public static log4net.ILog RollingFileLogger = log4net.LogManager.GetLogger("RollingLogFileAppender");
        public static log4net.ILog ConsoleLogger = log4net.LogManager.GetLogger("ConsoleLogger");
        public static log4net.ILog ColorConsoleLogger = log4net.LogManager.GetLogger("ColorConsoleLogger");
        public static log4net.ILog OutputDebugStringLogger = log4net.LogManager.GetLogger("OutputDebugStringAppender");
        public static log4net.ILog MailLogger = log4net.LogManager.GetLogger("eMailLogger");
    }
}
