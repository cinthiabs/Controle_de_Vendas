using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControledeVendas.Entidades;
using System.Data;
using ControledeVendas.Services;

namespace ControledeVendas
{
    public partial class Vendas : System.Web.UI.Page
    {
        DataTable Data = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            PanelPrincipal.Visible = true;
            PanelSegundo.Visible = false;
            Btn_Atualizar.Visible = false;
            TableConsulta();
            ValoresProduto();
        }
        public void TableConsulta()
        {
            Data = DataBaseService.ConsultaTableVendas();
            Dados.DataSource = Data;
            Dados.DataBind();
        }
        public bool ValidaCampos()
        {
            bool retorno = true;
            if (string.IsNullOrEmpty(txtData.Value))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "aviso", "<script>alert('Informe a Data.')</script>");
                retorno = false;
            }
            else if (string.IsNullOrEmpty(txtQuantidade.Value))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "aviso", "<script>alert('Informe a Quantidade.')</script>");
                retorno = false;
            }
            else if (string.IsNullOrEmpty(txtValor.Value))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "aviso", "<script>alert('Informe o Preço unitário.')</script>");
                retorno = false;
            }
            
            else
            {
                retorno = true;
            }
            return retorno;
        }
        protected void Btn_Consultar_Click(object sender, EventArgs e)
        {
            bool valida = ValidaCampos();
            if (valida == true)
            {
                Vendas vendas = new Vendas();
               
            }
        }
        public void ValoresProduto()
        {
            DataTable Data;
            Data = DataBaseService.PesquisaValoresProduto();
            DropProduto.DataSource = Data;
            DropProduto.DataTextField = "Nome";
            DropProduto.DataValueField = "id";

            if(Data.Rows.Count > 0)
            {
                DropProduto.DataBind();
            }
            DropProduto.Items.Insert(0, new ListItem("--Selecione--", "0"));
            DropProduto.SelectedIndex = 0;
        }
        protected void Btn_Inserir_Click(object sender, EventArgs e)
        {

        }

        protected void Btn_Editar_Click(object sender, EventArgs e)
        {

        }

        protected void Btn_Excluir_Click(object sender, EventArgs e)
        {

        }
        protected void Btn_Atualizar_Click(object sender, EventArgs e)
        {

        }
        protected void Btn_Adicionar_Click(object sender, EventArgs e)
        {
            PanelPrincipal.Visible = false;
            PanelSegundo.Visible = true;
            Btn_Atualizar.Visible = false;
            Btn_Inserir.Visible = true;
        }
        

    }
}