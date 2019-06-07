/*
 * @CreateTime: Jun 7, 2019 5:40 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 7, 2019 5:40 PM
 * @Description: Modify Here, Please 
 */
using BackendSecurity.Domain.SmartSystems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendSecurity.Persistance.SmartSystems {
    public class CiSessionsConfiguration : IEntityTypeConfiguration<CiSessions> {
        public void Configure (EntityTypeBuilder<CiSessions> builder) {
            builder.HasKey (e => e.SessionId)
                .HasName ("PRIMARY");

            builder.ToTable ("ci_sessions");

            builder.HasIndex (e => e.LastActivity)
                .HasName ("last_activity_idx");

            builder.Property (e => e.SessionId)
                .HasColumnName ("session_id")
                .HasColumnType ("varchar(40)")
                .HasDefaultValueSql ("'0'");

            builder.Property (e => e.IpAddress)
                .IsRequired ()
                .HasColumnName ("ip_address")
                .HasColumnType ("varchar(45)")
                .HasDefaultValueSql ("'0'");

            builder.Property (e => e.LastActivity)
                .HasColumnName ("last_activity")
                .HasDefaultValueSql ("'0'");

            builder.Property (e => e.UserAgent)
                .IsRequired ()
                .HasColumnName ("user_agent")
                .HasColumnType ("varchar(120)");

            builder.Property (e => e.UserData)
                .IsRequired ()
                .HasColumnName ("user_data")
                .HasColumnType ("text");
        }
    }
}