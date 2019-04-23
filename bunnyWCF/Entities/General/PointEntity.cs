using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
namespace bunnyWCF.Entities.General
{

    [DataContract]
    public class PointEntity
    {
        [DataMember]
        public double Latitude { get; set; }

        [DataMember]
        public double Longitude { get; set; }
    }
}