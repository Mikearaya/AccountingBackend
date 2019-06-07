/*
 * @CreateTime: Jun 7, 2019 5:47 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 7, 2019 5:47 PM
 * @Description: Modify Here, Please 
 */
using System.Linq;
using BackendSecurity.Domain.SmartSystems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendSecurity.Persistance.SmartSystems {
    public class LookupConfiguration : IEntityTypeConfiguration<Lookup> {
        public void Configure (EntityTypeBuilder<Lookup> builder) {
            builder.ToTable ("lookup");

            builder.HasIndex (e => new { e.LookUpValue, e.LookUpType })
                .HasName ("unique_lookup")
                .IsUnique ();

            builder.Property (e => e.Id).HasColumnName ("id");

            builder.Property (e => e.LookUpType)
                .IsRequired ()
                .HasColumnName ("look_up_type")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.LookUpValue)
                .IsRequired ()
                .HasColumnName ("look_up_value")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.Status)
                .HasColumnName ("status")
                .HasColumnType ("tinyint(1)");
        }
    }
}