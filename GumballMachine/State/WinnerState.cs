using System;
using System.Runtime.Serialization;

namespace State
{
    [DataContract(Name = "WinnerState")]
    [KnownType(typeof(IState))]
    public class WinnerState : IState
    {
        private GumballMachine gumballMachine;
        private string stateName;

        public WinnerState(GumballMachine gumballMachine)
        {
            this.gumballMachine = gumballMachine;
            stateName = "Winner state";
        }

        [DataMember(Name = "StateName")]
        public override string StateName
        {
            get { return stateName; }
            set { stateName = value; }
        }

        public override void dispense()
        {
            gumballMachine.releaseBall();
            if (gumballMachine.getCount() == 0)
            {
                setSoldOutState();
            }
            else
            {
                gumballMachine.releaseBall();
                Console.WriteLine("YOU'RE A WINNER! You got two gumballs for your quarter");
                if (gumballMachine.getCount() > 0)
                {
                    gumballMachine.setState(gumballMachine.getNoQuarterState());
                }
                else
                {
                    setSoldOutState();
                }
            }
        }

        private void setSoldOutState()
        {
            Console.WriteLine("Oops. Out of gumballs");
            gumballMachine.setState(gumballMachine.getSoldOutState());
        }

        public override void ejectQuarter()
        {
            Console.WriteLine("Sorry, you already turned the crank");
        }

        public override void insertQuarter()
        {
            Console.WriteLine("Please wait, we're already giving you a gumball");
        }

        public override void turnCrank()
        {
            Console.WriteLine("Turning twice doesn't get you another gumball");
        }

        public override string ToString()
        {
            return "Winner State";
        }
    }
}
