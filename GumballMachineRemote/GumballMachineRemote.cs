using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GumballMachineRemote
{
    public class GumballMachineRemote : IGumballMachineRemote
    {
        public int getCount()
        {
            throw new NotImplementedException();
        }

        public string getLocation()
        {
            throw new NotImplementedException();
        }

        public IState getState()
        {
            throw new NotImplementedException();
        }
    }
}
