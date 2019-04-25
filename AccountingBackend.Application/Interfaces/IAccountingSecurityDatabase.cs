/*
 * @CreateTime: Apr 25, 2019 3:29 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 25, 2019 3:30 PM
 * @Description: Modify Here, Please 
 */
using AccountingBackend.Domain.Identity;
using Microsoft.EntityFrameworkCore;

namespace AccountingBackend.Application.Interfaces {
    public interface IAccountingSecurityDatabase {
        DbSet<AspNetRoleClaims> RoleClaims { get; set; }
        DbSet<ApplicationRole> Roles { get; set; }
        DbSet<AspNetUserClaims> UserClaims { get; set; }
        DbSet<AspNetUserLogins> UserLogins { get; set; }
        DbSet<AspNetUserRoles> UserRoles { get; set; }
        DbSet<ApplicationUser> Users { get; set; }
        DbSet<AspNetUserTokens> UserTokens { get; set; }
    }
}