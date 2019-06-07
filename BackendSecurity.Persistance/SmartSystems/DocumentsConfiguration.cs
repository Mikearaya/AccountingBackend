/*
 * @CreateTime: Jun 7, 2019 5:43 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 7, 2019 5:43 PM
 * @Description: Modify Here, Please 
 */
using BackendSecurity.Domain.SmartSystems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendSecurity.Persistance.SmartSystems {
    public class DocumentsConfiguration : IEntityTypeConfiguration<Documents> {
        public void Configure (EntityTypeBuilder<Documents> builder) {
            builder.ToTable ("documents");

            builder.Property (e => e.Id).HasColumnName ("id");

            builder.Property (e => e.Description)
                .HasColumnName ("description")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.DocumentType)
                .HasColumnName ("document_type")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.Path)
                .HasColumnName ("path")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.Title)
                .HasColumnName ("title")
                .HasColumnType ("varchar(45)");

        }
    }
}