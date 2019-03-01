using Microsoft.LightSwitch;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System;

namespace LightSwitchApplication
{
    public partial class cfr_financialYear
    {
        partial void periodSummary_Compute(ref string result)
        {
            result = this.finStartDate.ToString("dd-MMM-yy") + " - " + this.finEndDate.ToString("dd-MMM-yy");

        }

        partial void finStartDate_Validate(EntityValidationResultsBuilder results)
        {
            if (this.finStartDate != null)
            {
                var onServer = (from finYears in this.DataWorkspace.ApplicationData.cfr_financialYears.Cast<cfr_financialYear>()
                                where this.finStartDate < finYears.finEndDate && this.finEndDate > finYears.finStartDate && finYears != this
                                && finYears.cfr_lu_manufacturer == this.cfr_lu_manufacturer
                                select finYears ).ToArray();
                var onClient = (from finYears in this.DataWorkspace.ApplicationData.Details.GetChanges().OfType<cfr_financialYear>()
                                where this.finStartDate < finYears.finEndDate && this.finEndDate > finYears.finStartDate && finYears != this
                                && finYears.cfr_lu_manufacturer == this.cfr_lu_manufacturer
                                select finYears).ToArray();
                var anyPer = onServer.Union(onClient).Distinct().Any();

                if (anyPer)
                {
                    results.AddPropertyError("Overlapping Finacial Year");
                }
                
            }
        }

        partial void finEndDate_Validate(EntityValidationResultsBuilder results)
        {
            if (this.finEndDate != null)
            {
                var onServer = (from finYears in this.DataWorkspace.ApplicationData.cfr_financialYears.Cast<cfr_financialYear>()
                                where this.finStartDate < finYears.finEndDate && this.finEndDate > finYears.finStartDate && finYears != this
                                && finYears.cfr_lu_manufacturer == this.cfr_lu_manufacturer
                                select finYears).ToArray();
                var onClient = (from finYears in this.DataWorkspace.ApplicationData.Details.GetChanges().OfType<cfr_financialYear>()
                                where this.finStartDate < finYears.finEndDate && this.finEndDate > finYears.finStartDate && finYears != this
                                && finYears.cfr_lu_manufacturer == this.cfr_lu_manufacturer
                                select finYears).ToArray();
                var anyPer = onServer.Union(onClient).Distinct().Any();

                if (anyPer)
                {
                    results.AddPropertyError(this.finStartDate + "Overlapping Finacial Year");
                }
                else if (this.finEndDate < this.finStartDate)
                {
                    results.AddEntityError("Financial Year End Date Cannot be Before Start Date");
                }
            }

        }

        public decimal deficit()
        {
            var remainingAmmt = (this.profitBeforeTax * (decimal)0.01) - depositTotal;
            return remainingAmmt;
        }

        partial void depositTotal_Compute(ref decimal result)
        {
            result = (from deposits in this.cfr_deposits select deposits.depositAmmount).Sum();

        }

        partial void remainingAmmount_Compute(ref decimal result)
        {
            if (this.profitBeforeTax>0)
            {
                result = this.requiredAmmount - this.depositTotal;
            }

        }

        partial void requiredAmmount_Compute(ref decimal result)
        {
            if (this.profitBeforeTax > 0)
            {
                result = profitBeforeTax * (decimal) 0.01;
            }

        }
    }
}