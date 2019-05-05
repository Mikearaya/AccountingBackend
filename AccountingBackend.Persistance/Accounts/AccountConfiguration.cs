/*
 * @CreateTime: May 2, 2019 3:20 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 2, 2019 6:48 PM
 * @Description: Modify Here, Please 
 */
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

            builder.HasIndex (e => new { e.Year, e.Id })
                .HasName ("account_year_UN")
                .IsUnique ();

            builder.Property (e => e.Id)
                .HasColumnName ("ID")
                .HasColumnType ("int(11)");

            builder.Property (e => e.AccountId)
                .IsRequired ()
                .HasColumnType ("varchar(20)");

            builder.Property (e => e.AccountName)
                .IsRequired ()
                .HasColumnName ("account_name")
                .HasColumnType ("varchar(100)");

            builder.Property (e => e.Active)
                .HasColumnName ("active")
                .HasColumnType ("tinyint(4)")
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
                .HasColumnType ("int(11)");

            builder.Property (e => e.Year)
                .IsRequired ()
                .HasColumnName ("year")
                .HasColumnType ("varchar(4)");

            builder.HasOne (d => d.Catagory)
                .WithMany (p => p.Account)
                .HasForeignKey (d => d.CatagoryId)
                .OnDelete (DeleteBehavior.ClientSetNull)
                .HasConstraintName ("account_account_catagory_FK");

            builder.HasOne (d => d.ParentAccountNavigation)
                .WithMany (p => p.InverseParentAccountNavigation)
                .HasForeignKey (d => d.ParentAccount)
                .OnDelete (DeleteBehavior.Cascade)
                .HasConstraintName ("account_account_FK");
        }
    }
}