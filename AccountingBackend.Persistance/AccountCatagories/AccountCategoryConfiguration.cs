/*
 * @CreateTime: Apr 30, 2019 6:31 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 30, 2019 6:32 AM
 * @Description: Modify Here, Please 
 */

using AccountingBackend.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountingBackend.Persistance.AccountCatagories {

    public class AccountCategoryConfiguration : IEntityTypeConfiguration<AccountCatagory> {
        public void Configure (EntityTypeBuilder<AccountCatagory> builder) {
            builder.ToTable ("account_catagory");

            builder.HasIndex (e => e.Id)
                .HasName ("account_catagory_ID_IDX");

            builder.HasIndex (e => e.Type)
                .HasName ("account_catagory_account_type_FK");

            builder.Property (e => e.Id)
                .HasColumnName ("ID")
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

            builder.Property (e => e.Type)
                .IsRequired ()
                .HasColumnName ("type")
                .HasColumnType ("varchar(20)");

            builder.HasOne (d => d.TypeNavigation)
                .WithMany (p => p.AccountCatagory)
                .HasForeignKey (d => d.Type)
                .HasConstraintName ("account_catagory_account_type_FK");

        }
    }
}