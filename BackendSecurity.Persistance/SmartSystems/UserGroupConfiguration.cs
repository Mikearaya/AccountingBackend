/*
 * @CreateTime: Jun 7, 2019 5:52 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 7, 2019 5:52 PM
 * @Description: Modify Here, Please 
 */
using BackendSecurity.Domain.SmartSystems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendSecurity.Persistance.SmartSystems {
    public class UserGroupConfiguration : IEntityTypeConfiguration<UserGroup> {
        public void Configure (EntityTypeBuilder<UserGroup> builder) {
            builder.ToTable ("user_group");

            builder.HasIndex (e => e.GroupName)
                .HasName ("unique_gruop")
                .IsUnique ();

            builder.Property (e => e.Id).HasColumnName ("id");

            builder.Property (e => e.Description)
                .HasColumnName ("description")
                .HasColumnType ("text");

            builder.Property (e => e.GroupName)
                .HasColumnName ("group_name")
                .HasColumnType ("varchar(45)");
        }
    }
}