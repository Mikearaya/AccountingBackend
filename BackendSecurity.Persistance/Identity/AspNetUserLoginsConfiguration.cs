/*
 * @CreateTime: Apr 25, 2019 3:20 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 25, 2019 3:20 PM
 * @Description: Modify Here, Please 
 */
using BackendSecurity.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendSecurity.Persistance.Identity {
    public class AspNetUserLoginsConfiguration : IEntityTypeConfiguration<AspNetUserLogins> {
        public void Configure (EntityTypeBuilder<AspNetUserLogins> builder) {

            builder.ToTable ("AspNetUserLogins");

            builder.HasIndex (e => e.UserId);

            builder.Property (e => e.LoginProvider).HasColumnType ("varchar(255)");

            builder.Property (e => e.ProviderKey).HasColumnType ("varchar(255)");

            builder.Property (e => e.ProviderDisplayName).HasColumnType ("longtext");

            builder.Property (e => e.UserId)
                .IsRequired ()
                .HasColumnType ("varchar(255)");

            builder.HasOne (d => d.User)
                .WithMany (p => p.AspNetUserLogins)
                .HasForeignKey (d => d.UserId);
        }
    }
}