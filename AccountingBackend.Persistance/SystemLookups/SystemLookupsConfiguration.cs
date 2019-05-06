/*
 * @CreateTime: May 6, 2019 10:31 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 6, 2019 10:32 AM
 * @Description: Modify Here, Please 
 */
using AccountingBackend.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountingBackend.Persistance.SystemLookups {
    public class SystemLookupsConfiguration : IEntityTypeConfiguration<SystemLookup> {
        public void Configure (EntityTypeBuilder<SystemLookup> builder) {
            builder.ToTable ("system_lookup");

            builder.Property (e => e.Id).HasColumnType ("int(11)");

            builder.Property (e => e.DateAdded)
                .HasColumnName ("date_added")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

            builder.Property (e => e.DateUpdated)
                .HasColumnName ("date_updated")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                .ValueGeneratedOnAddOrUpdate ();

            builder.Property (e => e.Type)
                .IsRequired ()
                .HasColumnName ("type")
                .HasColumnType ("varchar(100)");

            builder.Property (e => e.Value)
                .IsRequired ()
                .HasColumnName ("value")
                .HasColumnType ("varchar(100)");
        }
    }
}