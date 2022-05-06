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
    public partial class Relatorios : System.Web.UI.Page
    {
        DataTable dataTable;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (DropRelatorio.SelectedValue == "")
                VDropRelatorio();
        }
        protected void Btn_Consultar_Click(object sender, EventArgs e)
        {
            bool retorno = true;
            if (string.IsNullOrEmpty(txtInicio.Value))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "aviso", "<script>alert('Informe a Data Inicio.')</script>");
                retorno = false;
            }
            if (string.IsNullOrEmpty(txtFinal.Value))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "aviso", "<script>alert('Informe a Data Fim.')</script>");
                retorno = false;
            }
            DateTime inicio = DateTime.Parse(txtInicio.Value);
            DateTime fim = DateTime.Parse(txtFinal.Value);

            if (DropRelatorio.SelectedIndex == 0)//vendas
            {
                dataTable  = new DataTable();
                dataTable = DataBaseService.RelatorioVendas(inicio, fim);

                bool valida =  ExportarExcel.SalvarExcel(dataTable, 1, "RelatorioVendas");
                if(valida == true)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "aviso", "<script>alert('Relatorio exportado com sucesso.')</script>");

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "aviso", "<script>alert('Não foi possivel fazer a Exportação do Relatorio.')</script>");

                }

            }
            else if (DropRelatorio.SelectedIndex == 1)//compras
            {
                dataTable = new DataTable();
                dataTable = DataBaseService.RelatorioCompra(inicio, fim);
                bool valida = ExportarExcel.SalvarExcel(dataTable, 1, "RelatorioCompra");
                if (valida == true)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "aviso", "<script>alert('Relatorio exportado com sucesso.')</script>");

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "aviso", "<script>alert('Não foi possivel fazer a Exportação do Relatorio.')</script>");

                }

            }
        }
        public void VDropRelatorio()
        {
            DropRelatorio.Items.Insert(0, new ListItem("Relatorio de Vendas", "0"));
            DropRelatorio.SelectedIndex = 0;

            DropRelatorio.Items.Insert(1, new ListItem("Relatorio de Compras", "1"));
            DropRelatorio.SelectedIndex = 1;
        }

    }
}