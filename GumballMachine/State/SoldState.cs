using System;
using System.Runtime.Serialization;

namespace State
{
    [DataContract(Name = "SoldState")]
    [KnownType(typeof(IState))]
    public class SoldState : IState
    {
        private GumballMachine gumballMachine;
        private string stateName;

        [DataMember(Name = "SoldState")]
        public override string StateName
        {
            get { return stateName; }
            set { stateName = value; }
        }

        public SoldState(GumballMachine gumballMachine)
        {
            this.gumballMachine = gumballMachine;
        }

        public override void dispense()
        {
            if (gumballMachine.getCount() > 0)
            {
                gumballMachine.releaseBall();
                gumballMachine.setState(gumballMachine.getNoQuarterState());
            }
            else
            {
                gumballMachine.setState(gumballMachine.getSoldOutState());
            }
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
            return "Sold State";
        }
    }
}
