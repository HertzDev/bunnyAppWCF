using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bunnyWCF.Entities.General;
using System.Runtime.Serialization;
namespace bunnyWCF.Entities.Admin.Catalogs
{
    [DataContract]
    public class TypeProductEntity:TypeEntity
    {
        [DataMember]
        public string Description { get; set; }
    }
}