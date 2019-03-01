using Microsoft.LightSwitch;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System;

namespace LightSwitchApplication
{
    public partial class cfr_lu_branchName
    {
        partial void branchNameFull_Compute(ref string result)
        {
            result = this.branchCode + " " + this.branchName + " " + this.city;

        }

        partial void branchCode_Validate(EntityValidationResultsBuilder results)
        {
            var dupOnServer = (from branch in this.DataWorkspace.ApplicationData.cfr_lu_branchNames.Cast<cfr_lu_branchName>()
                               where this.branchCode == branch.branchCode && this != branch
                               select branch).ToArray();
            var dupOnClient = (from branch in this.DataWorkspace.ApplicationData.Details.GetChanges().OfType<cfr_lu_branchName>()
                               where this.branchCode == branch.branchCode && this != branch
                               select branch).ToArray();
            var anyDup = dupOnServer.Union(dupOnClient).Distinct().Any();

            if (anyDup)
            {
                results.AddPropertyError("Duplicate Branch Code");
            }

        }
    }
}