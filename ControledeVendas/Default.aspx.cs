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
           
            FiltroData();
            if (DropRelatorio.SelectedValue == "")
                VDropRelatorio();
                FiltroData();
        }

        public void FiltroData()
        {
            Totais total = new Totais();

            if (DropRelatorio.SelectedIndex == 0)//15 dias
            {
                TableConsulta(15);
                TableCompra(15);

                total = DataBaseService.TotalCompras(15);
                if (total != null)
                {
                    TotalCompras.InnerText = total.TotalCompras;

                }
                total = DataBaseService.TotalVed(15);
                if (total != null)
                {
                    TotalVed.InnerText = total.TotalVed;

                }
                total = DataBaseService.TotalPaes(15);
                if (total != null)
                {
                    TotalPaes.InnerText = total.TotalPaes;

                }
                total = DataBaseService.TotalPend(15);
                if (total != null)
                {
                    TotalPend.InnerText = total.TotalPend;

                }

            }
            else if (DropRelatorio.SelectedIndex == 1)//30 dias
            {
                TableConsulta(30);
                TableCompra(30);
                total = DataBaseService.TotalCompras(30);
                if (total != null)
                {
                    TotalCompras.InnerText = total.TotalCompras;

                }
                total = DataBaseService.TotalVed(30);
                if (total != null)
                {
                    TotalVed.InnerText = total.TotalVed;

                }
                total = DataBaseService.TotalPaes(30);
                if (total != null)
                {
                    TotalPaes.InnerText = total.TotalPaes;

                }
                total = DataBaseService.TotalPend(30);
                if (total != null)
                {
                    TotalPend.InnerText = total.TotalPend;

                }
            }
            else if (DropRelatorio.SelectedIndex == 2)//60 dias
            {
                TableConsulta(60);
                TableCompra(60);
                total = DataBaseService.TotalCompras(60);
                if (total != null)
                {
                    TotalCompras.InnerText = total.TotalCompras;

                }
                total = DataBaseService.TotalVed(60);
                if (total != null)
                {
                    TotalVed.InnerText = total.TotalVed;

                }
                total = DataBaseService.TotalPaes(60);
                if (total != null)
                {
                    TotalPaes.InnerText = total.TotalPaes;

                }
                total = DataBaseService.TotalPend(60);
                if (total != null)
                {
                    TotalPend.InnerText = total.TotalPend;

                }
            }
        }
        protected void DropRelatorio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(DropRelatorio.SelectedValue))
            {
                FiltroData();
            }
        }
        public void TableConsulta(int dias)
        {
            Data = DataBaseService.ConsultaTableVendas(dias);
            Dados.DataSource = Data;
            Dados.DataBind();
        }
        public void TableCompra(int dias)
        {
            Data = DataBaseService.ConsultaTableCompra(dias);
            DadosCompra.DataSource = Data;
            DadosCompra.DataBind();
        }
        public void VDropRelatorio()
        {
            DropRelatorio.Items.Insert(0, new ListItem("15 Dias", "0"));
            DropRelatorio.SelectedIndex = 0;

            DropRelatorio.Items.Insert(1, new ListItem("30 Dias", "1"));
            DropRelatorio.SelectedIndex = 1;

            DropRelatorio.Items.Insert(2, new ListItem("60 Dias", "2"));
            DropRelatorio.SelectedIndex = 2;
        }
    }
}