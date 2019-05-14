/*
 * @CreateTime: Apr 30, 2019 6:30 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 30, 2019 6:30 AM
 * @Description: Modify Here, Please 
 */
using AccountingBackend.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountingBackend.Persistance.AccountTypes {
    public class AccountTypeConfiguration : IEntityTypeConfiguration<AccountType> {
        public void Configure (EntityTypeBuilder<AccountType> builder) {
            builder.ToTable ("account_type");

            builder.HasIndex (e => e.TypeOf)
                .HasName ("defult_account_type_fk");

            builder.HasIndex (e => new { e.Type, e.TypeOf })
                .HasName ("type")
                .IsUnique ();

            builder.Property (e => e.Id).HasColumnName ("ID");

            builder.Property (e => e.IsSummery)
                .HasColumnName ("is_summery")
                .HasColumnType ("tinyint(4)")
                .HasDefaultValueSql ("'0'");

            builder.Property (e => e.Type)
                .IsRequired ()
                .HasColumnName ("type")
                .HasColumnType ("varchar(20)");

            builder.Property (e => e.TypeOf).HasColumnName ("type_of");

            builder.HasOne (d => d.TypeOfNavigation)
                .WithMany (p => p.InverseTypeOfNavigation)
                .HasForeignKey (d => d.TypeOf)
                .HasConstraintName ("defult_account_type_fk");
        }
    }
}