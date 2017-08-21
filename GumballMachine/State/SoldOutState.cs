using System;
using System.Runtime.Serialization;

namespace State
{
    [DataContract(Name = "SoldOutState")]
    [KnownType(typeof(IState))]
    public class SoldOutState : IState
    {
        private GumballMachine gumballMachine;
        private string stateName;

        public SoldOutState(GumballMachine gumballMachine)
        {
            this.gumballMachine = gumballMachine;
            stateName = "SoldOut";
        }

        [DataMember(Name = "StateName")]
        public override string StateName
        {
            get { return stateName; }
            set { stateName = value; }
        }

        public override void dispense()
        {
            Console.WriteLine("You haven't paid yet");
        }

        public override void ejectQuarter()
        {
            Console.WriteLine("There is no quarter");
        }

        public override void insertQuarter()
        {
            Console.WriteLine("Sorry, out of gumballs");
        }

        public override void turnCrank()
        {
            Console.WriteLine("Sorry, out of gumballs");
        }

        public override string ToString()
        {
            return "Sold Out State";
        }
    }
}