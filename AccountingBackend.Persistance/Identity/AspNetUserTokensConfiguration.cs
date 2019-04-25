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
    public class AspNetUserTokensConfiguration : IEntityTypeConfiguration<AspNetUserTokens> {
        public void Configure (EntityTypeBuilder<AspNetUserTokens> builder) {

            builder.Property (e => e.UserId).HasColumnType ("varchar(255)");

            builder.Property (e => e.LoginProvider).HasColumnType ("varchar(255)");

            builder.Property (e => e.Name).HasColumnType ("varchar(255)");

            builder.Property (e => e.Value).HasColumnType ("longtext");

            builder.HasOne (d => d.User)
                .WithMany (p => p.AspNetUserTokens)
                .HasForeignKey (d => d.UserId);
        }
    }
}