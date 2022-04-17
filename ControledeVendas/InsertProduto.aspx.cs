using ControledeVendas.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControledeVendas
{
    public partial class InsertProduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

       
        protected void Btn_Inserir_Click(object sender, EventArgs e)
        {
            //LimpaCampos();
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
                        if (insert != null)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "aviso", "<script>alert('Produto Cadastrada com sucesso!')</script>");
                            //retornar a tela de consulta
                            //Dados.DataSource = insert;
                            //Dados.DataBind();
                            Response.Redirect("Produto.aspx");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "aviso", "<script>alert('Erro " + ex + "')</script>");
            }
        }
    }
}