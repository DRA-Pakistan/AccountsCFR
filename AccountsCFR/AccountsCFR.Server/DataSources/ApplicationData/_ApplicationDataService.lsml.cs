using Microsoft.LightSwitch.Security.Server;
using Microsoft.LightSwitch;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System;

namespace LightSwitchApplication
{
    public partial class ApplicationDataService
    {
        
        #region Audit Trail
        partial void cfr_deposits_Updating(cfr_deposit entity)
        {
            AuditHelper.CreateAuditTrailForUpdate(entity, this);
        }

        partial void cfr_deposits_Deleting(cfr_deposit entity)
        {
            AuditHelper.CreateAuditTrailForDelete(entity, this);
        }

        partial void cfr_financialYears_Updating(cfr_financialYear entity)
        {
            AuditHelper.CreateAuditTrailForUpdate(entity, this);
        }

        partial void cfr_financialYears_Deleting(cfr_financialYear entity)
        {
            AuditHelper.CreateAuditTrailForDelete(entity, this);
        }

        partial void cfr_issuedLetters_Updating(cfr_issuedLetter entity)
        {
            AuditHelper.CreateAuditTrailForUpdate(entity, this);
        }

        partial void cfr_issuedLetters_Deleting(cfr_issuedLetter entity)
        {
            AuditHelper.CreateAuditTrailForDelete(entity, this);
        }

        partial void cfr_lu_bankNames_Updating(cfr_lu_bankName entity)
        {
            AuditHelper.CreateAuditTrailForUpdate(entity, this);
        }

        partial void cfr_lu_bankNames_Deleted(cfr_lu_bankName entity)
        {
            AuditHelper.CreateAuditTrailForDelete(entity, this);
        }

        partial void cfr_lu_branchNames_Updating(cfr_lu_branchName entity)
        {
            AuditHelper.CreateAuditTrailForUpdate(entity, this);
        }

        partial void cfr_lu_branchNames_Deleting(cfr_lu_branchName entity)
        {
            AuditHelper.CreateAuditTrailForDelete(entity, this);
        }

        partial void cfr_lu_manufacturers_Updating(cfr_lu_manufacturer entity)
        {
            AuditHelper.CreateAuditTrailForUpdate(entity, this);
        }

        partial void cfr_lu_manufacturers_Deleting(cfr_lu_manufacturer entity)
        {
            AuditHelper.CreateAuditTrailForDelete(entity, this);
        }

        partial void cfr_lu_provinces_Updating(cfr_lu_province entity)
        {
            AuditHelper.CreateAuditTrailForUpdate(entity, this);
        }

        partial void cfr_lu_provinces_Deleting(cfr_lu_province entity)
        {
            AuditHelper.CreateAuditTrailForDelete(entity, this);
        }
        #endregion

        #region Permissons
        partial void cfr_deposits_CanInsert(ref bool result)
        {
            result = Application.Current.User.HasPermission(Permissions.AddDeposit);
        }
        partial void cfr_deposits_CanUpdate(ref bool result)
        {
            result = Application.Current.User.HasPermission(Permissions.UpdateDeposit);
        }
        partial void cfr_deposits_CanDelete(ref bool result)
        {
            result = Application.Current.User.HasPermission(Permissions.DeleteDeposit);
        }
        partial void cfr_financialYears_CanInsert(ref bool result)
        {
            result = Application.Current.User.HasPermission(Permissions.AddDeposit);
        }
        partial void cfr_financialYears_CanUpdate(ref bool result)
        {
            result = Application.Current.User.HasPermission(Permissions.UpdateDeposit);
        }
        partial void cfr_financialYears_CanDelete(ref bool result)
        {
            result = Application.Current.User.HasPermission(Permissions.DeleteDeposit);
        }
        partial void cfr_issuedLetters_CanInsert(ref bool result)
        {
            result = Application.Current.User.HasPermission(Permissions.AddDeposit);
        }
        partial void cfr_issuedLetters_CanUpdate(ref bool result)
        {
            result = Application.Current.User.HasPermission(Permissions.UpdateDeposit);
        }
        partial void cfr_issuedLetters_CanDelete(ref bool result)
        {
            result = Application.Current.User.HasPermission(Permissions.DeleteDeposit);
        }
        partial void cfr_lu_bankNames_CanInsert(ref bool result)
        {
            result = Application.Current.User.HasPermission(Permissions.AddLookup);
        }
        partial void cfr_lu_bankNames_CanUpdate(ref bool result)
        {
            result = Application.Current.User.HasPermission(Permissions.UpdateLookup);
        }
        partial void cfr_lu_bankNames_CanDelete(ref bool result)
        {
            result = Application.Current.User.HasPermission(Permissions.DeleteLookup);
        }
        partial void cfr_lu_branchNames_CanInsert(ref bool result)
        {
            result = Application.Current.User.HasPermission(Permissions.AddLookup);
        }
        partial void cfr_lu_branchNames_CanUpdate(ref bool result)
        {
            result = Application.Current.User.HasPermission(Permissions.UpdateLookup);
        }
        partial void cfr_lu_branchNames_CanDelete(ref bool result)
        {
            result = Application.Current.User.HasPermission(Permissions.DeleteLookup);
        }
        partial void cfr_lu_cities_CanInsert(ref bool result)
        {
            result = Application.Current.User.HasPermission(Permissions.AddLookup);
        }
        partial void cfr_lu_cities_CanUpdate(ref bool result)
        {
            result = Application.Current.User.HasPermission(Permissions.UpdateLookup);
        }
        partial void cfr_lu_cities_CanDelete(ref bool result)
        {
            result = Application.Current.User.HasPermission(Permissions.DeleteLookup);
        }
        partial void cfr_lu_manufacturers_CanInsert(ref bool result)
        {
            result = Application.Current.User.HasPermission(Permissions.AddLookup);
        }
        partial void cfr_lu_manufacturers_CanUpdate(ref bool result)
        {
            result = Application.Current.User.HasPermission(Permissions.UpdateLookup);
        }
        partial void cfr_lu_manufacturers_CanDelete(ref bool result)
        {
            result = Application.Current.User.HasPermission(Permissions.DeleteLookup);
        }
        partial void cfr_lu_provinces_CanInsert(ref bool result)
        {
            result = Application.Current.User.HasPermission(Permissions.AddLookup);
        }
        partial void cfr_lu_provinces_CanUpdate(ref bool result)
        {
            result = Application.Current.User.HasPermission(Permissions.UpdateLookup);
        }
        partial void cfr_lu_provinces_CanDelete(ref bool result)
        {
            result = Application.Current.User.HasPermission(Permissions.DeleteLookup);
        }

        #endregion


       
    }
}