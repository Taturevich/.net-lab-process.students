using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Pets
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPetService" in both code and config file together.
    [ServiceContract]
    public interface IPetService
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        Task<List<Pet>> GetPets();
    }

    [DataContract]
    public class Pet
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Type { get; set; }
    }
}
