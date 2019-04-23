using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace bunnyWCF.Entities.Admin
{
    [DataContract]
    public class ClientEntity
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string CodeClient { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Phone { get; set; }

        [DataMember]
        public int IdState { get; set; }

        [DataMember]
        public int IdUser { get; set; }

        [DataMember]
        public string State { get; set; }
    }
}