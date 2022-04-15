using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControledeVendas.Entidades;

namespace ControledeVendas
{
    public partial class Vendas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.panelGrid.Visible = false;
            //botao.Visible = false;
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

        protected void Btn_inserir_Click(object sender, EventArgs e)
        {

        }

        protected void Btn_Excluir_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }
    }
}