/*
 * @CreateTime: Apr 23, 2019 7:04 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 26, 2019 9:27 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Threading.Tasks;
using AccountingBackend.Application.Interfaces;
using BackendSecurity.Domain.Identity;
using BackendSecurity.Persistance.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BackendSecurity.Persistance {
    public class SecurityDatabaseService : IdentityDbContext<ApplicationUser, ApplicationRole, string, AspNetUserClaims, AspNetUserRoles, AspNetUserLogins, AspNetRoleClaims, AspNetUserTokens>, ISecurityDatabaseService {

        public SecurityDatabaseService () { }
        public SecurityDatabaseService (DbContextOptions<SecurityDatabaseService> options) : base (options) { }
        public new DbSet<AspNetRoleClaims> RoleClaims { get; set; }
        public new DbSet<ApplicationRole> Roles { get; set; }
        public new DbSet<AspNetUserClaims> UserClaims { get; set; }
        public new DbSet<AspNetUserLogins> UserLogins { get; set; }
        public new DbSet<AspNetUserRoles> UserRoles { get; set; }
        public new DbSet<ApplicationUser> Users { get; set; }
        public new DbSet<AspNetUserTokens> UserTokens { get; set; }
        protected override void OnConfiguring (DbContextOptionsBuilder optionBuilder) {

            if (!optionBuilder.IsConfigured) {
                optionBuilder.UseMySql ("server=localhost;user=admin;password=admin;port=3306;database=smart_security;");
            }
        }

        protected override void OnModelCreating (ModelBuilder builder) {
            base.OnModelCreating (builder);
            builder.ApplyConfiguration (new AspNetUserConfiguration ());
            builder.ApplyConfiguration (new AspNetRoleClaimsConfiguration ());
            builder.ApplyConfiguration (new AspNetRolesConfiguration ());
            builder.ApplyConfiguration (new AspNetUserClaimsConfiguration ());
            builder.ApplyConfiguration (new AspNetUserLoginsConfiguration ());
            builder.ApplyConfiguration (new AspNetUserRolesConfiguration ());
            builder.ApplyConfiguration (new AspNetUserTokensConfiguration ());
        }

        public void Save () {
            this.SaveChanges ();
        }

        public Task SaveAsync () {
            return this.SaveChangesAsync ();
        }

    }
}