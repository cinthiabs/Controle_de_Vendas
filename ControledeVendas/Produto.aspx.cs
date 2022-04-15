﻿using ControledeVendas.Services;
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
                    Entidades.Produtos prod = new Entidades.Produtos();
                    prod.produto = txtProduto.Value;

                    var retorno = DataBaseService.ConsultaProduto(prod);
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
                        if (insert != null)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "aviso", "<script>alert('Categoria Cadastrada com sucesso!')</script>");

                            Dados.DataSource = insert;
                            Dados.DataBind();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "aviso", "<script>alert('Erro " + ex + "')</script>");
            }
        }

        protected void Btn_Atualizar_Click(object sender, EventArgs e)
        {

        }
    }
}