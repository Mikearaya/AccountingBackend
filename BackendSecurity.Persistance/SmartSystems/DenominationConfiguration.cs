using BackendSecurity.Domain.SmartSystems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendSecurity.Persistance.SmartSystems {
    public class DenominationConfiguration : IEntityTypeConfiguration<Denomination> {
        public void Configure (EntityTypeBuilder<Denomination> builder) {
            builder.ToTable ("denomination");

            builder.HasIndex (e => e.Birr)
                .HasName ("unique_denomination")
                .IsUnique ();

            builder.Property (e => e.Id).HasColumnName ("id");

            builder.Property (e => e.Amount)
                .HasColumnName ("amount")
                .HasColumnType ("int(11)");

            builder.Property (e => e.Birr)
                .HasColumnName ("birr")
                .HasColumnType ("varchar(45)");
        }
    }
}