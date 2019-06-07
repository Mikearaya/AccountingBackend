/*
 * @CreateTime: Apr 23, 2019 7:04 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 7, 2019 6:00 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Threading.Tasks;
using AccountingBackend.Application.Interfaces;
using BackendSecurity.Domain.Identity;
using BackendSecurity.Domain.SmartSystems;
using BackendSecurity.Persistance.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BackendSecurity.Persistance {
    public class SecurityDatabaseService : IdentityDbContext<ApplicationUser, ApplicationRole, string, ApplicationUserClaims, AspNetUserRoles, AspNetUserLogins, AspNetRoleClaims, AspNetUserTokens>, ISecurityDatabaseService {

        public SecurityDatabaseService () { }
        public SecurityDatabaseService (DbContextOptions<SecurityDatabaseService> options) : base (options) { }
        public new DbSet<AspNetRoleClaims> RoleClaims { get; set; }
        public new DbSet<ApplicationRole> Roles { get; set; }
        public new DbSet<ApplicationUserClaims> UserClaims { get; set; }
        public new DbSet<AspNetUserLogins> UserLogins { get; set; }
        public new DbSet<AspNetUserRoles> UserRoles { get; set; }
        public new DbSet<ApplicationUser> Users { get; set; }
        public new DbSet<AspNetUserTokens> UserTokens { get; set; }
        public DbSet<CiSessions> CiSessions { get; set; }
        public DbSet<Denomination> Denomination { get; set; }
        public DbSet<DepartmentGroupRole> DepartmentGroupRole { get; set; }
        public DbSet<Documents> Documents { get; set; }
        public DbSet<GroupRole> GroupRole { get; set; }
        public DbSet<Log> Log { get; set; }
        public DbSet<Lookup> Lookup { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<MyReport> MyReport { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<UserGroup> UserGroup { get; set; }
        public DbSet<Users> SystemUsers { get; set; }
        protected override void OnConfiguring (DbContextOptionsBuilder optionBuilder) {

            if (!optionBuilder.IsConfigured) {
                optionBuilder.UseMySql ("server=localhost;user=admin;password=admin;port=3306;database=smart_security;");
            }
        }

        protected override void OnModelCreating (ModelBuilder builder) {
            base.OnModelCreating (builder);
            builder.ApplyConfigurationsFromAssembly (typeof (SecurityDatabaseService).Assembly);
        }

        public void Save () {
            this.SaveChanges ();
        }

        public Task SaveAsync () {
            return this.SaveChangesAsync ();
        }

    }
}