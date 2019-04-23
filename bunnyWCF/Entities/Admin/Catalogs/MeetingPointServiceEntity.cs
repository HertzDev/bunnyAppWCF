using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using bunnyWCF.Utils.Helper;
namespace bunnyWCF.Entities.Admin.Catalogs
{
    [DataContract]
    public class MeetingPointServiceEntity
    {
        [DataMember]
        public List<MeetingPointEntity> ListMeetingPoints { get; set; }

        [DataMember]
        public MessageHelper Message { get; set; }
        
    }
}