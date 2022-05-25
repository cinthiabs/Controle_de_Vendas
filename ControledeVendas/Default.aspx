<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ControledeVendas._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <style>
       .row{
           padding-top: 10px;
           padding-bottom: 30px;
           margin-bottom: 30px;
           margin-left:50px;
       }
 .main{
    /*margin: auto;*/ /*centralizado*/
}
.content-section{
    width:100%;
    background-color: white;
    padding: 2px;
    margin-bottom: 10px;  
    overflow: auto;/*foi adicionado por causa do float no card*/
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
/*   background:#D3D3D3;*/
}
.Detalhe-Content{
   width:100%;
   overflow: auto;/*foi adicionado por causa do float no card*/
}
 .combo {
      text-align: right;
 }
 .Mode{
     display: flex;
      align-items: center;
      justify-content: space-between;
      left:80%;
 }
 .Mode label{
     padding-top:10px;
     padding-right:10px;
 }
 .legenda{
     font-weight:bold;
     font-size:15px;
     color:white;
     text-align: right;
     padding-right:10px;
     background-color:mediumaquamarine;
 }

   </style>
    <div class="row">
        <div class="form-group col-md-2 col-sm-2 col-xs-2 Mode">
         <label for="txtFiltro">Filtro:  </label>
         <asp:DropDownList ID="DropRelatorio" runat="server" BackColor="White" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="DropRelatorio_SelectedIndexChanged">
           </asp:DropDownList>
        </div>
        
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
                <p>PENDÊNCIAS</p>
            </div>   
        </section>

        <div class="Detalhe-Content">
            <div class="cardDetalhe detalhe1">
                <table class="table table-striped">
                     <caption class="bg-info legenda">Vendas</caption>
                <thead>
                    <tr>  
                        <th scope="col" style="width: 9%;" class="bg-info">ID</th>
                        <th scope="col" style="width: 30%;" class="bg-info">Data</th>
                        <th scope="col" style="width: 18%;"class="bg-info">Produto</th>
                        <th scope="col" style="width: 10%;"class="bg-info">Cliente</th>
                        <th scope="col" style="width: 2%;"class="bg-info">Quantidade</th>
                        <th scope="col" style="width: 25%;"class="bg-info">Valor</th>
                        <th scope="col" style="width: 10%;"class="bg-info">Pago</th>
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
                      <caption class="bg-info legenda">Compras</caption>
                    <thead>
                        <tr>
                            <th scope="col" style="width: 10%;"class="bg-info">ID</th>
                            <th scope="col"style="width: 30%;"class="bg-info">Data</th>
                            <th scope="col"style="width: 8%;"class="bg-info">Quantidade</th>
                            <th scope="col"style="width: 20%;"class="bg-info">Produto</th>
                            <th scope="col"style="width: 15%;"class="bg-info">Unitário</th>
                            <th scope="col"style="width: 15%;"class="bg-info">Total</th>
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
