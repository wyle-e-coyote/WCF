using System;
using System.Text;

namespace State
{
    public class GumballMachine : IGumballMachineRemote
    {
        IState soldOutState;
        IState noQuarterState;
        IState hasQuarterState;
        IState soldState;
        IState winnerState;

        static IState state;
        static int count = 0;
        static string location;

        public GumballMachine()
        {
            soldOutState = new SoldOutState(this);
            noQuarterState = new NoQuarterState(this);
            hasQuarterState = new HasQuarterState(this);
            soldState = new SoldState(this);
            winnerState = new WinnerState(this);

            if (GumballMachine.count == 0)
            {
                GumballMachine.count = 100;
                GumballMachine.state = noQuarterState;
                GumballMachine.location = "Raleigh";
            }
        }

        public void insertQuarter()
        {
            state.insertQuarter();
        }

        public void ejectQuarter()
        {
            state.ejectQuarter();
        }

        public void turnCrank()
        {
            state.turnCrank();
            state.dispense();
        }

        public void releaseBall()
        {
            if (count != 0)
            {
                Console.WriteLine("A gumball comes rolling out the slot...");
                count--;
            }
        }

        internal void setState(IState state)
        {
            GumballMachine.state = state;
        }

        public IState getState()
        {
            Console.WriteLine("getState: {0}", GumballMachine.state);
            return GumballMachine.state;
        }

        internal IState getHasQuarterState()
        {
            return this.hasQuarterState;
        }

        internal IState getSoldOutState()
        {
            return this.soldOutState;
        }

        internal IState getNoQuarterState()
        {
            return this.noQuarterState;
        }

        internal IState getSoldState()
        {
            return this.soldState;
        }

        internal IState getWinnerState()
        {
            return this.winnerState;
        }

        public int getCount()
        {
            Console.WriteLine("getCount: {0}", GumballMachine.count);
            return GumballMachine.count;
        }

        public string getLocation()
        {
            Console.WriteLine("getLocation: {0}", GumballMachine.location);
            return GumballMachine.location;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine("Gumball Machine 9000 online");
            sb.AppendLine(string.Format("Current gumball count: {0}", count));
            sb.AppendLine(string.Format("Current state: {0}", state));
            sb.AppendLine();
            return sb.ToString();
        }
    }
}