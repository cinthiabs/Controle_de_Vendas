<%@ Page Language="C#" Title="Produtos" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Produtos.aspx.cs" Inherits="ControledeVendas.Produtos" %>

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
                    <label for="txtQuantidade">Quantidade:</label>
                    <input type="text" class="form-control" id="txtQuantidade" runat="server">
                </div>

                <div class="form-group col-md-4">
                    <label for="txtProduto">Produto:</label>
                    <input type="text" class="form-control" id="txtProduto" runat="server">
                </div>
                <div class="form-group col-md-4">
                    <label for="txtPrecoUni">Preço Unitário:</label>
                    <input type="text" class="form-control" id="txtPrecoUni" runat="server">
                </div>

                <div class="form-group col-md-4">
                    <label for="txtPrecoTotal">Preço Total:</label>
                    <input type="text" class="form-control" id="txtPrecoTotal" runat="server">
                </div>

                <br />
                <div class="form-group col-md-12 combo">
                    <asp:Button ID="Btn_Atualizar" class="btn btn-primary" runat="server" Text="Atualizar" OnClick="Btn_Atualizar_Click" />
                    <asp:Button ID="Btn_Inserir" class="btn btn-success" runat="server" type="submit" Text="Inserir" OnClick="Btn_Inserir_Click" />
                    <asp:Button ID="Btn_Excluir" class="btn btn-danger" runat="server" type="submit" Text="Excluir" />
                </div>
            </div>
        </form>
        <br />

          <div class="form-group col-md-12 col-sm-12 col-xs-12">
            <label for="txtid">Codigo do Produto:</label>
            <input type="number" class="form-control" id="txtid" runat="server" style="width: 100%">
            <br />
            <asp:Button ID="Consultar" class="btn btn-primary" runat="server" Text="Consultar" OnClick="Btn_Consultar_Click" />
        </div>


        <table class="table table-hover">
            <thead>
                <tr>
                    <th scope="col">ID</th>
                    <th scope="col">Data</th>
                    <th scope="col">Quantidade</th>
                    <th scope="col">Produto</th>
                    <th scope="col">Preço Unitário</th>
                    <th scope="col">Preço Total</th>
                    <th scope="col"></th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td id="Id" runat="server"></td>
                    <td id="Data" runat="server"></td>
                    <td id="Quantidade" runat="server"></td>
                    <td id="Produto" runat="server"></td>
                    <td id="PrecoUni" runat="server"></td>
                    <td id="PrecoTotal" runat="server"></td>
                    <td id="botao" runat="server">
                        <asp:Button ID="Editar" class="btn btn-primary" runat="server" type="submit" Text="Editar" OnClick="Editar_Click" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>

</asp:Content>
