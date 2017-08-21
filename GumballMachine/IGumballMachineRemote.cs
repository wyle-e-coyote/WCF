using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace State
{
    [ServiceContract(Name = "GumballMachine", Namespace = "State")]

    public interface IGumballMachineRemote
    {
        [OperationContract]
        int getCount();

        [OperationContract]
        string getLocation();

        [OperationContract]
        [ServiceKnownType(typeof(NoQuarterState))]
        [ServiceKnownType(typeof(SoldOutState))]
        [ServiceKnownType(typeof(SoldState))]
        [ServiceKnownType(typeof(WinnerState))]
        [ServiceKnownType(typeof(HasQuarterState))]
        IState getState();
    }
}
