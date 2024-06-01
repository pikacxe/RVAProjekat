using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace RVAProject.ServiceApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost serviceHost = new ServiceHost(typeof(LibraryServiceImpl)))
            {
                ILog logger = LogManager.GetLogger(typeof(LibraryServiceImpl));
                BasicConfigurator.Configure();
                serviceHost.Open();
                logger.Info("===========================Service started======================================");
                Console.WriteLine("Starting service....");
                Console.WriteLine("Service started...\nPress any key to exit");
                Console.ReadLine();
                serviceHost.Close();
            }
        }
    }
}
