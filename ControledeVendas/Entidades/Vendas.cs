using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControledeVendas.Entidades
{
    public class Vendas
    {
        public int id { get; set; }
        public DateTime Data { get; set; }
        public int produtoid { get; set; }
        public string Nome { get; set; }
        public string Cliente { get; set; }
        public string Quant { get; set; }
        public int Pago { get; set; }
        public string precoTotal { get; set; }

    }
}