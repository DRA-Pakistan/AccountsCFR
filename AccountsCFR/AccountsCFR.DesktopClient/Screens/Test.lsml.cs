using Microsoft.LightSwitch.Presentation.Extensions;
using Microsoft.LightSwitch.Presentation;
using Microsoft.LightSwitch.Framework.Client;
using Microsoft.LightSwitch;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.IO;
using System.Linq;
using System;
using System.Windows.Printing;
using System.Windows;
using System.Windows.Browser;

namespace LightSwitchApplication
{
    public partial class Test
    {
        partial void ReportView_Execute()
        {

            Microsoft.LightSwitch.Threading.Dispatchers.Main.BeginInvoke(() =>
            {
            //    System.Text.StringBuilder codeToRun = new System.Text.StringBuilder();
            //    codeToRun.Append("window.open(");
            //    codeToRun.Append("\"");
            //    codeToRun.Append(string.Format("{0}", String.Format(@"{0}/WF/reportViewer.aspx?lid={1}&type=noc", GetBaseAddress(), "1234567890")));
            //    codeToRun.Append("\",");
            //    codeToRun.Append("\"");
            //    codeToRun.Append("\",");
            //    codeToRun.Append("\"");
            //    codeToRun.Append("width=680,height=640");
            //    codeToRun.Append(",scrollbars=yes,menubar=no,toolbar=no,resizable=yes");
            //    codeToRun.Append("\");");
            //    try
            //    {
            //        System.Windows.Browser.HtmlPage.Window.Eval(codeToRun.ToString());
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message,
            //            "Error", MessageBoxButton.OK);
            //    }
            //MessageBox.Show(GetBaseAddress().ToString());
                HtmlPage.Window.Navigate(new Uri(GetBaseAddress() + "/WF/Viewer.aspx?type=noc&nid=12345678"), "_blank");
            });

        }
        private static Uri GetBaseAddress()
        {
            // Get the web address of the .xap that launched this application
            string strBaseWebAddress = System.Windows.Browser.HtmlPage.Document.DocumentUri.AbsoluteUri;
            // Find the position of the ClientBin directory        
            int PositionOfClientBin =
                System.Windows.Browser.HtmlPage.Document.DocumentUri.AbsoluteUri.ToLower().IndexOf(@"/desktopclient");
            // Strip off everything after the ClientBin directory         
                strBaseWebAddress = Microsoft.VisualBasic.Strings.Left(strBaseWebAddress, PositionOfClientBin);
            // Create a URI
            Uri UriWebService = new Uri(String.Format(@"{0}", strBaseWebAddress));
            // Return the base address          
            return UriWebService;
        }
    }
}