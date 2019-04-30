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
            builder.HasKey (e => e.Type)
                .HasName ("PRIMARY");

            builder.ToTable ("account_type");

            builder.HasIndex (e => e.Type)
                .HasName ("account_type_type_IDX");

            builder.Property (e => e.Type)
                .HasColumnName ("type")
                .HasColumnType ("varchar(20)");
        }
    }
}