using System.Runtime.Serialization;

namespace State
{
    [DataContract(Name = "IState")]
    public abstract class IState
    {
        [DataMember(Name = "StateName")]
        public abstract string StateName { get; set; }
        public abstract void insertQuarter();
        public abstract void ejectQuarter();
        public abstract void turnCrank();
        public abstract void dispense();
    }
}
