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
            //Btn_Atualizar.Visible = false;
            //botao.Visible = false;
            TableConsulta();
        }
        public void TableConsulta()
        {
            Data = DataBaseService.ConsultaTableCompra();
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
                    Entidades.Compras compra = new Entidades.Compras();
                    compra.id = Convert.ToInt32(txtid.Value);

                    var retorno = DataBaseService.ConsultaCompras(compra);
                    if (retorno != null)
                    {
                        //Id.InnerText = Convert.ToString(retorno.id);
                        //Data.InnerText = Convert.ToDateTime(retorno.Data).ToString();
                        //Produto.InnerText = retorno.produto;
                        //Quantidade.InnerText = retorno.Quant;
                        //PrecoUni.InnerText = retorno.precoUnt;
                        //PrecoTotal.InnerText = retorno.precoTotal;
                        //botao.Visible = true;
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
                    if (retorno != null)
                    {
                        //ClientScript.RegisterStartupScript(this.GetType(), "aviso", "<script>alert('Produto cadastrado com sucesso! ID : " + retorno.id + "')</script>");
                        //Id.InnerText = Convert.ToString(retorno.id);
                        //Data.InnerText = Convert.ToDateTime(retorno.Data).ToString("yyyy-mm-dd hh:mm:ss");
                        //Produto.InnerText = retorno.produto;
                        //Quantidade.InnerText = retorno.Quant;
                        //PrecoUni.InnerText = retorno.precoUnt;
                        //PrecoTotal.InnerText = retorno.precoTotal;
                    }
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "aviso", "<script>alert('Erro: " + ex + "')</script>");

            }
        }
        
        protected void Btn_Adicionar_Click(object sender, EventArgs e) { }

        protected void Btn_Excluir_Click(object sender, EventArgs e) { }

        protected void Btn_Editar_Click(object sender, EventArgs e)
        {

            Entidades.Compras compra = new Entidades.Compras();
            compra.id = Convert.ToInt32(txtid.Value);

            var retorno = DataBaseService.ConsultaCompras(compra);

            if (retorno != null)
            {
                txtData.Value = Convert.ToDateTime(retorno.Data).ToString("yyyy-MM-dd");
                txtProduto.Value = retorno.produto;
                txtQuantidade.Value = retorno.Quant;
                txtPrecoUni.Value = Convert.ToString(retorno.precoUnt);
                txtPrecoTotal.Value = Convert.ToString(retorno.precoTotal);

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
                    if (retorno != null)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "aviso", "<script>alert('Produto atualizado com sucesso!')</script>");
                        //Data.InnerText = Convert.ToDateTime(retorno.Data).ToString("yyyy-mm-dd hh:mm:ss");
                        //Produto.InnerText = retorno.produto;
                        //Quantidade.InnerText = retorno.Quant;
                        //PrecoUni.InnerText = retorno.precoUnt;
                        //PrecoTotal.InnerText = retorno.precoTotal;
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

