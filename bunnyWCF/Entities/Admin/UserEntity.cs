using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
namespace bunnyWCF.Entities.Admin
{
    [DataContract]
    public class UserEntity
    {
        [DataMember]
        public int IdUser { get; set; }
        
        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public int IdTypeUser { get; set; }

        [DataMember]
        public string TypeUser { get; set; }
        
        [DataMember]
        public int IdState { get; set; }

        [DataMember]
        public string State { get; set; }
        
        
    }
}