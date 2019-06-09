using System;
using System.Collections.Generic;
using System.Linq;
using AccountingBackend.Application.Interfaces;
using BackendSecurity.Domain.Identity;

namespace AccountingBackend.Application.Security {
    public class SecurityManager {
        private readonly ISecurityDatabaseService _securityDatabase;

        public SecurityManager (ISecurityDatabaseService securityDatabase) {
            _securityDatabase = securityDatabase;
        }

        public AppUserAuth ValidateUser (AppUser user) {

            AppUserAuth ret = new AppUserAuth ();
            ApplicationUser authUser = null;

            authUser = _securityDatabase.Users
                .Where (u => u.UserName.ToLower () == user.UserName.ToLower () && u.PasswordHash == user.PasswordHash)
                .FirstOrDefault ();

            if (authUser != null) {
                ret = BuildUserAuthObject (authUser);
            }
            return ret;
        }

        public List<ApplicationUserClaims> GetUserClaims (ApplicationUser authUser) {
            List<ApplicationUserClaims> list = new List<ApplicationUserClaims> ();

            try {
                list = _securityDatabase.UserClaims
                    .Where (a => a.UserId == authUser.Id)
                    .ToList ();
            } catch (Exception e) {

            }

            return list;

        }

        public AppUserAuth BuildUserAuthObject (ApplicationUser authUser) {
            AppUserAuth ret = new AppUserAuth ();
            List<ApplicationUserClaims> claims = new List<ApplicationUserClaims> ();

            ret.UserName = authUser.UserName;
            ret.IsAuthenticated = true;
            ret.BearerToken = new Guid ().ToString ();

            claims = GetUserClaims (authUser);

            foreach (ApplicationUserClaims claim in claims) {

                try {
                    typeof (AppUserAuth).GetProperty (claim.ClaimType).SetValue (ret, Convert.ToBoolean (claim.ClaimValue), null);
                } finally {

                }

            }

            return ret;

        }

    }
}