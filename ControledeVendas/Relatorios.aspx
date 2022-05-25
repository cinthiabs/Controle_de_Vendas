<%@ Page Language="C#" Title="Relatorios" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Relatorios.aspx.cs" Inherits="ControledeVendas.Relatorios" %>

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

        .headerFIltro {
            align-items: center;
            border: 1px solid #d6d6d8;
            height: 187px;
            background: #d6d6d8;
            width: 97%;
        }

            .headerFIltro h5 {
                font-weight: bold;
                padding-left: 15px;
            }

        .BodyFIltro {
            padding-top: 15px;
            height: 150px;
            background: #ffffff;
            margin: auto;
        }
    </style>
    <div class="row">
        <div class="headerFIltro bg-info">
            <h5>Filtros</h5>
            <div class="BodyFIltro">

                <div class="form-group col-md-4">    
                    <label for="txtrelatorio">Relatório</label>
                      <asp:DropDownList ID="DropRelatorio" runat="server" BackColor="White" class="form-control">
                        </asp:DropDownList>
                </div>
                <div class="form-group col-md-3">
                    <label for="txtInicio">Data Inicio</label>
                    <input type="datetime-local" class="form-control" id="txtInicio" runat="server">
                </div>
                <div class="form-group col-md-3">
                    <label for="txtFinal">Data Final </label>
                    <input type="datetime-local" class="form-control" id="txtFinal" runat="server">
                </div>
                <div class="form-group col-md-1 combo">
                    <asp:Button ID="Btn_Consultar" class="btn btn-primary" runat="server" Text="Consultar" OnClick="Btn_Consultar_Click" />
                </div>
            </div>
        </div>
        <br />
    </div>
</asp:Content>
