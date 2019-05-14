/*
 * @CreateTime: Apr 30, 2019 6:31 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 8, 2019 9:24 AM
 * @Description: Modify Here, Please 
 */

using AccountingBackend.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountingBackend.Persistance.AccountCatagories {

    public class AccountCategoryConfiguration : IEntityTypeConfiguration<AccountCatagory> {
        public void Configure (EntityTypeBuilder<AccountCatagory> builder) {
            builder.ToTable ("account_catagory");

            builder.HasIndex (e => e.AccountTypeId)
                .HasName ("account_catagory_account_type_FK");

            builder.HasIndex (e => e.OverflowAccount)
                .HasName ("account_overflow_fk");

            builder.HasIndex (e => new { e.Catagory, e.AccountTypeId })
                .HasName ("catagory")
                .IsUnique ();

            builder.Property (e => e.Id)
                .HasColumnName ("ID")
                .HasColumnType ("int(11)");

            builder.Property (e => e.AccountTypeId).HasColumnName ("account_type_id");

            builder.Property (e => e.Catagory)
                .IsRequired ()
                .HasColumnName ("catagory")
                .HasColumnType ("varchar(100)");

            builder.Property (e => e.DateAdded)
                .HasColumnName ("date_added")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

            builder.Property (e => e.DateUpdated)
                .HasColumnName ("date_updated")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                .ValueGeneratedOnAddOrUpdate ();

            builder.Property (e => e.OverflowAccount)
                .HasColumnName ("overflow_account")
                .HasColumnType ("int(11)");

            builder.HasOne (d => d.AccountType)
                .WithMany (p => p.AccountCatagory)
                .HasForeignKey (d => d.AccountTypeId)
                .OnDelete (DeleteBehavior.ClientSetNull)
                .HasConstraintName ("account_catagory_account_type_FK");

            builder.HasOne (d => d.OverflowAccountNavigation)
                .WithMany (p => p.InverseOverflowAccountNavigation)
                .HasForeignKey (d => d.OverflowAccount)
                .HasConstraintName ("account_overflow_fk");

        }
    }
}