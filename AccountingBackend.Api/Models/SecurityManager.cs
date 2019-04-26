/*
 * @CreateTime: Apr 25, 2019 8:59 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 26, 2019 10:39 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using AccountingBackend.Api.Configurations;
using AccountingBackend.Application.Models;
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

            //TODO: chnge to asp net core authentication
            using (var db = new AccountingDatabaseService ()) {
                authUser = db.Users.Where (
                    u => u.UserName.ToLower () == user.UserName.ToLower ()).FirstOrDefault ();
            }

            if (authUser != null) {
                ret = BuildUserAuthObject (authUser);
            }

            return ret;

        }
        protected string BuildJwtToken (AppUserAuth authUser) {
            SymmetricSecurityKey key = new SymmetricSecurityKey (
                Encoding.UTF8.GetBytes (_settings.Key));

            List<Claim> jwtClaims = new List<Claim> ();

            jwtClaims.Add (new Claim (JwtRegisteredClaimNames.Sub, authUser.UserName));
            jwtClaims.Add (new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid ().ToString ()));

            jwtClaims.Add (new Claim ("isAuthenticated", authUser.IsAuthenticated.ToString ().ToLower ()));

            foreach (var claim in authUser.Claims) {
                jwtClaims.Add (new Claim (claim.ClaimType, claim.ClaimValue));
            }

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

            ret.Claims = GetUserClaims (authUser);

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