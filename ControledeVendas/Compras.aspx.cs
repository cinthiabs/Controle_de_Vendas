using ControledeVendas.Entidades;
using ControledeVendas.Services;
using System;
using System.Globalization;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ControledeVendas
{
    public partial class Compras : System.Web.UI.Page
    {
        DataTable Data = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            PanelPrincipal.Visible = true;
            PanelSegundo.Visible = false;
            Btn_Atualizar.Visible = false;
            TableConsulta();
        }
        public void TableConsulta()
        {
            Data = DataBaseService.ConsultaTableCompra(30);
            Dados.DataSource = Data;
            Dados.DataBind();
        }
        protected void Btn_Consultar_Click(object sender, EventArgs e)
        {
            try
            {   // campos obrigatorios

                if (string.IsNullOrEmpty(txtid.Value))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "aviso", "<script>alert('Informe codigo do Produto.')</script>");
                }

                else
                {
                    var retorno = DataBaseService.ConsultaCompra(txtid.Value);
                    if (retorno != null)
                    {
                        Dados.DataSource = retorno;
                        Dados.DataBind();
                    }

                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "aviso", "<script>alert('Erro: " + ex + "')</script>");
            }
        }

        protected void Btn_Inserir_Click(object sender, EventArgs e)
        {
            try
            {
                bool valida = ValidaCampos();
                if (valida == true )
                {
                    Entidades.Compras compra = new Entidades.Compras();
                    compra.produto = txtProduto.Value;
                    compra.Data = Convert.ToDateTime(txtData.Value);
                    compra.Quant = txtQuantidade.Value;
                    compra.precoUnt = txtPrecoUni.Value;
                    compra.precoTotal = txtPrecoTotal.Value;

                    var retorno = DataBaseService.InsertCompras(compra);
                    if (retorno == true)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "aviso", "<script>alert('Produto cadastrado com sucesso!')</script>");
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
        
        protected void Btn_Adicionar_Click(object sender, EventArgs e)
        {
            PanelPrincipal.Visible = false;
            PanelSegundo.Visible = true;
            Btn_Atualizar.Visible = false;
            Btn_Inserir.Visible = true;
        }

        protected void Btn_Excluir_Click(object sender, EventArgs e) 
        {
            Entidades.Compras compra = new Entidades.Compras();
            compra.id = Convert.ToInt32(txtid.Value);

            var retorno = DataBaseService.ConsultaCompras(compra);
            if (retorno != null)
            {
                var retornoExcluir = DataBaseService.ExcluirCompra(compra);
                if (retornoExcluir == true)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "aviso", "<script>alert('Produto excluido com sucesso!')</script>");
                    txtid.Value = "";
                    TableConsulta();

                }

            }
        }
        
        protected void Btn_Editar_Click(object sender, EventArgs e)
        {
            Adicionar.Visible = false;
            PanelPrincipal.Visible = false;
            PanelSegundo.Visible = true;
            Btn_Atualizar.Visible = true;

            Entidades.Compras compra = new Entidades.Compras();
            compra.id = Convert.ToInt32(txtid.Value);

            var retorno = DataBaseService.ConsultaCompras(compra);

            if (retorno != null)
            {
                txtid.Value = Convert.ToString(retorno.id);
                txtProduto.Value = retorno.produto;
                txtData.Value = retorno.Data.ToString("yyyy-MM-dd");
                txtQuantidade.Value = retorno.Quant;
                txtPrecoUni.Value = retorno.precoUnt;
                txtPrecoTotal.Value = retorno.precoTotal;
            }
        }
        public  bool ValidaCampos()
        {
            bool retorno = true;
            if (string.IsNullOrEmpty(txtData.Value))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "aviso", "<script>alert('Informe a Data.')</script>");
                retorno = false;
            }
            else if (string.IsNullOrEmpty(txtProduto.Value))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "aviso", "<script>alert('Informe o Produto.')</script>");
                retorno = false;
            }
            else if (string.IsNullOrEmpty(txtPrecoUni.Value))
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
        public void LimpaCampos()
        {
            txtData.Value = "";
            txtProduto.Value = "";
            txtPrecoTotal.Value = "";
            txtPrecoUni.Value = "";
            txtQuantidade.Value = "";
        }

        protected void Btn_Atualizar_Click(object sender, EventArgs e)
        {
            try
            {    // campos obrigatorios
                bool valida = ValidaCampos();
                if (valida == true)
                {
                    Entidades.Compras compra = new Entidades.Compras();
                    compra.id = Convert.ToInt32(txtid.Value);
                    compra.produto = txtProduto.Value;
                    compra.Data = Convert.ToDateTime(txtData.Value);
                    compra.Quant = txtQuantidade.Value;
                    compra.precoUnt = txtPrecoUni.Value;
                    compra.precoTotal = txtPrecoTotal.Value;

                    var retorno = DataBaseService.AtualizaCompras(compra);
                    if (retorno == true)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "aviso", "<script>alert('Cadastro atualizado com sucesso!')</script>");
                        PanelPrincipal.Visible = true;
                        PanelSegundo.Visible = false;
                        Btn_Atualizar.Visible = false;
                        LimpaCampos();
                        TableConsulta();
                    }
                }
            }
            catch(Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "aviso", "<script>alert('Erro: " + ex + "')</script>");

            }
        }
    }
}

