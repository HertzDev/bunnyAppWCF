using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
namespace bunnyWCF.Entities.Admin
{
    [DataContract]
    public class ProductEntity
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public double PriceUnit { get; set; }

        [DataMember]
        public double CostUnit { get; set; }

        [DataMember]
        public int IdTypeProduct { get; set; }

        [DataMember]
        public string TypeProduct { get; set; }

        [DataMember]
        public int IdState { get; set; }

        [DataMember]
        public string State { get; set; }

        [DataMember]
        public string Image { get; set; }

        [DataMember]
        public int Points { get; set; }

        [DataMember]
        public int IdMaterial { get; set; }

        [DataMember]
        public string Material { get; set; }

    }
}