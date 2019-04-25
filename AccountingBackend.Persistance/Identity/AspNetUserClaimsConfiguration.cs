/*
 * @CreateTime: Apr 25, 2019 3:17 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 25, 2019 3:17 PM
 * @Description: Modify Here, Please 
 */

using AccountingBackend.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountingBackend.Persistance.Identity {
    public class AspNetUserClaimsConfiguration : IEntityTypeConfiguration<AspNetUserClaims> {
        public void Configure (EntityTypeBuilder<AspNetUserClaims> builder) {

            builder.HasIndex (e => e.UserId);

            builder.Property (e => e.Id).HasColumnType ("int(11)");

            builder.Property (e => e.ClaimType).HasColumnType ("longtext");

            builder.Property (e => e.ClaimValue).HasColumnType ("longtext");

            builder.Property (e => e.UserId)
                .IsRequired ()
                .HasColumnType ("varchar(255)");

            builder.HasOne (d => d.User)
                .WithMany (p => p.AspNetUserClaims)
                .HasForeignKey (d => d.UserId);
        }
    }
}