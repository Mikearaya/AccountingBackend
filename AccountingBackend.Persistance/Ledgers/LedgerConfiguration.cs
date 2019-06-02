/*
 * @CreateTime: May 8, 2019 4:51 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 8, 2019 9:25 AM
 * @Description: Modify Here, Please 
 */
using AccountingBackend.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountingBackend.Persistance.Ledgers {
    public class LedgerConfiguration : IEntityTypeConfiguration<Ledger> {
        public void Configure (EntityTypeBuilder<Ledger> builder) {
            builder.ToTable ("ledger");

            builder.HasIndex (e => e.VoucherId)
                .HasName ("ledger_UN")
                .IsUnique ();

            builder.Property (e => e.Id).HasColumnType ("int(11)");

            builder.Property (e => e.Date)
                .HasColumnName ("date")
                .HasColumnType ("datetime");

            builder.Property (e => e.DateAdded)
                .HasColumnName ("date_added")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

            builder.Property (e => e.DateEt)
                .IsRequired ()
                .HasColumnName ("date_et")
                .HasColumnType ("varchar(10)");

            builder.Property (e => e.DateUpdated)
                .HasColumnName ("date_updated")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                .ValueGeneratedOnAddOrUpdate ();

            builder.Property (e => e.Description)
                .IsRequired ()
                .HasColumnName ("description")
                .HasColumnType ("varchar(100)");

            builder.Property (e => e.IsPosted)
                .HasColumnName ("is_posted")
                .HasColumnType ("tinyint(4)")
                .HasDefaultValueSql ("'0'");

            builder.Property (e => e.Reference)
                .HasColumnName ("reference")
                .HasColumnType ("varchar(100)");

            builder.Property (e => e.VoucherId)
                .IsRequired ()
                .HasColumnName ("voucher_id")
                .HasColumnType ("varchar(50)");
        }
    }
}