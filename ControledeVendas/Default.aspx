<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ControledeVendas._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <style>
       .row{
           padding-top: 50px;
           padding-bottom: 30px;
           margin-bottom: 30px;
           margin-left:40px;
       }
 .main{
    /*margin: auto;*/ /*centralizado*/
}
.content-section{
    width:100%;
    background-color: white;
    padding: 5px;
    margin-bottom: 10px;  
    overflow: auto;/*foi adicionado por causa do float no cart*/
}
.card{
    width:23%;
   float: left;/*deixar imagen do lado da outra*/
   margin: 6px;
   padding: 40px 0 0 0;
   background:#aea6f3;
}
.cardcolor{
    background:#DC3545;
}
.cardcolor1{
    background:#28A745;
}
.cardcolor2{
    background:#FFC107;
}
.cardcolor3{
    background:#007BFF;
}
.card h3{
    width: 100%;
    align-items:center;
    display: block;
    color:white;
    text-align:center;
    font-weight:600;
    font-size:35px;
    padding-bottom: 20px;

}
.card p{
    margin: 0;
    background-color:#808080;
    color: white;
    padding: 10px;
    text-transform: uppercase;
    text-align:center;
}
.cardDetalhe{
   width:47%;
   float: left;/*deixar imagen do lado da outra*/
   margin-left: 10px;
   padding: 20px;
/**/   /*background:#e3e1fa;*/
}
.Detalhe-Content{
   width:100%;
/*    background-color: white;*/
/*    padding: 5px;
*/    /*margin-bottom: 10px;*/  
    overflow: auto;/*foi adicionado por causa do float no cart*/
}

   </style>
    <div class="row">
        <section class="content-section">
            <div class="card cardcolor2">
               <h3 id="TotalCompras" runat="server"></h3>
                <p>TOTAL DE COMPRAS</p>
            </div>

            <div class="card cardcolor1">
               <h3 id="TotalVed" runat="server"></h3>
                <p>TOTAL DE VENDAS</p>
            </div>
            <div class="card cardcolor3">
               <h3 id="TotalPaes" runat="server"></h3>
                <p>QUANT. PÃES</p>
            </div>
             <div class="card cardcolor">
               <h3 id="TotalPend" runat="server"></h3>
                <p>PENDENCIAS</p>
            </div>   
        </section>

        <div class="Detalhe-Content">
            <div class="cardDetalhe detalhe1">
                <table class="table table-striped">
                <thead>
                    <tr>
                        <th scope="col" style="width: 9%;">ID</th>
                        <th scope="col" style="width: 35%;">Data</th>
                        <th scope="col" style="width: 20%;">Produto</th>
                        <th scope="col" style="width: 18%;">Cliente</th>
                        <th scope="col" style="width: 9%;">Quantidade</th>
                        <th scope="col" style="width: 10%;">Valor</th>
                        <th scope="col" style="width: 10%;">Pago</th>
                        <th scope="col" style="width: 50%;"></th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="Dados" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("id") %></td>
                                <td><%# Eval("Data") %></td>
                                <td><%# Eval("nome") %></td>
                                <td><%# Eval("Cliente") %></td>
                                <td><%# Eval("Quant") %></td>
                                <td><%# Eval("PrecoTotal") %></td>
                                <td><%# Eval("descricao") %></td>
                           </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
            </div>

            <div class="cardDetalhe detalhe2">
                 <table class="table table-striped">
                    <thead>
                        <tr>
                            <th scope="col" style="width: 10%;">ID</th>
                            <th scope="col"style="width: 30%;">Data</th>
                            <th scope="col"style="width: 10%;">Quantidade</th>
                            <th scope="col"style="width: 32%;">Produto</th>
                            <th scope="col"style="width: 10%;">Unitário</th>
                            <th scope="col"style="width: 10%;">Total</th>
                            <th scope="col" style="width:60%;"></th>
                        </tr>
                    </thead>
                    <tbody>
                      <asp:Repeater ID="DadosCompra" runat="server">
                          <ItemTemplate>
                        <tr>
                            <td><%# Eval("id") %></td>
                            <td><%# Eval("Data") %></td>
                            <td><%# Eval("Quant") %></td>
                            <td><%# Eval("Produto") %></td>
                            <td><%# Eval("PrecoUnt") %></td>
                            <td><%# Eval("PrecoTotal") %></td>
                        </tr>
                       </ItemTemplate>
                    </asp:Repeater>
                    </tbody>
                </table>
            </div>

        </div>
    </div>


</asp:Content>
