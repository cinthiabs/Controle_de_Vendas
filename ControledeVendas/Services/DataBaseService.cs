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
                 var query = @" select * from Categoria where Nome ='"+ prod.produto+"'";
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

                var query = @" select * from Categoria where Nome ='" + produto + "'";
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

                string query = "SELECT top 5 * FROM Categoria";
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
        
        public static Entidades.Produtos AtualizarProd(Entidades.Produtos prod)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                
                Entidades.Produtos produto = new Entidades.Produtos();

                var query = @"update Produto set produto='" + prod.produto + "' where id="+ prod.id+ "";
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
                        produto.produto = dtLista.Rows[0]["produto"].ToString();

                    }
                    return produto;

                }
                catch (Exception e)
                {
                    throw new ArgumentException(e.Message);

                }
            }

        }

        public static Entidades.Produtos InsertProduto(Entidades.Produtos prod)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                Entidades.Produtos produtos = new Entidades.Produtos();
                var query = @"insert into Categoria (nome)values('"+ prod.produto + "')";
                connection.Open();

                try
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    DataTable dtLista = new DataTable();
                    SqlDataAdapter sqlData = new SqlDataAdapter(command);

                    DataSet list = new DataSet();
                    sqlData.Fill(list);

                    if (list.Tables[0].Rows.Count >= 0)
                    {
                        //produtos = list;
                        return produtos;
                    }
                    return produtos;

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

        public static Entidades.Compras InsertCompras(Entidades.Compras comp)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                Entidades.Compras compra = new Entidades.Compras();

                var query = @"insert into Produto(data, produto, Quant,precoUnt,precoTotal)values('"+ comp.Data.ToString("yyyy-dd-mm hh:mm:ss") + "','" + comp.produto + "','" + comp.Quant + "'," + comp.precoUnt + "," + comp.precoTotal + ")";
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
                        compra.Data = Convert.ToDateTime(dtLista.Rows[0]["data"].ToString());
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
        public static Entidades.Compras AtualizaCompras(Entidades.Compras comp)
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
                        compra.id = Convert.ToInt32(dtLista.Rows[0]["id"].ToString());
                        compra.Data = Convert.ToDateTime(dtLista.Rows[0]["data"].ToString());
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
        public void Produto()
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