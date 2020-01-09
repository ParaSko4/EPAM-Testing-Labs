using log4net.Config;
using log4net;
using System;
using System.IO;

namespace Framework.Logging
{
    public class Logger
    {
        private static ILog log = LogManager.GetLogger("logger");

        public static ILog Log
        {
            get { return log; }
        }

        public static void InitLogger()
        {
            int separateIndex = AppDomain.CurrentDomain.BaseDirectory.IndexOf("bin", StringComparison.Ordinal);
            string logConfigPath = AppDomain.CurrentDomain.BaseDirectory.Substring(0, separateIndex) + "Config\\log4net.config";
            XmlConfigurator.Configure(new FileInfo(logConfigPath));
        }
    }
}