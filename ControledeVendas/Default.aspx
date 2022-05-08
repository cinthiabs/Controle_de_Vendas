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
.CardDetalhe{

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

            </div>

            <div class="cardDetalhe detalhe2">

            </div>

        </div>
    </div>


</asp:Content>
