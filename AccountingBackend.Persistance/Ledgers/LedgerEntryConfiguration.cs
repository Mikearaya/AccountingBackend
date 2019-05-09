/*
 * @CreateTime: May 9, 2019 7:59 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 9, 2019 8:02 AM
 * @Description: Modify Here, Please 
 */
using AccountingBackend.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountingBackend.Persistance.Ledgers {
    public class LedgerEntryConfiguration : IEntityTypeConfiguration<LedgerEntry> {
        public void Configure (EntityTypeBuilder<LedgerEntry> builder) {
            builder.ToTable ("ledger_entry");

            builder.HasIndex (e => e.AccountId)
                .HasName ("ledger_entry_FK");

            builder.HasIndex (e => e.LedgerId)
                .HasName ("ledger_entry_FK_1");

            builder.Property (e => e.Id).HasColumnType ("int(11)");

            builder.Property (e => e.AccountId)
                .HasColumnName ("ACCOUNT_ID")
                .HasColumnType ("int(11)");

            builder.Property (e => e.Credit)
                .HasColumnName ("credit")
                .HasDefaultValueSql ("'0'");

            builder.Property (e => e.DateAdded)
                .HasColumnName ("date_added")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

            builder.Property (e => e.DateUpdated)
                .HasColumnName ("date_updated")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                .ValueGeneratedOnAddOrUpdate ();

            builder.Property (e => e.Debit)
                .HasColumnName ("debit")
                .HasDefaultValueSql ("'0'");

            builder.Property (e => e.LedgerId)
                .HasColumnName ("LEDGER_ID")
                .HasColumnType ("int(11)");

            builder.HasOne (d => d.Account)
                .WithMany (p => p.LedgerEntry)
                .HasForeignKey (d => d.AccountId)
                .OnDelete (DeleteBehavior.ClientSetNull)
                .HasConstraintName ("ledger_entry_FK");

            builder.HasOne (d => d.Ledger)
                .WithMany (p => p.LedgerEntry)
                .HasForeignKey (d => d.LedgerId)
                .HasConstraintName ("ledger_entry_FK_1");

        }
    }
}