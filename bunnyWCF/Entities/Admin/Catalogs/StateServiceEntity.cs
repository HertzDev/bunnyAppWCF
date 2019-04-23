using bunnyWCF.Utils.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace bunnyWCF.Entities.Admin.Catalogs
{
    [DataContract]
    public class StateServiceEntity
    {
        [DataMember]
        public List<StateEntity> ListState { get; set; }

        [DataMember]
        public MessageHelper Message { get; set; }
    }
}