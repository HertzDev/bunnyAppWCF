using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using bunnyWCF.Utils.Helper;
namespace bunnyWCF.Entities.Admin
{
    [DataContract]
    public class ClientServiceEntity
    {
        [DataMember]
        public List<ClientEntity> ListClient { get; set; }

        [DataMember]
        public MessageHelper Message { get; set; }
    }
}