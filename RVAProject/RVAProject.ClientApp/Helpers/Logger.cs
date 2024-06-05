using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;

namespace RVAProject.ClientApp.Helpers
{
    public static class Logger
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Logger));
        public static List<string> messages=new List<string>();

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
            string formatedMessage = String.Format("{0} Info: {1}",DateTime.Now,message);
            messages.Add(formatedMessage);
            log.Info(message);
        }

        public static void Warn(string message)
        {
            messages.Add(message);
            log.Warn(message);
        }

        public static void Error(string message, Exception ex = null)
        {
            string formatedMessage = String.Format("{0} Error: {1}", DateTime.Now, message);
            messages.Add(formatedMessage);
            log.Error(message, ex);
        }

        public static void Fatal(string message, Exception ex = null)
        {
            messages.Add(message);
            log.Fatal(message, ex);
        }
    }
}
