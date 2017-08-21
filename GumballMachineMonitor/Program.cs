using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GumballMachineMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            var gumballClient = new GumballMachine.GumballMachineClient();

            Console.WriteLine("Gumball machine location: {0}", gumballClient.getLocation());
            Console.WriteLine("Gumball machine count: {0}", gumballClient.getCount());
            Console.WriteLine("Gumball machine state: {0}", gumballClient.getState().StateName);

            Console.ReadKey();
        }
    }
}
