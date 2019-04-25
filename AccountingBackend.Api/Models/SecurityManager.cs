/*
 * @CreateTime: Apr 25, 2019 8:59 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 25, 2019 2:45 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using AccountingBackend.Api.Configurations;
using AccountingBackend.Domain.Identity;
using AccountingBackend.Persistance;
using Microsoft.IdentityModel.Tokens;

namespace AccountingBackend.Api.Models {
    public class SecurityManager {
        private readonly JwtSettings _settings;

        public SecurityManager (JwtSettings settings) {
            _settings = settings;
        }

        public AppUserAuth ValidateUser (ApplicationUser user) {

            AppUserAuth ret = new AppUserAuth ();
            ApplicationUser authUser = null;

            return ret;

        }
        protected string BuildJwtToken (AppUserAuth authUser) {
            SymmetricSecurityKey key = new SymmetricSecurityKey (
                Encoding.UTF8.GetBytes (_settings.Key));

            List<Claim> jwtClaims = new List<Claim> ();

            jwtClaims.Add (new Claim (JwtRegisteredClaimNames.Sub, authUser.UserName));
            jwtClaims.Add (new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid ().ToString ()));

            jwtClaims.Add (new Claim ("isAuthenticated", authUser.IsAuthenticated.ToString ().ToLower ()));
            jwtClaims.Add (new Claim ("canAccessAccounts", authUser.CanAccessAccounts.ToString ().ToLower ()));
            jwtClaims.Add (new Claim ("canAddAccount", authUser.CanAddAccount.ToString ().ToLower ()));
            jwtClaims.Add (new Claim ("canEditAccount", authUser.CanEditAccount.ToString ().ToLower ()));
            jwtClaims.Add (new Claim ("canDeleteAccount", authUser.CanDeleteAccount.ToString ().ToLower ()));

            var token = new JwtSecurityToken (
                issuer: _settings.Issuer,
                audience: _settings.Audience,
                claims: jwtClaims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes (_settings.MinutesToExpiration),
                signingCredentials: new SigningCredentials (key, SecurityAlgorithms.HmacSha256)

            );

            return new JwtSecurityTokenHandler ().WriteToken (token);
        }

        protected AppUserAuth BuildUserAuthObject (ApplicationUser authUser) {
            AppUserAuth ret = new AppUserAuth ();

            List<AspNetUserClaims> claims = new List<AspNetUserClaims> ();

            ret.UserName = authUser.UserName;
            ret.IsAuthenticated = true;
            ret.BearerToken = new Guid ().ToString ();

            claims = GetUserClaims (authUser);

            foreach (AspNetUserClaims claim in claims) {

                try {
                    typeof (AppUserAuth)
                    .GetProperty (claim.ClaimType)
                        .SetValue (ret, Convert.ToBoolean (claim.ClaimValue));
                } catch { }

            }

            return ret;
        }

        protected List<AspNetUserClaims> GetUserClaims (ApplicationUser authUser) {

            List<AspNetUserClaims> list = new List<AspNetUserClaims> ();

            try {
                using (var db = new AccountingDatabaseService ()) {
                    list = db.UserClaims.Where (u => u.UserId == authUser.Id).ToList ();
                }
            } catch (Exception ex) {
                throw new Exception ("Exception trying toretrive user claims", ex);
            }

            return list;
        }

    }

}