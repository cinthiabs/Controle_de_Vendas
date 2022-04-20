<%@ Page Language="C#" Title="Compras" EnableEventValidation="false"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Compras.aspx.cs" Inherits="ControledeVendas.Compras" %>

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
        <asp:Panel runat="server" ID="PanelSegundo">
            <form>
                <div class="containerTable">
                    <div class="form-group col-md-4">
                        <label for="txtData">Data:</label>
                        <input type="date" class="form-control" id="txtData" runat="server">
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
                       <asp:Button ID="Adicionar" class="btn btn-success" runat="server" type="submit" Text="Adicionar" OnClick="Btn_Inserir_Click" />
                       <asp:Button ID="Btn_Atualizar" class="btn btn-success" runat="server" Text="Atualizar" OnClick="Btn_Atualizar_Click" />
                   </div>
                </div>
            </form>
          <br />
       </asp:Panel>

        <asp:Panel runat="server" ID="PanelPrincipal">
          <form>
                <div class="form-group col-md-11 col-sm-11 col-xs-11 input-group">
                    <input type="number" class="form-control" id="txtid" placeholder="Codigo da Compra" runat="server" style="width: 100%">
                    <div class="input-group-btn">
                        <asp:Button ID="Consultar" class="btn btn-primary" runat="server" Text="Consultar" OnClick="Btn_Consultar_Click" />
                    </div>
                </div>
           </form>
            <br />
                <table class="table table-hover">
                    <thead>
                        <tr>
                            <th scope="col" style="width: 10%;">ID</th>
                            <th scope="col"style="width: 20%;">Data</th>
                            <th scope="col"style="width: 10%;">Quantidade</th>
                            <th scope="col"style="width: 20%;">Produto</th>
                            <th scope="col"style="width: 10%;">Preço Unitário</th>
                            <th scope="col"style="width: 10%;">Preço Total</th>
                            <th scope="col" style="width:60%;"></th>
                        </tr>
                    </thead>
                    <tbody>
                      <asp:Repeater ID="Dados" runat="server">
                          <ItemTemplate>
                        <tr>
                            <td><%# Eval("id") %></td>
                            <td><%# Eval("Data") %></td>
                            <td><%# Eval("Quant") %></td>
                            <td><%# Eval("Produto") %></td>
                            <td><%# Eval("PrecoUnt") %></td>
                            <td><%# Eval("PrecoTotal") %></td>
                            <td id="botao" runat="server">
                                <asp:Button ID="Editar" class="btn btn-primary" runat="server" Text="Editar" OnClick="Btn_Editar_Click" />
                                <asp:Button ID="Excluir" class="btn btn-danger" runat="server" Text="Excluir" OnClientClick="javascript:return pergunta();" OnClick="Btn_Excluir_Click" />
                            </td>
                        </tr>
                       </ItemTemplate>
                    </asp:Repeater>
                    </tbody>
                </table>
            <div class="form-group col-md-12 col-sm-11 col-xs-11 combo">
                <asp:Button ID="Btn_Inserir" class="btn btn-success" runat="server" Text="Adicionar Novo" OnClick="Btn_Adicionar_Click" />
            </div>
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
