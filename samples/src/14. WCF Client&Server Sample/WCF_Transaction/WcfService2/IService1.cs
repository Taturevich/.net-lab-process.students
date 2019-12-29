using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService2
{
    // NOTE: If you change the interface name "IService1" here, you must also update the reference to "IService1" in Web.config.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Mandatory)]
        void UpdateData();

    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool _boolValue = true;
        string _stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get => _boolValue;
            set => _boolValue = value;
        }

        [DataMember]
        public string StringValue
        {
            get => _stringValue;
            set => _stringValue = value;
        }
    }
}
