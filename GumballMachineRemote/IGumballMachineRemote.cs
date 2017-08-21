using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GumballMachineRemote
{
    [ServiceContract]
    public interface IGumballMachineRemote
    {
        [OperationContract]
        int getCount();

        [OperationContract]
        string getLocation();

        [OperationContract]
        IState getState();
    }
}
