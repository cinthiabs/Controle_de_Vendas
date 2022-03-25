using ControledeVendas.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace ControledeVendas.Services
{

    public class DataBaseService
    {
        private static string conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        public DataBaseService()
        {
            //this.con = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        }
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


    }
}