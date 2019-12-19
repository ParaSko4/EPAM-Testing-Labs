using log4net.Config;
using log4net;

namespace Framework.Logging
{
    public class Logger
    {
        private static ILog log = LogManager.GetLogger("LOGGER");

        public static ILog Log
        {
            get { return log; }
        }

        public static void InitLogger()
        {
            XmlConfigurator.Configure();
        }
    }
}
