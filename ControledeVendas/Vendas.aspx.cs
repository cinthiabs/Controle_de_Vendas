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
            ValoresPagamento();
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
                ClientScript.RegisterStartupScript(this.GetType(), "aviso", "<script>alert('Informe o Valor.')</script>");
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
        public void ValoresPagamento()
        {
            DataTable Data;
            Data = DataBaseService.PesquisaValoresPagamento();
            DropPago.DataSource = Data;
            DropPago.DataTextField = "descricao";
            DropPago.DataValueField = "id";

            if (Data.Rows.Count > 0)
            {
                DropPago.DataBind();
            }
            //DropPago.Items.Insert(0, new ListItem("--Selecione--", "0"));
            //DropPago.SelectedIndex = 0;
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
            //DropProduto.Items.Insert(0, new ListItem("--Selecione--", "0"));
            //DropProduto.SelectedIndex = 0;
        }
        protected void Btn_Editar_Click(object sender, EventArgs e)
        {

        }

        protected void Btn_Excluir_Click(object sender, EventArgs e)
        {
            Entidades.Vendas vend = new Entidades.Vendas();
            vend.id = Convert.ToInt32(txtid.Value);

            var retorno = DataBaseService.ConsultaVendas(txtid.Value);
            if (retorno != null)
            {
                var retornoExcluir = DataBaseService.ExcluirVendas(vend);
                if (retornoExcluir == true)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "aviso", "<script>alert('Venda excluida com sucesso!')</script>");
                    txtid.Value = "";
                    TableConsulta();
                }
            }
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
        public void LimpaCampos()
        {
            txtData.Value = "";
            txtid.Value = "";
            txtQuantidade.Value = "";
            txtValor.Value = "";
            ValoresProduto();
            ValoresPagamento();
        }
        protected void Btn_Inserir_Click(object sender, EventArgs e)
        {

            try
            {
                bool valida = ValidaCampos();
                if (valida == true)
                {
                    Entidades.Vendas vendas = new Entidades.Vendas();
                    var TESTE = DropProduto.SelectedItem;

                    vendas.Data = Convert.ToDateTime(txtData.Value);
                    vendas.produtoid =Convert.ToInt32(DropProduto.SelectedValue);
                    vendas.Cliente = txtCliente.Value;
                    vendas.Quant = txtQuantidade.Value;
                    vendas.precoTotal = txtValor.Value;
                    vendas.Pago = Convert.ToInt32(DropPago.SelectedValue);

                    var retorno = DataBaseService.InsertVendas(vendas);
                    if (retorno == true)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "aviso", "<script>alert('Venda cadastrada com sucesso!')</script>");
                        PanelPrincipal.Visible = true;
                        PanelSegundo.Visible = false;
                        LimpaCampos();
                        TableConsulta();
                    }
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "aviso", "<script>alert('Erro: " + ex + "')</script>");

            }
        }
    }
}