/*
 * @CreateTime: Jun 7, 2019 5:41 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 7, 2019 5:42 PM
 * @Description: Modify Here, Please 
 */
using BackendSecurity.Domain.SmartSystems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendSecurity.Persistance.SmartSystems {
    public class DepartmentGroupRoleConfiguration : IEntityTypeConfiguration<DepartmentGroupRole> {
        public void Configure (EntityTypeBuilder<DepartmentGroupRole> builder) {
            builder.ToTable ("department_group_role");

            builder.HasIndex (e => e.GroupId)
                .HasName ("role_fk_idx");

            builder.Property (e => e.Id).HasColumnName ("id");

            builder.Property (e => e.GroupId).HasColumnName ("group_id");

            builder.HasOne (d => d.Group)
                .WithMany (p => p.DepartmentGroupRole)
                .HasForeignKey (d => d.GroupId)
                .HasConstraintName ("user_groiup_role_fk");
        }
    }
}