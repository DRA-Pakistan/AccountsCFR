using Microsoft.LightSwitch.Presentation.Extensions;
using Microsoft.LightSwitch.Presentation;
using Microsoft.LightSwitch.Framework.Client;
using Microsoft.LightSwitch;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.IO;
using System.Linq;
using System;
using System.Windows;
using System.Windows.Browser;

namespace LightSwitchApplication
{
    public partial class CompanyWise
    {
        partial void GenNOC_CanExecute(ref bool result)
        {
            result = (Application.Current.User.HasPermission(Permissions.GenNOC) && cfr_financialYear.SelectedItem.deficit() <=0);   

        }

        partial void GenNOC_Execute()
        {
            if (this.ShowMessageBox("Are you sure to proceed?....", "Confirmation", MessageBoxOption.YesNo) == MessageBoxResult.Yes)
            {
                var letterNum = this.ShowInputBox("Please Enter Letter Number", "Letter Number");
                if (letterNum != null)
                {
                    var letter = this.DataWorkspace.ApplicationData.cfr_issuedLetters.AddNew();
                    letter.letterNumber = letterNum;
                    letter.letterType = "NOC";
                    letter.finacnialYear = this.cfr_financialYear.SelectedItem;
                    letter.isValid = true;
                    letter.issuedBy = Application.User.FullName;
                }

            }
        }

        partial void GenDefficiency_CanExecute(ref bool result)
        {
            result = (Application.Current.User.HasPermission(Permissions.GenDef) && cfr_financialYear.SelectedItem.deficit() > 0);

        }

        partial void GenDefficiency_Execute()
        {
            this.ShowMessageBox("Defficit Letter Generated");

        }

        partial void View_Execute()
        {
            string relUrl = string.Format(@"/WF/Viewer.aspx?type={0}&nid={1}", this.issuedLetters.SelectedItem.letterType, this.issuedLetters.SelectedItem.letterGuid);
            Microsoft.LightSwitch.Threading.Dispatchers.Main.BeginInvoke(() =>
            {
                
                string baseurl = "http://"+System.Windows.Application.Current.Host.Source.Host.ToString()+":"+ System.Windows.Application.Current.Host.Source.Port.ToString();
                //this.ShowMessageBox(baseurl + relUrl);
                HtmlPage.Window.Navigate(new Uri(baseurl+relUrl), "_new");
            });
        }
    }
}