using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using bunnyWCF.Utils.Helper;
namespace bunnyWCF.Entities.Admin.Catalogs
{
    [DataContract]
    public class TypeProductServiceEntity
    {
        [DataMember]
        public List<TypeProductEntity> ListProduct{ get; set; }

        [DataMember]
        public MessageHelper Message { get; set; }
    }
}