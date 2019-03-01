using Microsoft.LightSwitch;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System;

namespace LightSwitchApplication
{
    public partial class cfr_lu_manufacturer
    {
        partial void manuFacturerFull_Compute(ref string result)
        {
            result = this.license_no + " " + this.companyName;
        }

        partial void license_no_Validate(EntityValidationResultsBuilder results)
        {
            var dupOnserver = (from mfgs in this.DataWorkspace.ApplicationData.cfr_lu_manufacturers.Cast<cfr_lu_manufacturer>()
                               where this.license_no == mfgs.license_no && mfgs != this
                               select mfgs).ToArray();
            var dupOnClient = (from mfgs in this.DataWorkspace.ApplicationData.Details.GetChanges().OfType<cfr_lu_manufacturer>()
                               where this.license_no == mfgs.license_no && this != mfgs
                               select mfgs).ToArray();

            var anyDup = dupOnserver.Union(dupOnClient).Distinct().Any();
            if (anyDup)
            {
                results.AddPropertyError("Duplicate Entry");
            }

        }
    }
}