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
    public partial class Categorias : System.Web.UI.Page
    {
        DataTable Data = new DataTable();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            Categoria cat = new Categoria();
            Data = DataBaseService.ConsultaTable();

            //List<Categoria> categorias = new List<Categoria>();
            //for (var data = 0; data < Data.Rows.Count; data++)
            //{

            //    cat.id = Convert.ToInt32(Data.Rows[data]["id"].ToString());
            //    cat.produto = Data.Rows[data]["nome"].ToString();

            //    categorias.Add(cat);

            //}
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
                    Categoria cat = new Categoria();
                    cat.produto = txtProduto.Value;

                    var retorno = DataBaseService.ConsultaCategoria(cat);
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
                    Categoria cat = new Categoria();
                    cat.produto = txtProduto.Value;

                    var retorno = DataBaseService.ConsultaCategoria(cat);
                    if (retorno.id != 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "aviso", "<script>alert('Produto já Cadastrado.')</script>");

                    }
                    else
                    {
                        var insert = DataBaseService.InsertCategoria(cat);
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