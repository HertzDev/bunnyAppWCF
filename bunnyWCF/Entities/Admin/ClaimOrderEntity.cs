using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
namespace bunnyWCF.Entities.Admin
{
    [DataContract]
    public class ClaimOrderEntity
    {

        [DataMember]
        public string CodeOrder { get; set; }

        [DataMember]
        public string DateClaim { get; set; }

        [DataMember]
        public string CodeClient { get; set; }

        [DataMember]
        public string Reason { get; set; }

        [DataMember]
        public int IdType { get; set; }

        [DataMember]
        public int IdState { get; set; }

        [DataMember]
        public string TypeClaim { get; set; }
        
        [DataMember]
        public string State { get; set; }

        
    }
}