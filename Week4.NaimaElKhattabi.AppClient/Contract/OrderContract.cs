using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Week4.NaimaElKhattabi.Client.Contract
{
    public class OrderContract
    {
        public int Id { get; set; }

        public DateTime DataOrdine { get; set; }

        public string CodiceOrdine { get; set; }

        public string CodiceProdotto { get; set; }

        public Decimal Importo { get; set; }


        public int ClienteId { get; set; }
    }
}
