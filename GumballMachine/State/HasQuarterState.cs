using System;
using System.Runtime.Serialization;

namespace State
{
    [DataContract(Name = "HasQuarterState")]
    [KnownType(typeof(IState))]
    public class HasQuarterState : IState
    {
        private GumballMachine gumballMachine;
        private Random randomWinner = new Random(DateTime.Now.Millisecond);
        private string stateName;

        public HasQuarterState(GumballMachine gumballMachine)
        {
            stateName = "Has Quarter";
            this.gumballMachine = gumballMachine;
        }

        [DataMember(Name = "StateName")]
        public override string StateName
        {
            get { return stateName; }
            set { stateName = value; }
        }

        public override void dispense()
        {
            Console.WriteLine("No gumball dispensed");
        }

        public override void ejectQuarter()
        {
            Console.WriteLine("Quarter returned");
            gumballMachine.setState(gumballMachine.getNoQuarterState());
        }

        public override void insertQuarter()
        {
            Console.WriteLine("You can't insert another quarter");
        }

        public override void turnCrank()
        {
            Console.WriteLine("You turned...");
            var winner = randomWinner.Next(10);
            if ((winner == 0) && (gumballMachine.getCount() > 1))
            {
                gumballMachine.setState(gumballMachine.getWinnerState());
            }
            else
            {
                gumballMachine.setState(gumballMachine.getSoldState());
            }
        }

        public override string ToString()
        {
            return stateName;
        }
    }
}
