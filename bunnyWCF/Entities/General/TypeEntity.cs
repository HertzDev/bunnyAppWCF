using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace bunnyWCF.Entities.General
{
    [DataContract]
    public class TypeEntity
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Value { get; set; }

        [DataMember]
        public int IdState { get; set; }

        [DataMember]
        public string State { get; set; }

    }
}