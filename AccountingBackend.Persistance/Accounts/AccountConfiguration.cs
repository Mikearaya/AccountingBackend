using AccountingBackend.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountingBackend.Persistance.Accounts {
    public class AccountConfiguration : IEntityTypeConfiguration<Account> {
        public void Configure (EntityTypeBuilder<Account> builder) {
            builder.ToTable ("account");

            builder.HasIndex (e => e.CatagoryId)
                .HasName ("account_account_catagory_FK");

            builder.HasIndex (e => e.ParentAccount)
                .HasName ("account_account_FK");

            builder.Property (e => e.Id)
                .HasColumnName ("ID")
                .HasColumnType ("varchar(10)");

            builder.Property (e => e.AccountName)
                .IsRequired ()
                .HasColumnName ("account_name")
                .HasColumnType ("varchar(100)");

            builder.Property (e => e.Active)
                .HasColumnName ("active")
                .HasColumnType ("tinyint(1)")
                .HasDefaultValueSql ("'1'");

            builder.Property (e => e.CatagoryId)
                .HasColumnName ("CATAGORY_ID")
                .HasColumnType ("int(11)");

            builder.Property (e => e.DateAdded)
                .HasColumnName ("date_added")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

            builder.Property (e => e.DateUpdated)
                .HasColumnName ("date_updated")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                .ValueGeneratedOnAddOrUpdate ();

            builder.Property (e => e.OpeningBalance)
                .HasColumnName ("opening_balance")
                .HasDefaultValueSql ("'0'");

            builder.Property (e => e.ParentAccount)
                .HasColumnName ("parent_account")
                .HasColumnType ("varchar(10)");

            builder.HasOne (d => d.Catagory)
                .WithMany (p => p.Account)
                .HasForeignKey (d => d.CatagoryId)
                .OnDelete (DeleteBehavior.ClientSetNull)
                .HasConstraintName ("account_account_catagory_FK");

            builder.HasOne (d => d.ParentAccountNavigation)
                .WithMany (p => p.InverseParentAccountNavigation)
                .HasForeignKey (d => d.ParentAccount)
                .HasConstraintName ("account_account_FK");
        }
    }
}