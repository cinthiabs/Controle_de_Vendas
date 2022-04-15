﻿<%@ Page Language="C#" Title="Produto" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Produto.aspx.cs" Inherits="ControledeVendas.Produto" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .row {
            padding-top: 40px;
            padding-bottom: 30px;
            margin-bottom: 30px;
            margin-left: 40px;
        }

        .combo {
            text-align: right;
            margin: auto;
            padding-right: 80px;
            padding-top: 20px;
            padding-bottom: 20px;
        }

        input:disabled {
            background: white;
        }
    </style>
    <div class="row">
        <h3><%: Title %></h3>

        <form action="">
            <div class="containerTable">

                <div class="form-group col-md-4">
                    <label for="txtid">ID:</label>
                    <input type="number" class="form-control" id="txtid" runat="server" disabled="">
                </div>

                <div class="form-group col-md-4">
                    <label for="txtProduto">Produto:</label>
                    <input type="text" class="form-control" id="txtProduto" runat="server">
                </div>

                <br />
                <div class="form-group col-md-12 combo">
                    <asp:Button ID="Btn_Consultar" class="btn btn-primary" runat="server" Text="Consultar" OnClick="Btn_Consultar_Click" />
                    <asp:Button ID="Btn_Inserir" class="btn btn-success" runat="server" type="submit" Text="Inserir" OnClick="Btn_Inserir_Click" />
                    <asp:Button ID="Btn_Atualizar" class="btn btn-danger" runat="server" type="submit" Text="Atualizar" OnClick="Btn_Atualizar_Click" />
                </div>
            </div>
        </form>
        <br />
        <table class="table table-hover" id="tcount">
            <thead>
                <tr>
                    <th scope="col">ID</th>
                    <th scope="col">Produto</th>
                </tr>
            </thead>
            <tbody>

                <asp:Repeater ID="Dados" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td> <%# Eval("id") %></td>
                            <td ><%# Eval("nome") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </tbody>
        </table>
    </div>
</asp:Content>