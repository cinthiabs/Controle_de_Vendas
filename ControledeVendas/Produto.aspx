<%@ Page Language="C#" Title="Produto" EnableEventValidation="false"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Produto.aspx.cs" Inherits="ControledeVendas.Produto" %>



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
    <asp:Panel runat="server" ID="PanelPrincipal">

        <form action="">
            <div class="containerTable">

                <div class="form-group col-md-12 col-sm-12 col-xs-12">
                    <label for="txtProduto">Consulta Produto:</label>
                    <input type="text" class="form-control" id="txtProduto" runat="server">
                    <br />
                      <asp:Button ID="Btn_Consultar" class="btn btn-primary" runat="server" Text="Consultar" OnClick="Btn_Consultar_Click" />
                </div>

                <br />
                <div class="form-group col-md-13 combo">
                    <asp:Button ID="Btn_Inserir" class="btn btn-success" runat="server" Text="Adicionar Novo" OnClick="Btn_Adicionar_Click" />
                
                </div>
            </div>
        </form>
        <br />
        <table class="table table-hover" id="tcount">
            <thead>
                <tr>
                    <th scope="col"style="width:10%;">ID</th>
                    <th scope="col" style="width:70%;">Produto</th>
                    <th scope="col" id="botaoN" runat="server"><%# Eval("id") %></th>
                  
                </tr>
            </thead>
            <tbody>

                <asp:Repeater ID="Dados" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("id") %></td>
                            <td><%# Eval("nome") %></td>
                            <td ID="botao" runat="server">
                                <asp:Button ID="Editar" class="btn btn-primary" runat="server" Text="Editar" OnClick="Btn_Editar_Click" />
                                <asp:Button ID="Excluir" class="btn btn-danger" runat="server" Text="Excluir" OnClientClick="javascript:return pergunta();" OnClick="Btn_Excluir_Click" />
                            </td>

                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </tbody>
        </table>
    </div>
    </asp:Panel>

    <asp:Panel runat="server" ID="PanelSegundo">
         <form action="">
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


        <div style="display:none">
      <input type="text" id="txt" runat="server">
      <label id="LblRecebe" runat="server"></label>
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

