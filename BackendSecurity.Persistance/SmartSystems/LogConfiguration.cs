/*
 * @CreateTime: Jun 7, 2019 5:57 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 7, 2019 5:57 PM
 * @Description: Modify Here, Please 
 */
using BackendSecurity.Domain.SmartSystems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendSecurity.Persistance.SmartSystems {
    public class LogConfiguration : IEntityTypeConfiguration<Log> {
        public void Configure (EntityTypeBuilder<Log> builder) {
            builder.ToTable ("log");

            builder.Property (e => e.LogId).HasColumnName ("log_id");

            builder.Property (e => e.Action)
                .IsRequired ()
                .HasColumnName ("action")
                .HasColumnType ("enum('Edit','Delete','Add New')");

            builder.Property (e => e.NewValue)
                .HasColumnName ("new_value")
                .HasColumnType ("text");

            builder.Property (e => e.OldValue)
                .HasColumnName ("old_value")
                .HasColumnType ("text");

            builder.Property (e => e.Table)
                .IsRequired ()
                .HasColumnName ("table")
                .HasColumnType ("varchar(50)");

            builder.Property (e => e.Time)
                .HasColumnName ("time")
                .HasColumnType ("timestamp")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

            builder.Property (e => e.UniqueId)
                .HasColumnName ("unique_id")
                .HasColumnType ("varchar(50)");
        }
    }
}