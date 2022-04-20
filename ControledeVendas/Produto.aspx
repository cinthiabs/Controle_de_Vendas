<%@ Page Language="C#" Title="Produto" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Produto.aspx.cs" Inherits="ControledeVendas.Produto" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <script src="https://code.jquery.com/jquery-3.1.1.js"></script>
	<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
	<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.quicksearch/2.3.1/jquery.quicksearch.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script>
        $('input#txtProduto').quicksearch('table#tcount tbody tr');
    </script>
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
        <asp:Panel runat="server" ID="PanelPrincipal">

            <form>
                <div class="containerTable">

                    <div class="form-group col-md-11 col-sm-11 col-xs-11 input-group">
                        <input type="text" class="form-control" placeholder="Consulta Produto" id="txtProduto" runat="server">
                        <div class="input-group-btn">
                            <asp:Button ID="Btn_Consultar" class="btn btn-primary" runat="server" Text="Consultar" OnClick="Btn_Consultar_Click" />
                        </div>
                    </div>
                </div>
            </form>
            <br />
            <table class="table table-hover" id="tcount">
                <thead>
                    <tr>
                        <th scope="col" style="width: 10%;">ID</th>
                        <th scope="col" style="width: 70%;">Produto</th>
                        <th scope="col" id="botaoN" runat="server"><%# Eval("id") %></th>

                    </tr>
                </thead>
                <tbody>

                    <asp:Repeater ID="Dados" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("id") %></td>
                                <td><%# Eval("nome") %></td>
                                <td id="botao" runat="server">
                                    <asp:Button ID="Editar" class="btn btn-primary" runat="server" Text="Editar" OnClick="Btn_Editar_Click" />
                                    <asp:Button ID="Excluir" class="btn btn-danger" runat="server" Text="Excluir" OnClientClick="javascript:return pergunta();" OnClick="Btn_Excluir_Click" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
            <br />
         <div class="form-group col-md-12 col-sm-11 col-xs-12 combo">
           <asp:Button ID="Btn_Inserir" class="btn btn-success" runat="server" Text="Adicionar Novo" OnClick="Btn_Adicionar_Click" />
         </div>
    </asp:Panel>

    <asp:Panel runat="server" ID="PanelSegundo">
        <form>
            <div class="containerTable">

                <div class="form-group col-md-4">
                    <label for="txtid">ID:</label>
                    <input type="number" class="form-control" id="txtid" runat="server" disabled="">
                </div>

                <div class="form-group col-md-4">
                    <label for="inputProduto">Produto:</label>
                    <input type="text" class="form-control" id="inputProduto" runat="server">
                </div>
                <br />
                <div class="form-group col-md-12 combo">
                    <asp:Button ID="Adicionar" class="btn btn-success" runat="server" type="submit" Text="Adicionar" OnClick="Btn_Inserir_Click" />
                    <asp:Button ID="Btn_Atualizar" class="btn btn-success" runat="server" Text="Atualizar" OnClick="Btn_Atualizar_Click" />
                </div>
            </div>
        </form>
    </asp:Panel>
  </div>
    <script>

        function pergunta() {
            if (confirm("Deseja realmente excluir?")) {

                return true;

            } else {

                return false;

            }
        }

    </script>
</asp:Content>

