<%@ Page Language="C#" Title="Vendas" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Vendas.aspx.cs" Inherits="ControledeVendas.Vendas" %>



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
    </style>
    <div class="row">
        <h3><%: Title %></h3>

        <form action="">
            <div class="containerTable">
                <div class="form-group col-md-4">
                    <label for="txtData">Data:</label>
                    <input type="datetime-local" class="form-control" id="txtData" runat="server">
                </div>
                <div class="form-group col-md-4">
                    <label for="txtProduto">Produto:</label>
                    <select id="txtProduto" class="form-control">
                        <option selected>Escolher...</option>
                    </select>
                </div>
                <div class="form-group col-md-4">
                    <label for="txtCliente">Cliente:</label>
                    <input type="text" class="form-control" id="txtCliente" runat="server">
                </div>
                <div class="form-group col-md-4">
                    <label for="txtQuantidade">Quantidade:</label>
                    <input type="text" class="form-control" id="txtQuantidade" runat="server">
                </div>
                <div class="form-group col-md-4">
                    <label for="txtValor">Valor:</label>
                    <input type="number" class="form-control" id="txtValor" runat="server">
                </div>
                <div class="form-group col-md-4">
                    
                    <label for="txtPago">Pago:</label>
                    <select id="txtPago" class="form-control">
                        <option value="0">Escolher...</option>
                         <option value=""></option>
                    </select>
                </div>
                <br />

                <div class="form-group col-md-12 combo">
                    <asp:Button ID="Btn_Atualizar" class="btn btn-primary" runat="server" Text="Atualizar" />
                    <asp:Button ID="Btn_inserir" class="btn btn-success" runat="server" type="submit" Text="Inserir" OnClick="Btn_inserir_Click" />
                    <asp:Button ID="Btn_Excluir" class="btn btn-danger" runat="server" type="submit" Text="Excluir" OnClick="Btn_Excluir_Click" />
                </div>

            </div>

        </form>
        <br />
        <div class="form-group col-md-12 col-sm-12 col-xs-12">
            <label for="txtid">Consultar ID:</label>
            <input type="number" class="form-control" id="txtid" runat="server" style="width: 100%">
            <br />
            <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="Consultar" OnClick="Btn_Consultar_Click" />
        </div>

        <table class="table table-hover">
            <thead>
                <tr>
                    <th scope="col">Data</th>
                    <th scope="col">Produto</th>
                    <th scope="col">Cliente</th>
                    <th scope="col">Quantidade</th>
                    <th scope="col">Valor</th>
                    <th scope="col">Pago</th>
                    <th scope="col"></th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td id="Data" runat="server"></td>
                    <td id="Quantidade" runat="server"></td>
                    <td id="Produto" runat="server"></td>
                    <td id="Cliente" runat="server"></td>
                    <td id="PrecoUni" runat="server"></td>
                    <td id="PrecoTotal" runat="server"></td>
                    <td id="botao" runat="server">
                        <asp:Button ID="Button2" class="btn btn-primary" runat="server" type="submit" Text="Editar" OnClick="Button2_Click" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>

</asp:Content>
