using BackendSecurity.Domain.SmartSystems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendSecurity.Persistance.SmartSystems {
    public class UserConfiguration : IEntityTypeConfiguration<Users> {
        public void Configure (EntityTypeBuilder<Users> builder) {
            builder.HasKey (e => new { e.EmployeeId, e.UserName })
                .HasName ("PRIMARY");

            builder.ToTable ("users");

            builder.HasIndex (e => e.GroupId)
                .HasName ("user_group_fk_idx");

            builder.HasIndex (e => e.UserName)
                .HasName ("index3")
                .IsUnique ();

            builder.Property (e => e.EmployeeId)
                .HasColumnName ("employee_id")
                .HasColumnType ("varchar(8)");

            builder.Property (e => e.UserName)
                .HasColumnName ("user_name")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.GroupId).HasColumnName ("group_id");

            builder.Property (e => e.LastLoginTime)
                .HasColumnName ("last_login_time")
                .HasColumnType ("datetime");

            builder.Property (e => e.Password)
                .HasColumnName ("password")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.Status)
                .HasColumnName ("status")
                .HasColumnType ("varchar(45)")
                .HasDefaultValueSql ("'Active'");

            builder.HasOne (d => d.Group)
                .WithMany (p => p.Users)
                .HasForeignKey (d => d.GroupId)
                .HasConstraintName ("user_group_fk");
        }
    }
}