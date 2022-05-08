using ControledeVendas.Entidades;
using ControledeVendas.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControledeVendas
{
    public partial class _Default : Page
    {
        DataTable Data = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            TableConsulta();
            TableCompra();

            Totais total = new Totais();

            total = DataBaseService.TotalCompras();
            if (total != null)
            {
                TotalCompras.InnerText = total.TotalCompras;

            }
            total = DataBaseService.TotalVed();
            if (total != null)
            {
                TotalVed.InnerText = total.TotalVed;

            }
            total = DataBaseService.TotalPaes();
            if (total != null)
            {
                TotalPaes.InnerText = total.TotalPaes;

            }
            total = DataBaseService.TotalPend();
            if (total != null)
            {
                TotalPend.InnerText = total.TotalPend;

            }

        }
        public void TableConsulta()
        {
            Data = DataBaseService.ConsultaTableVendas();
            Dados.DataSource = Data;
            Dados.DataBind();
        }
        public void TableCompra()
        {
            Data = DataBaseService.ConsultaTableCompra();
            DadosCompra.DataSource = Data;
            DadosCompra.DataBind();
        }
    }
}