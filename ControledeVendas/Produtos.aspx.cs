﻿using ControledeVendas.Entidades;
using ControledeVendas.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControledeVendas
{
    public partial class Produtos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            botao.Visible = false;
        }

        protected void Btn_Consultar_Click(object sender, EventArgs e)
        {
            try
            {   // campos obrigatorios
                
                if(string.IsNullOrEmpty(txtid.Value))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "aviso", "<script>alert('Informe codigo do Produto.')</script>");
                }
               
                else
                {
                    Produto prod = new Produto();
                    prod.id = Convert.ToInt32(txtid.Value);
                    
                    var retorno = DataBaseService.ConsultaProduto(prod);
                    if (retorno != null)
                    {
                        Id.InnerText = Convert.ToString(retorno.id);
                        Data.InnerText = retorno.Data;
                        Produto.InnerText = retorno.produto;
                        Quantidade.InnerText = retorno.Quant;
                        PrecoUni.InnerText = retorno.precoUnt;
                        PrecoTotal.InnerText = retorno.precoTotal;
                        botao.Visible = true;
                    }

                }
            }
            catch(Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "aviso", "<script>alert('Erro: " + ex + "')</script>");
            }
        }

        protected void Btn_Inserir_Click(object sender, EventArgs e)
        {
            try
            {    // campos obrigatorios

                if (string.IsNullOrEmpty(txtData.Value))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "aviso", "<script>alert('Informe a Data.')</script>");
                }
                else if (string.IsNullOrEmpty(txtProduto.Value))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "aviso", "<script>alert('Informe o Produto.')</script>");
                }
                else if (string.IsNullOrEmpty(txtPrecoUni.Value))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "aviso", "<script>alert('Informe o Preço unitário.')</script>");
                }
                else
                {
                    Produto prod = new Produto();
                    prod.produto = txtProduto.Value;
                    prod.Data =    txtData.Value;
                    prod.Quant = txtQuantidade.Value;
                    prod.precoUnt = txtPrecoUni.Value;
                    prod.precoTotal = txtPrecoTotal.Value;

                    var retorno = DataBaseService.InsertProduto(prod);
                    if (retorno != null)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "aviso", "<script>alert('Produto cadastrado com sucesso! ID : "+retorno.id+"')</script>");
                        Id.InnerText = Convert.ToString(retorno.id);
                        Data.InnerText = retorno.Data;
                        Produto.InnerText = retorno.produto;
                        Quantidade.InnerText = retorno.Quant;
                        PrecoUni.InnerText = retorno.precoUnt;
                        PrecoTotal.InnerText = retorno.precoTotal;
                    }
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "aviso", "<script>alert('Erro: " + ex + "')</script>");

            }
        }

        protected void Editar_Click(object sender, EventArgs e)
        {
            Produto prod = new Produto();
            prod.id = Convert.ToInt32(txtid.Value);

            var retorno = DataBaseService.ConsultaProduto(prod);
            if (retorno != null)
            {
                txtData.Value= retorno.Data;
                txtProduto.Value = retorno.produto;
                txtQuantidade.Value = retorno.Quant;
                txtPrecoUni.Value = Convert.ToString(retorno.precoUnt);
                txtPrecoTotal.Value = Convert.ToString( retorno.precoTotal);
               
            }
        }
    }
}