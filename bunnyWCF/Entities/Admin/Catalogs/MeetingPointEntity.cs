using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using bunnyWCF.Entities.General;
namespace bunnyWCF.Entities.Admin.Catalogs
{
    [DataContract]
    public class MeetingPointEntity
    {
        [DataMember]
        public int IdMeetingPoint { get; set; }

        [DataMember]
        public string Direction { get; set; }

        [DataMember]
        public PointEntity Point {get; set;}

        [DataMember]
        public int IdState {get; set;}

        [DataMember]
        public int IdUser { get; set; }

        [DataMember]
        public string State { get; set; }
    }
}