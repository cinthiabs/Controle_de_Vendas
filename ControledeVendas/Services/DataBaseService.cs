using ControledeVendas.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControledeVendas.Services
{

    public class DataBaseService
    {
        private static string conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
      

        public static Entidades.Produtos ConsultaProduto(Entidades.Produtos prod)
        {
            using (SqlConnection connection = new SqlConnection(conn)) 
            {
                Entidades.Produtos produtos = new Entidades.Produtos();
                 var query = @" select * from Categoria where ID ="+ prod.id+"";
                connection.Open();
                
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    DataTable dtLista = new DataTable();
                    SqlDataAdapter sqlData = new SqlDataAdapter(command);
                    sqlData.Fill(dtLista);
                                    
                    if (dtLista.Rows.Count > 0)
                    {
                        produtos.id = Convert.ToInt32(dtLista.Rows[0]["id"].ToString());
                        produtos.produto = dtLista.Rows[0]["nome"].ToString();
                    }
                    return produtos;

                }
                catch (Exception e)
                {
                    throw new ArgumentException(e.Message);
                  
                }
            }

        }
        public static DataTable ExcluirProduto(int id)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                Entidades.Produtos produtos = new Entidades.Produtos();
                var query = @" delete from Categoria where id =" + id + "";
                connection.Open();

                try
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    DataTable dtLista = new DataTable();
                    SqlDataAdapter sqlData = new SqlDataAdapter(command);
                    sqlData.Fill(dtLista);
                    
                    return dtLista;
                }
                catch (Exception e)
                {
                    throw new ArgumentException(e.Message);

                }
            }

        }
        public static DataTable ConsultaProd(string produto)
        {

            DataTable dtLista = new DataTable();
            using (SqlConnection connection = new SqlConnection(conn))
            {

                var query = @" select * from Categoria where ID =" + produto + "";
                connection.Open();

                try
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataAdapter sqlData = new SqlDataAdapter(command);
                    sqlData.Fill(dtLista);
                    return dtLista;
                }
                catch (Exception e)
                {
                    throw new ArgumentException(e.Message);

                }
            }

        }
        public static DataTable ConsultaTable()
        {

            DataTable dtLista = new DataTable();
            using (SqlConnection connection = new SqlConnection(conn))
            {
                string query = "SELECT * FROM Categoria";
                connection.Open();

                try
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataAdapter sqlData = new SqlDataAdapter(command);
                    sqlData.Fill(dtLista);
                    return dtLista;
                }
                catch (Exception e)
                {
                    throw new ArgumentException(e.Message);
              
                }
            }

        }
        public static bool AtualizarProd(Entidades.Produtos prod)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                Entidades.Produtos produto = new Entidades.Produtos();

                var query = @"update categoria set nome='" + prod.produto + "' where id="+ prod.id+ "";
                connection.Open();

                try
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    DataTable dtLista = new DataTable();
                    SqlDataAdapter sqlData = new SqlDataAdapter(command);
                    sqlData.Fill(dtLista);

                    if (dtLista.Rows.Count >= 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception e)
                {
                    throw new ArgumentException(e.Message);

                }
            }

        }

        public static bool InsertProduto(Entidades.Produtos prod)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                Entidades.Produtos produtos = new Entidades.Produtos();
                var query = @"insert into Categoria (nome)values('"+ prod.produto + "')";
                connection.Open();

                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter sqlData = new SqlDataAdapter(command);

                    DataTable dtLista = new DataTable();
                    sqlData.Fill(dtLista);


                    if (dtLista.Rows.Count >= 0)
                    {

                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch (Exception e)
                {
                    throw new ArgumentException(e.Message);

                }
            }
        }

        public static Entidades.Compras ConsultaCompras(Entidades.Compras comp)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                Entidades.Compras compra = new Entidades.Compras();
                var query = @"select * from Produto where id = "+ comp.id;
                connection.Open();

                try
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    DataTable dtLista = new DataTable();
                    SqlDataAdapter sqlData = new SqlDataAdapter(command);
                    sqlData.Fill(dtLista);

                    if (dtLista.Rows.Count >= 0)
                    {
                        compra.id = Convert.ToInt32(dtLista.Rows[0]["id"].ToString());
                        compra.Data =Convert.ToDateTime(dtLista.Rows[0]["data"]);
                        compra.produto = dtLista.Rows[0]["produto"].ToString();
                        compra.Quant = dtLista.Rows[0]["quant"].ToString();
                        compra.precoUnt = dtLista.Rows[0]["precoUnt"].ToString();
                        compra.precoTotal = dtLista.Rows[0]["precoTotal"].ToString();
                    }
                    return compra;

                }
                catch (Exception e)
                {
                    throw new ArgumentException(e.Message);

                }
            }
        }

        public static bool InsertCompras(Entidades.Compras comp)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                Entidades.Compras compra = new Entidades.Compras();
               
                string data = comp.Data.ToString("yyyy-dd-MM");
                var precoTotal = comp.precoTotal;
                var precoUnt = comp.precoUnt;
                precoTotal = precoTotal.Replace(',', '.');
                precoUnt = precoUnt.Replace(',', '.');


                var query = @"insert into Produto(data, produto, Quant,precoUnt,precoTotal)values('"+ data + "','" + comp.produto + "','" + comp.Quant + "'," + precoUnt + "," + precoTotal + ")";
                connection.Open();

                try
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    DataTable dtLista = new DataTable();
                    SqlDataAdapter sqlData = new SqlDataAdapter(command);
                    sqlData.Fill(dtLista);

                    if (dtLista.Rows.Count >= 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;

                    }

                }
                catch (Exception e)
                {
                    throw new ArgumentException(e.Message);

                }
            }
        }
        
        public static bool ExcluirCompra(Entidades.Compras comp)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                Entidades.Produtos produtos = new Entidades.Produtos();
                var query = @" delete from Produto where id =" + comp.id + "";
                connection.Open();

                try
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    DataTable dtLista = new DataTable();
                    SqlDataAdapter sqlData = new SqlDataAdapter(command);
                    sqlData.Fill(dtLista);

                    if (dtLista.Rows.Count >= 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;

                    }
                }
                catch (Exception e)
                {
                    throw new ArgumentException(e.Message);

                }
            }
        }

        public static bool AtualizaCompras(Entidades.Compras comp)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                var precoTotal = comp.precoTotal;
                var precoUnt = comp.precoUnt;
                precoTotal = precoTotal.Replace(',', '.');
                precoUnt = precoUnt.Replace(',', '.');
                string data = comp.Data.ToString("yyyy-dd-MM");
                string GetData = DateTime.Now.ToString("yyyy-dd-MM");

                Entidades.Compras compra = new Entidades.Compras();

                var query = @"update Produto set data='"+data +"', produto='"+ comp.produto+"', Quant='"+ comp.Quant+"',precoUnt="+precoUnt+",precoTotal="+precoTotal+", DataAlteracao='"+GetData + "' where id = "+ comp.id+"";
                connection.Open();

                try
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    DataTable dtLista = new DataTable();
                    SqlDataAdapter sqlData = new SqlDataAdapter(command);
                    sqlData.Fill(dtLista);

                    if (dtLista.Rows.Count >= 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;

                    }

                }
                catch (Exception e)
                {
                    throw new ArgumentException(e.Message);
                }
            }
        }
        //public static bool AtualizaVendas(Entidades.Vendas vend)
        //{
        //    using (SqlConnection connection = new SqlConnection(conn))
        //    {
        //        var precoTotal = vend.precoTotal;
        //        precoTotal = precoTotal.Replace(',', '.');
        //        string data = vend.Data.ToString("yyyy-dd-MM");
        //        string GetData = DateTime.Now.ToString("yyyy-dd-MM");

        //        Entidades.Compras compra = new Entidades.Compras();

        //        var query = @"update vendas set data='" + data + "', produtoid='" + vend.produtoid + "', Quant='" + vend.Quant + "',precoTotal=" + precoTotal + ", pago = " + vend.Pago + " DataAlteracao='" + GetData + "' where id = " + vend.id + ""; connection.Open();

        //        try
        //        {
        //            SqlCommand command = new SqlCommand(query, connection);

        //            DataTable dtLista = new DataTable();
        //            SqlDataAdapter sqlData = new SqlDataAdapter(command);
        //            sqlData.Fill(dtLista);

        //            if (dtLista.Rows.Count >= 0)
        //            {
        //                return true;
        //            }
        //            else
        //            {
        //                return false;

        //            }

        //        }
        //        catch (Exception e)
        //        {
        //            throw new ArgumentException(e.Message);
        //        }
        //    }
        //}
        public static DataTable ConsultaCompra(string id)
        {

            DataTable dtLista = new DataTable();
            using (SqlConnection connection = new SqlConnection(conn))
            {
                var query = @"select * from Produto where id = " + id;
                connection.Open();

                try
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataAdapter sqlData = new SqlDataAdapter(command);
                    sqlData.Fill(dtLista);
                    return dtLista;
                }
                catch (Exception e)
                {
                    throw new ArgumentException(e.Message);

                }
            }

        }
        public static DataTable ConsultaTableCompra(int dias)
        {

            DataTable dtLista = new DataTable();
            using (SqlConnection connection = new SqlConnection(conn))
            {
                string query = "SELECT top 5 id,data,Produto,Quant,FORMAT(precoUnt , 'C') AS 'precoUnt',FORMAT(precoTotal , 'C') AS 'precoTotal' FROM Produto  where data >= getdate()-" + dias+" ORDER BY DATA DESC";
                connection.Open();

                try
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataAdapter sqlData = new SqlDataAdapter(command);
                    sqlData.Fill(dtLista);
                    return dtLista;
                }
                catch (Exception e)
                {
                    throw new ArgumentException(e.Message);

                }
            }

        }

        public static DataTable PesquisaValoresProduto()
        {
            DataTable dtLista = new DataTable();
            using (SqlConnection connection = new SqlConnection(conn))
            {
                string query = "SELECT * FROM Categoria";
                connection.Open();

                try
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataAdapter sqlData = new SqlDataAdapter(command);
                    sqlData.Fill(dtLista);
                    return dtLista;
                }
                catch (Exception e)
                {
                    throw new ArgumentException(e.Message);

                }
            }
        }
        public static DataTable PesquisaValoresPagamento()
        {
            DataTable dtLista = new DataTable();
            using (SqlConnection connection = new SqlConnection(conn))
            {
                string query = "SELECT * FROM pago";
                connection.Open();

                try
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataAdapter sqlData = new SqlDataAdapter(command);
                    sqlData.Fill(dtLista);
                    return dtLista;
                }
                catch (Exception e)
                {
                    throw new ArgumentException(e.Message);

                }
            }
        }
        public static DataTable ConsultaVenda(string id)
        {
            DataTable dtLista = new DataTable();
            using (SqlConnection connection = new SqlConnection(conn))
            {
                string query = "SELECT  v.id,data,c.Nome, Cliente,Quant,FORMAT(precoTotal , 'C') AS 'precoTotal',p.descricao FROM Vendas v";
                query += " inner join Categoria c on v.Produtoid = c.id ";
                query += " inner join pago p on v.Pago = p.id  where v.id = " + id;
                //var query = @"select * from vendas where id = " +id;
                connection.Open();

                try
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataAdapter sqlData = new SqlDataAdapter(command);
                    sqlData.Fill(dtLista);
                    return dtLista;

                }
                catch (Exception e)
                {
                    throw new ArgumentException(e.Message);

                }
            }
        }
        public static Entidades.Vendas ConsultaVendas(Entidades.Vendas vend)
        {
            Entidades.Vendas vendas = new Entidades.Vendas();
            DataTable dtLista = new DataTable();
            using (SqlConnection connection = new SqlConnection(conn))
            {
                var query = @"select * from vendas where id = " + vend.id;
                connection.Open();

                try
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataAdapter sqlData = new SqlDataAdapter(command);
                    sqlData.Fill(dtLista);
                    if (dtLista.Rows.Count >= 0)
                    {
                        vendas.id = Convert.ToInt32(dtLista.Rows[0]["id"].ToString());
                        vendas.Data = Convert.ToDateTime(dtLista.Rows[0]["data"]);
                        vendas.produtoid = Convert.ToInt32(dtLista.Rows[0]["produtoid"].ToString());
                        vendas.Quant = dtLista.Rows[0]["quant"].ToString();
                        vendas.precoTotal = dtLista.Rows[0]["precoTotal"].ToString();
                        vendas.Pago = Convert.ToInt32(dtLista.Rows[0]["pago"].ToString());
                        return vendas;
                    }
                    return vendas;


                }
                catch (Exception e)
                {
                    throw new ArgumentException(e.Message);

                }
            }
        }
        public static bool AtualizaVendas(Entidades.Vendas vend)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                string data = vend.Data.ToString("yyyy-dd-MM");
                var precoTotal = vend.precoTotal;
                precoTotal = precoTotal.Replace(',', '.');
                string GetData = DateTime.Now.ToString("yyyy-dd-MM");

                var query = @"update Vendas set data='" + data + "', Cliente='" + vend.Cliente + "', produtoid=" + vend.produtoid + ", Quant='" + vend.Quant + "',precoTotal=" + precoTotal + ", DataAlteracao='" + GetData + "' where id = " + vend.id + "";
                connection.Open();

                try
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    DataTable dtLista = new DataTable();
                    SqlDataAdapter sqlData = new SqlDataAdapter(command);
                    sqlData.Fill(dtLista);

                    if (dtLista.Rows.Count >= 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;

                    }

                }
                catch (Exception e)
                {
                    throw new ArgumentException(e.Message);
                }
            }
        }
        public static bool ExcluirVendas(Entidades.Vendas vend)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                Entidades.Vendas vendas = new Entidades.Vendas();
                var query = @" delete from Vendas where id =" + vend.id + "";
                connection.Open();

                try
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    DataTable dtLista = new DataTable();
                    SqlDataAdapter sqlData = new SqlDataAdapter(command);
                    sqlData.Fill(dtLista);

                    if (dtLista.Rows.Count >= 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;

                    }
                }
                catch (Exception e)
                {
                    throw new ArgumentException(e.Message);

                }
            }
        }
        public static bool InsertVendas(Entidades.Vendas vend)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {

                string data = vend.Data.ToString("yyyy-dd-MM");
                var precoTotal = vend.precoTotal;
                precoTotal = precoTotal.Replace(',', '.');

                var query = @"insert into Vendas(data, produtoID, Cliente,Quant,precoTotal,pago)values('" + data + "'," + vend.produtoid + ",'" + vend.Cliente + "','" + vend.Quant + "'," + precoTotal + ","+vend.Pago+")";
                connection.Open();

                try
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    DataTable dtLista = new DataTable();
                    SqlDataAdapter sqlData = new SqlDataAdapter(command);
                    sqlData.Fill(dtLista);

                    if (dtLista.Rows.Count >= 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;

                    }

                }
                catch (Exception e)
                {
                    throw new ArgumentException(e.Message);

                }
            }
        }
        public static DataTable ConsultaTableVendas(int dias)
        {

            DataTable dtLista = new DataTable();
            using (SqlConnection connection = new SqlConnection(conn))
            {
                string query = "SELECT top 5 v.id,data,c.Nome, Cliente,Quant,FORMAT(precoTotal , 'C') AS 'precoTotal',p.descricao FROM Vendas v";
                query += " inner join Categoria c on v.Produtoid = c.id ";
                query += " inner join pago p on v.Pago = p.id  where data>=getdate()-"+dias+" ORDER BY DATA DESC";
                connection.Open();

                try
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataAdapter sqlData = new SqlDataAdapter(command);
                    sqlData.Fill(dtLista);
                    return dtLista;
                }
                catch (Exception e)
                {
                    throw new ArgumentException(e.Message);

                }
            }

        }
        public static DataTable RelatorioVendas(DateTime dataIni, DateTime dataFim)
        {
           
            string DataIni = dataIni.ToString("yyyy-dd-MM");
            string Datafim = dataFim.ToString("yyyy-dd-MM");

            DataTable dtLista = new DataTable();
            using (SqlConnection connection = new SqlConnection(conn))
            {
                var query = @"SPS_RELATORIOVENDAS '" + DataIni + "','"+ Datafim + "'";
                connection.Open();

                try
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataAdapter sqlData = new SqlDataAdapter(command);
                    sqlData.Fill(dtLista);
                    return dtLista;
                }
                catch (Exception e)
                {
                    throw new ArgumentException(e.Message);

                }
            }

        }

        public static DataTable RelatorioCompra(DateTime dataIni, DateTime dataFim)
        {

            string DataIni = dataIni.ToString("yyyy-dd-MM");
            string Datafim = dataFim.ToString("yyyy-dd-MM");

            DataTable dtLista = new DataTable();
            using (SqlConnection connection = new SqlConnection(conn))
            {
                var query = @"SELECT ID AS ID, Data, Produto, Quant AS Quantidade, precoUnt AS 'Preço Unitário', precoTotal as 'Preco Total'";
                    query += " FROM PRODUTO  WHERE Data BETWEEN'" + DataIni + "' AND '" + Datafim + "'";
                connection.Open();

                try
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataAdapter sqlData = new SqlDataAdapter(command);
                    sqlData.Fill(dtLista);
                    return dtLista;
                }
                catch (Exception e)
                {
                    throw new ArgumentException(e.Message);

                }
            }

        }
        public static Totais TotalPend(int dias)
        {
            DataTable dtLista = new DataTable();
            using (SqlConnection connection = new SqlConnection(conn))
            {
                Totais total = new Totais();

                var query = @"select count(pago) as TotalPend from vendas where pago <> 1 and data >=getdate() -" + dias + "";
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataAdapter sqlData = new SqlDataAdapter(command);
                    sqlData.Fill(dtLista);
                    if (dtLista.Rows.Count >= 0)
                    {
                        total.TotalPend = dtLista.Rows[0]["TotalPend"].ToString();
                        return total;
                    }
                    return total;
                }
                catch (Exception e)
                {
                    throw new ArgumentException(e.Message);

                }
            }

        }
        public static Totais TotalVed(int dias)
        {
            Totais total = new Totais();

            DataTable dtLista = new DataTable();
            using (SqlConnection connection = new SqlConnection(conn))
            {
                var query = @"declare @soma float";
                query += " set @soma = (select sum(precoTotal) from vendas where data >=getdate() -" + dias + ") ";
                query += " select FORMAT(@soma, 'C', 'pt-br') as total";
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataAdapter sqlData = new SqlDataAdapter(command);
                    sqlData.Fill(dtLista);
                    if (dtLista.Rows.Count >= 0)
                    {
                        total.TotalVed = dtLista.Rows[0]["total"].ToString();
                        return total;
                    }
                    return total;
                }
                catch (Exception e)
                {
                    throw new ArgumentException(e.Message);

                }
            }

        }
        public static Totais TotalPaes( int dias)
        {
            Totais total = new Totais();
            DataTable dtLista = new DataTable();
            using (SqlConnection connection = new SqlConnection(conn))
            {
                var query = @"select sum(quant)as quant from vendas where data >=getdate() -" + dias + "";
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataAdapter sqlData = new SqlDataAdapter(command);
                    sqlData.Fill(dtLista);
                    if (dtLista.Rows.Count >= 0)
                    {
                        total.TotalPaes = dtLista.Rows[0]["quant"].ToString();
                        return total;
                    }
                    return total;
                }
                catch (Exception e)
                {
                    throw new ArgumentException(e.Message);

                }
            }

        }
        public static Totais TotalCompras(int dias)
        {
            Totais total = new Totais();
            DataTable dtLista = new DataTable();
            using (SqlConnection connection = new SqlConnection(conn))
            {
                var query = @"declare @soma float";
                query += " set @soma = (select sum(precoTotal) from produto where data >=getdate() -"+dias+") ";
                query += " select FORMAT(@soma, 'C', 'pt-br') as total";
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataAdapter sqlData = new SqlDataAdapter(command);
                    sqlData.Fill(dtLista);
                    if (dtLista.Rows.Count >= 0)
                    {
                        total.TotalCompras = dtLista.Rows[0]["total"].ToString();
                        return total;
                    }
                    return total;
                }
                catch (Exception e)
                {
                    throw new ArgumentException(e.Message);                    
                }
            }

        }
    }
   
}