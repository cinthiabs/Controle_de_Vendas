<%@ Page Language="C#" Title="Relatorios"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Relatorios.aspx.cs" Inherits="ControledeVendas.Relatorios" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .row {
            padding-top: 40px;
            padding-bottom: 30px;
            margin-bottom: 30px;
            margin-left: 60px;

        }

        .combo {
            text-align: right;
            margin: auto;
            padding-right: 85px;
            padding-top: 22px;
            padding-bottom: 20px;
        }
        .headerFIltro{
                align-items:center;
                border: 1px solid #d6d6d8;
                height:187px;
                background:#d6d6d8;
                width:97%;


        }
        .headerFIltro h5{
            font-weight:bold;
            padding-left:5px;
        }
        .BodyFIltro{
            padding-top:15px;
            height:150px;
            background:#ffffff;
            margin:auto;
        }
        
    </style>
    <div class="row">
        <div class="headerFIltro">
            <h5>Relatorio de Compras</h5>
             <div class="BodyFIltro">
                 <div class="form-group col-md-4">
                     
                    <label for="txtInicio">Data Inicio</label>
                    <input type="datetime-local" class="form-control" id="txtInicio" runat="server" >
                </div>
                 <div class="form-group col-md-4">
                    <label for="txtFinal">Data Final </label>
                    <input type="datetime-local" class="form-control" id="txtFinal" runat="server">
                </div>
                <div class="form-group col-md-1 combo">
                    <asp:Button ID="Btn_Atualizar" class="btn btn-primary" runat="server" Text="Consultar" />
                </div>
            </div>
        </div>
        <br />
         <%--<div class="headerFIltro">
            <h5>Relatorio de Vendas</h5>
             <div class="BodyFIltro">
                 <div class="form-group col-md-4">
                     
                    <label for="txtInicio">Data Inicio</label>
                    <input type="datetime-local" class="form-control" id="Datetimelocal1" runat="server" >
                </div>
                 <div class="form-group col-md-4">
                    <label for="txtFinal">Data Final </label>
                    <input type="datetime-local" class="form-control" id="Datetimelocal2" runat="server">
                </div>
                <div class="form-group col-md-1 combo">
                    <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="Consultar" />
                </div>
            </div>
        </div>--%>
     </div>
</asp:Content>
