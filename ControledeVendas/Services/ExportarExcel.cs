using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControledeVendas.Services
{
    public class ExportarExcel
    {
        public static bool SalvarExcel(DataTable dt_ExpExcel, int Tipo, String filename)
        {
                if (Tipo == 1) //CSV
                {
                    Byte[] bCSV = Encoding.Unicode.GetBytes(ExportTCSVFile(dt_ExpExcel));
                    MemoryStream ms = new MemoryStream(bCSV);

                    HttpResponse oResponse = System.Web.HttpContext.Current.Response;
                    oResponse.Clear();
                    oResponse.Buffer = false;
                    oResponse.BufferOutput = false;
                    oResponse.ContentType = "Application/octet-stream";
                    oResponse.ContentEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
                    string attachment = "attachment; filename=" + filename + "_" + DateTime.Now.ToString("ddMMyyyy") + DateTime.Now.ToString("hhmmss") + ".csv";
                    oResponse.AddHeader("Content-Length", ms.Length.ToString());
                    oResponse.AddHeader("Content-Disposition", attachment);
                    oResponse.BinaryWrite(ms.ToArray());
                    oResponse.Flush();
                    oResponse.Close();
                    oResponse.End();
                    return true;

                }

                else if (Tipo == 2) //xls
                {
                   Byte[] dsSitEntrega = Encoding.Unicode.GetBytes(ExportTCSVFile(dt_ExpExcel));
                   MemoryStream ms = new MemoryStream(dsSitEntrega);
                    using (GridView gvconsulta = new GridView())
                    {
                        try
                        {
                            if (dt_ExpExcel != null)
                            {
                                if (dt_ExpExcel.Rows.Count > 0)
                                {
                                    gvconsulta.DataSource = dt_ExpExcel;
                                    gvconsulta.DataBind();

                                    HttpResponse oResponse = System.Web.HttpContext.Current.Response;
                                    oResponse.Buffer = false;
                                    oResponse.Clear();
                                    oResponse.ContentEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
                                    string attachment = "attachment; filename=" + filename + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".xls";
                                    oResponse.AddHeader("content-disposition", attachment);
                                    oResponse.ContentType = "application/vnd.ms-excel";
                                    System.IO.StringWriter sw = new System.IO.StringWriter();
                                    System.Web.UI.HtmlTextWriter htw = new HtmlTextWriter(sw);
                                    gvconsulta.RenderControl(htw);
                                    oResponse.Write(sw.ToString());
                                    oResponse.End();
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        catch (Exception ex)
                        {

                          throw new ArgumentException(ex.Message);
                        }
                    }
                }
            return true;
        }

        public  static string ExportTCSVFile(DataTable dtTable)
        {
            var sbldr = new StringBuilder();

            foreach (DataColumn c in dtTable.Columns)
            {
                sbldr.Append(System.Text.RegularExpressions.Regex.Replace(c.ColumnName, @"\n|\t|\r|;", "").Trim() + ";");
            }

            sbldr.Append("\r\n");
            foreach (DataRow row in dtTable.Rows)
            {
                foreach (DataColumn column in dtTable.Columns)
                {
                    sbldr.Append(System.Text.RegularExpressions.Regex.Replace(row[column].ToString().Trim(), @"\n|\t|\r|;", "") + ";");
                }
                sbldr.AppendLine();
            }

            return sbldr.ToString();
        }
    }
}