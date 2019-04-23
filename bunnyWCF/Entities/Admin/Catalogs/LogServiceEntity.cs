using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using bunnyWCF.Utils.Helper;
namespace bunnyWCF.Entities.Admin.Catalogs
{
    [DataContract]
    public class LogServiceEntity
    {
        [DataMember]
        public List<LogEntity> ListLog { get; set; }

        [DataMember]
        public MessageHelper Message { get; set; }
    }
}