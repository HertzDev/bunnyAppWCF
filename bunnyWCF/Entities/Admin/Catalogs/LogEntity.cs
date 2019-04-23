using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
namespace bunnyWCF.Entities.Admin.Catalogs
{
    [DataContract]
    public class LogEntity
    {
        [DataMember]
        public string Reason { get; set; }

        [DataMember]
        public string DateLog { get; set; }

        [DataMember]
        public int IdUser { get; set; }

        [DataMember]
        public string CodeMessage { get; set; }
        
        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string Message { get; set; }
    }
}