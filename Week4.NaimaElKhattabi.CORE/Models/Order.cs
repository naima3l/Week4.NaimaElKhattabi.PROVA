using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Week4.NaimaElKhattabi.CORE.Models
{
    public class Order
    {

        public int Id { get; set; }


        public DateTime DataOrdine { get; set; }


        public string CodiceOrdine { get; set; }


        public string CodiceProdotto { get; set; }


        public Decimal Importo { get; set; }


        public virtual Customer Cliente { get; set; }

        public int ClienteId { get; set; }
    }
}
