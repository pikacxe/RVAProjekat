using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using log4net;

namespace RVAProject.AppServices.Helpers
{
    public static class Logger
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Logger));

        static Logger()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public static void Debug(string message)
        {
            log.Debug(message);
        }

        public static void Info(string message)
        {
            log.Info(message);
        }

        public static void Warn(string message)
        {
            log.Warn(message);
        }

        public static void Error(string message, Exception ex = null)
        {
            log.Error(message, ex);
        }

        public static void Fatal(string message, Exception ex = null)
        {
            log.Fatal(message, ex);
        }
    }
}