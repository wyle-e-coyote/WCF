using State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GumballMachineHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var baseAddress = new Uri("http://localhost:8000/GumballMachine");

            var selfHost = new ServiceHost(typeof(GumballMachine), baseAddress);

            try
            {
                selfHost.AddServiceEndpoint(typeof(IGumballMachineRemote), new WSHttpBinding(), "Remote");

                var smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smb);

                selfHost.Open();
                Console.WriteLine("The service is ready and running on the following addresses:");
                foreach (var address in selfHost.BaseAddresses)
                {
                    Console.WriteLine("\t{0}", address.AbsoluteUri);
                }
                RunTest();
                Console.WriteLine("Press <enter> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                selfHost.Close();
            }
            catch (CommunicationException e)
            {
                Console.WriteLine("An exception occurred: {0}", e.Message);
                selfHost.Abort();
            }
        }

        static void RunTest()
        {
            var gumballMachine = new GumballMachine();

            while (gumballMachine.getCount() > 0)
            {
                gumballMachine.insertQuarter();
                gumballMachine.turnCrank();
                Thread.Sleep(1000);
            }
        }
    }
}
