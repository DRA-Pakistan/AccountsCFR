using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ZXing;
using System.Drawing;

namespace LightSwitchApplication.WF
{
    public partial class Viewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string type = Request.QueryString["type"];
            string nid = Request.QueryString["nid"];
            //Label1.Text = type + "\n" + nid;
            //Label1.Text = Label1.Text+"\n"+ Page.ResolveUrl(@"~/Reports/CrystalReport1.rpt");

            SqlConnection dbCon = new SqlConnection(ConfigurationManager.ConnectionStrings["_IntrinsicData"].ToString());
            SqlCommand cmd = new SqlCommand("CRF_nocLetter", dbCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@pLetterGuid", nid));

            try
            {
                dbCon.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet("DataSet1");
                DataTable dt = new DataTable("NOCLetter");
                da.Fill(dt);
                dt.Columns.Add("qrCode", System.Type.GetType("System.Byte[]"));
                dt.Rows[0]["qrCode"] = qrGenerator(nid) ;
                if (dt.Rows.Count == 1)
                {
                    ds.Tables.Add(dt);
                    bool flag = File.Exists(Server.MapPath(@"~/Reports/CRF_NoC.rpt"));
                    //Label1.Text = Label1.Text + "\nFile Exists? " + flag.ToString();
                    //Label1.Text = Label1.Text + "\n" + Server.MapPath(@"~/Reports/CRF_NoC.rpt");
                    //if (flag)
                    {
                        
                        //Label1.Text = Label1.Text + "\n" + CRSource.ReportDocument.DataSourceConnections;
                        
                        ReportDocument reportDocument34 = new ReportDocument();
                        reportDocument34.Load(Server.MapPath(@"~\\Reports\\CRF_NoC.rpt"));
                        //reportDocument34.Database.Tables[0].SetDataSource(dt);
                        reportDocument34.SetDataSource(ds);
                        //reportDocument34.ExportToHttpResponse(ExportFormatType.PortableDocFormat, this.Response, true, "Test");
                        CrystalReportViewer1.ReportSource = (object) reportDocument34;
                        CrystalReportViewer1.RefreshReport();
                        CrystalReportViewer1.DataBind();
                        CrystalReportViewer1.Visible = true;

                    }
                }


            }
            catch (Exception ex)
            {
                //Label1.Text = ex.Message;
            }

        }

        public byte[] qrGenerator(string toEncode)
        {
            ZXing.QrCode.QrCodeEncodingOptions s = new ZXing.QrCode.QrCodeEncodingOptions();
            s.Height = 1000;
            s.Width = 1000;
            s.Margin = 1;
            s.QrVersion = 2;
            s.ErrorCorrection = ZXing.QrCode.Internal.ErrorCorrectionLevel.Q;

            var qWriter = new BarcodeWriter();
            qWriter.Format = BarcodeFormat.QR_CODE;
            qWriter.Options = s;
            Bitmap img = qWriter.Write(toEncode);
            ImageConverter ic = new ImageConverter();

            return (byte[])ic.ConvertTo(img, typeof(byte[]));
        }


    }
}