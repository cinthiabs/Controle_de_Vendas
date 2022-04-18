using ControledeVendas.Services;
using ControledeVendas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ControledeVendas
{
    public partial class Produto : System.Web.UI.Page
    {
        DataTable Data = new DataTable();


        protected void Page_Load(object sender, EventArgs e)
        {

           
                PanelPrincipal.Visible = true;
                PanelSegundo.Visible = false;
                Btn_Atualizar.Visible = false;
                TableConsulta();

                if (txtProduto.Value == "")
                {
                  TableConsulta();
                }


        }
        public void TableConsulta()
        {
            Data = DataBaseService.ConsultaTable();
            Dados.DataSource = Data;
            Dados.DataBind();

        }


        protected void Btn_Consultar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtProduto.Value))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "aviso", "<script>alert('Informe o Nome')</script>");
                }
                else
                {
                    var retorno = DataBaseService.ConsultaProd(txtProduto.Value);
                    if (retorno != null)
                    {
                        Dados.DataSource = retorno;
                        Dados.DataBind();
                    }

                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "aviso", "<script>alert('Erro " + ex + "')</script>");
            }

        }        
        protected void Btn_Adicionar_Click(object sender, EventArgs e)
        {
            PanelPrincipal.Visible = false;
            PanelSegundo.Visible = true;
            Btn_Atualizar.Visible = false;
            Btn_Inserir.Visible = true;
        }
        protected void Btn_Inserir_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (string.IsNullOrEmpty(txtProduto.Value))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "aviso", "<script>alert('Informe o Nome.')</script>");
                }
                else
                {
                    Entidades.Produtos prod = new Entidades.Produtos();
                    prod.produto = txtProduto.Value;

                    var retorno = DataBaseService.ConsultaProduto(prod);
                    if (retorno.id != 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "aviso", "<script>alert('Produto já Cadastrado.')</script>");
                    }
                    else
                    {
                        var insert = DataBaseService.InsertProduto(prod);
                        if (insert == true)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "aviso", "<script>alert('Produto Cadastrada com sucesso!')</script>");
                            PanelPrincipal.Visible = true;
                            PanelSegundo.Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "aviso", "<script>alert('Erro " + ex + "')</script>");
            }
        }

        protected void Btn_Editar_Click(object sender, EventArgs e)
        {
            Adicionar.Visible = false;
            PanelPrincipal.Visible = false;
            PanelSegundo.Visible = true;
            Btn_Atualizar.Visible = true;

            Entidades.Produtos prod = new Entidades.Produtos();
            prod.produto = txtProduto.Value;

            var retorno = DataBaseService.ConsultaProduto(prod);

            if (retorno != null)
            {
                txtid.Value = Convert.ToInt32(retorno.id).ToString();
                inputProduto.Value = retorno.produto;
            }

        }
        protected void Btn_Atualizar_Click(object sender, EventArgs e)
        {
            Entidades.Produtos prod = new Entidades.Produtos();
            prod.produto = inputProduto.Value;
            prod.id = Convert.ToInt32(txtid.Value);

            bool retorno = DataBaseService.AtualizarProd(prod);
            {
                if (retorno == true)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "aviso", "<script>alert('Produto Atualizado com sucesso!')</script>");
                    PanelPrincipal.Visible = true;
                    PanelSegundo.Visible = false;
                    Btn_Atualizar.Visible = false;
                    txtProduto.Value = "";

                    TableConsulta();
                }

            }

        }

        protected void Btn_Excluir_Click(object sender, EventArgs e)
        {
            Entidades.Produtos prod = new Entidades.Produtos();
            prod.produto = txtProduto.Value;
         
            var retorno = DataBaseService.ConsultaProduto(prod);
            if(retorno != null)
            {
                int id = retorno.id;
                var retornoExcluir = DataBaseService.ExcluirProduto(id);
                if(retornoExcluir != null)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "aviso", "<script>alert('Produto excluido com sucesso!')</script>");
                    txtProduto.Value = "";
                    TableConsulta();

                }

            }

        }
    }
}