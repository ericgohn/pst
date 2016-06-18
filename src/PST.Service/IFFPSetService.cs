using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PST.Service
{
    [ServiceContract]
    public interface IFFPSetService
    {
        [OperationContract]
        void DoWork();
    }
}
