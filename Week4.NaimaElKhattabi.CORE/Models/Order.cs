using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Week4.NaimaElKhattabi.CORE.Models
{
    [DataContract]
    public class Order
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public DateTime DataOrdine { get; set; }

        [DataMember]
        public string CodiceOrdine { get; set; }

        [DataMember]
        public string CodiceProdotto { get; set; }

        [DataMember]
        public Decimal Importo { get; set; }

        [DataMember]
        public virtual Customer Cliente { get; set; }

        public int ClienteId { get; set; }
    }
}
