using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using bunnyWCF.Utils.Helper;
namespace bunnyWCF.Entities.Admin.Catalogs
{
    [DataMember]
    public class TypeEmployeeServiceEntity
    {
        [DataMember]
        public List<TypeEmployeeEntity> ListTypeEmployee { get; set; }

        [DataMember]
        public MessageHelper Message { get; set; }
    }
}