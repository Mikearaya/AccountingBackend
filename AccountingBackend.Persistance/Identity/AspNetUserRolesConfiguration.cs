/*
 * @CreateTime: Apr 25, 2019 3:20 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 25, 2019 3:20 PM
 * @Description: Modify Here, Please 
 */

using AccountingBackend.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountingBackend.Persistance.Identity {
    public class AspNetUserRolesConfiguration : IEntityTypeConfiguration<AspNetUserRoles> {
        public void Configure (EntityTypeBuilder<AspNetUserRoles> builder) {

            builder.HasIndex (e => e.RoleId);

            builder.Property (e => e.UserId).HasColumnType ("varchar(255)");

            builder.Property (e => e.RoleId).HasColumnType ("varchar(255)");

            builder.HasOne (d => d.Role)
                .WithMany (p => p.AspNetUserRoles)
                .HasForeignKey (d => d.RoleId);

            builder.HasOne (d => d.User)
                .WithMany (p => p.AspNetUserRoles)
                .HasForeignKey (d => d.UserId);
        }
    }
}