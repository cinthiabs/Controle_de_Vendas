<%@ Page Language="C#" Title="Categorias"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="ControledeVendas.Categorias" %>

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
                    <label for="txtid">ID:</label>
                    <input type="number" class="form-control" id="txtid" runat="server">
                </div>

                <div class="form-group col-md-4">
                    <label for="txtProduto">Produto:</label>
                       <input type="text" class="form-control" id="txtProduto" runat="server">
                </div>

                <br />
                <div class="form-group col-md-12 combo">
                    <asp:Button ID="Btn_Consultar" class="btn btn-primary" runat="server" Text="Inserir" />
                    <asp:Button ID="Btn_Ativar" class="btn btn-success" runat="server" type="submit" Text="Consultar" />
                    <asp:Button ID="Btn_Excluir" class="btn btn-danger" runat="server" type="submit" Text="Excluir                                                                                  " />
                </div>
            </div>
        </form>
        <br />
        <table class="table table-hover">
            <thead>
                <tr>
                    <th scope="col">ID</th>
                    <th scope="col">Produto</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td id="id" runat="server"></td>
                    <td id="Produto" runat="server"></td>
                </tr>
            </tbody>
        </table>
    </div>
</asp:Content>
