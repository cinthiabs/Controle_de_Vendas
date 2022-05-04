﻿using ControledeVendas.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControledeVendas
{
    public partial class Relatorios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (DropRelatorio.SelectedValue == "")
                VDropRelatorio();
        }
        protected void Btn_Consultar_Click(object sender, EventArgs e)
        {
            bool retorno = true;
            if (string.IsNullOrEmpty(txtInicio.Value))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "aviso", "<script>alert('Informe a Data Inicio.')</script>");
                retorno = false;
            }
            if (string.IsNullOrEmpty(txtFinal.Value))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "aviso", "<script>alert('Informe a Data Fim.')</script>");
                retorno = false;
            }

            if (DropRelatorio.SelectedIndex == 0)//vendas
            {
                DateTime inicio = DateTime.Parse(txtInicio.Value);
                DateTime fim = DateTime.Parse(txtFinal.Value);

                DataBaseService.RelatorioVendas(inicio, fim);
            }
            else if (DropRelatorio.SelectedIndex == 1)//compras
            {
                //teste
            }
        }
        public void VDropRelatorio()
        {
            DropRelatorio.Items.Insert(0, new ListItem("Relatorio de Vendas", "0"));
            DropRelatorio.SelectedIndex = 0;

            DropRelatorio.Items.Insert(1, new ListItem("Relatorio de Compras", "1"));
            DropRelatorio.SelectedIndex = 1;
        }

    }
}