/*
 * @CreateTime: Jun 7, 2019 5:44 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 7, 2019 5:45 PM
 * @Description: Modify Here, Please 
 */
using BackendSecurity.Domain.SmartSystems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendSecurity.Persistance.SmartSystems {
    public class GroupRoleConfiguration : IEntityTypeConfiguration<GroupRole> {
        public void Configure (EntityTypeBuilder<GroupRole> builder) {
            builder.ToTable ("group_role");

            builder.Property (e => e.Id).HasColumnName ("id");

            builder.Property (e => e.ApplicationName)
                .HasColumnName ("application_name")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.Event)
                .HasColumnName ("event")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.GroupId).HasColumnName ("group_id");

            builder.Property (e => e.Page)
                .HasColumnName ("page")
                .HasColumnType ("varchar(45)");
        }
    }
}