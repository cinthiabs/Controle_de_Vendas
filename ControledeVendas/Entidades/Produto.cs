using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControledeVendas.Entidades
{
    public class Produto
    {
        public int  id { get; set; }
        public DateTime Data { get; set; }
        public string produto { get; set; }
        public string Quant { get; set; }
        public float precoUnt { get; set; }
        public float precoTotal { get; set; }

    }
}