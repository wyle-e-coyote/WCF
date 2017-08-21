using System;
using System.Runtime.Serialization;

namespace State
{
    [DataContract(Name = "NoQuarterState")]
    [KnownType(typeof(IState))]
    public class NoQuarterState : IState
    {
        GumballMachine gumballMachine;
        string stateName;

        public NoQuarterState(GumballMachine gumballMachine)
        {
            this.gumballMachine = gumballMachine;
            stateName = "No Quarter";
        }

        [DataMember(Name = "StateName")]
        public override string StateName
        {
            get { return stateName; }
            set { stateName = value; }
        }
        public override void dispense()
        {
            Console.WriteLine("You need to pay first");
        }

        public override void ejectQuarter()
        {
            Console.WriteLine("You haven't inserted a quarter");
        }

        public override void insertQuarter()
        {
            Console.WriteLine("You inserted a quarter");
            gumballMachine.setState(gumballMachine.getHasQuarterState());
        }

        public override void turnCrank()
        {
            Console.WriteLine("You turned, but there's no quarter");
        }

        public override string ToString()
        {
            return "No Quarter State";
        }
    }
}
