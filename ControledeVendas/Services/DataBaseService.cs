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
      

        public static  Categoria ConsultaCategoria(Categoria categoria)
        {
            using (SqlConnection connection = new SqlConnection(conn)) 
            {
                Categoria cat = new Categoria();
                 var query = @" select * from Categoria where Nome ='"+categoria.produto+"'";
                connection.Open();
                
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    DataTable dtLista = new DataTable();
                    SqlDataAdapter sqlData = new SqlDataAdapter(command);
                    sqlData.Fill(dtLista);
                                    
                    if (dtLista.Rows.Count > 0)
                    {
                        cat.id = Convert.ToInt32(dtLista.Rows[0]["id"].ToString());
                        cat.produto = dtLista.Rows[0]["nome"].ToString();
                    }
                    return cat;

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
        public static Categoria InsertCategoria(Categoria categoria)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                Categoria cat = new Categoria();
                var query = @" insert into Categoria (nome)values('"+categoria.produto + "')";
                connection.Open();

                try
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    DataTable dtLista = new DataTable();
                    SqlDataAdapter sqlData = new SqlDataAdapter(command);
                    sqlData.Fill(dtLista);

                    if (dtLista.Rows.Count >= 0)
                    {
                        cat.id = Convert.ToInt32(dtLista.Rows[0]["id"].ToString());
                        cat.produto = dtLista.Rows[0]["nome"].ToString();
                    }
                    return cat;

                }
                catch (Exception e)
                {
                    throw new ArgumentException(e.Message);

                }
            }
        }

        public static Produto ConsultaProduto(Produto prod)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                Produto produto = new Produto();
                var query = @"select * from Produto where id = "+ prod.id;
                connection.Open();

                try
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    DataTable dtLista = new DataTable();
                    SqlDataAdapter sqlData = new SqlDataAdapter(command);
                    sqlData.Fill(dtLista);

                    if (dtLista.Rows.Count >= 0)
                    {
                        produto.id = Convert.ToInt32(dtLista.Rows[0]["id"].ToString());
                        produto.Data =Convert.ToDateTime(dtLista.Rows[0]["data"]);
                        produto.produto = dtLista.Rows[0]["produto"].ToString();
                        produto.Quant = dtLista.Rows[0]["quant"].ToString();
                        produto.precoUnt = dtLista.Rows[0]["precoUnt"].ToString();
                        produto.precoTotal = dtLista.Rows[0]["precoTotal"].ToString();
                    }
                    return produto;

                }
                catch (Exception e)
                {
                    throw new ArgumentException(e.Message);

                }
            }
        }
        public static Produto InsertProduto(Produto prod)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                Produto produto = new Produto();
                var query = @"insert into Produto(data, produto, Quant,precoUnt,precoTotal)values('"+ prod.Data.ToString("yyyy-dd-mm hh:mm:ss") + "','" + prod.produto + "','" + prod.Quant + "'," + prod.precoUnt + "," + prod.precoTotal + ")";
                connection.Open();

                try
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    DataTable dtLista = new DataTable();
                    SqlDataAdapter sqlData = new SqlDataAdapter(command);
                    sqlData.Fill(dtLista);

                    if (dtLista.Rows.Count >= 0)
                    {
                        produto.id = Convert.ToInt32(dtLista.Rows[0]["id"].ToString());
                        produto.Data = Convert.ToDateTime(dtLista.Rows[0]["data"].ToString());
                        produto.produto = dtLista.Rows[0]["produto"].ToString();
                        produto.Quant = dtLista.Rows[0]["quant"].ToString();
                        produto.precoUnt = dtLista.Rows[0]["precoUnt"].ToString();
                        produto.precoTotal = dtLista.Rows[0]["precoTotal"].ToString();



                    }
                    return produto;

                }
                catch (Exception e)
                {
                    throw new ArgumentException(e.Message);

                }
            }
        }
        public static Produto AtualizaProduto(Produto prod)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                var precoTotal = prod.precoTotal;
                var precoUnt = prod.precoUnt;
                precoTotal = precoTotal.Replace(',', '.');
                precoUnt = precoUnt.Replace(',', '.');
                string data = prod.Data.ToString("yyyy-dd-MM");
                string GetData = DateTime.Now.ToString("yyyy-dd-MM");

                Produto produto = new Produto();
                var query = @"update Produto set data='"+data +"', produto='"+prod.produto+"', Quant='"+prod.Quant+"',precoUnt="+precoUnt+",precoTotal="+precoTotal+", DataAlteracao='"+GetData + "' where id = "+prod.id+"";
                connection.Open();

                try
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    DataTable dtLista = new DataTable();
                    SqlDataAdapter sqlData = new SqlDataAdapter(command);
                    sqlData.Fill(dtLista);

                    if (dtLista.Rows.Count >= 0)
                    {
                        produto.id = Convert.ToInt32(dtLista.Rows[0]["id"].ToString());
                        produto.Data = Convert.ToDateTime(dtLista.Rows[0]["data"].ToString());
                        produto.produto = dtLista.Rows[0]["produto"].ToString();
                        produto.Quant = dtLista.Rows[0]["quant"].ToString();
                        produto.precoUnt = dtLista.Rows[0]["precoUnt"].ToString();
                        produto.precoTotal = dtLista.Rows[0]["precoTotal"].ToString();

                    }
                    return produto;

                }
                catch (Exception e)
                {
                    throw new ArgumentException(e.Message);

                }
            }
        }

        //public static Produto ConsultaVenda(Vendas venda)
        //{
        //    using (SqlConnection connection = new SqlConnection(conn))
        //    {
        //        Vendas pedido = new Vendas();
        //        //var query = @"select * from Vendas where id = " + venda.id;
        //        connection.Open();

        //        try
        //        {
        //            //SqlCommand command = new SqlCommand(query, connection);

        //            //DataTable dtLista = new DataTable();
        //            //SqlDataAdapter sqlData = new SqlDataAdapter(command);
        //            //sqlData.Fill(dtLista);

        //            //if (dtLista.Rows.Count >= 0)
        //            //{
        //            //    pedido.id = Convert.ToInt32(dtLista.Rows[0]["id"].ToString());
        //            //    pedido.Data = Convert.ToDateTime(dtLista.Rows[0]["data"].ToString());
        //            //    pedido.produto = dtLista.Rows[0]["produto"].ToString();
        //            //    pedido.Quant = dtLista.Rows[0]["quant"].ToString();
        //            //    pedido.precoUnt = dtLista.Rows[0]["precoUnt"].ToString();
        //            //    pedido.precoTotal = dtLista.Rows[0]["precoTotal"].ToString();
        //            //}
        //            //return pedido;

        //        }
        //        catch (Exception e)
        //        {
        //            throw new ArgumentException(e.Message);

        //        }
        //    }
        //}
        public void Categoria()
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();

            
                var query ="select * from Categoria";

                SqlCommand command = new SqlCommand(query, connection);
                DataTable dtLista = new DataTable();

                SqlDataAdapter sqlData = new SqlDataAdapter(command);
                sqlData.Fill(dtLista);

            }
                

        }
    }
}