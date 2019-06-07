/*
 * @CreateTime: Jun 7, 2019 5:51 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 7, 2019 5:51 PM
 * @Description: Modify Here, Please 
 */
using BackendSecurity.Domain.SmartSystems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendSecurity.Persistance.SmartSystems {
    public class NewsConfiguration : IEntityTypeConfiguration<News> {
        public void Configure (EntityTypeBuilder<News> builder) {
            builder.ToTable ("news");

            builder.Property (e => e.Id).HasColumnName ("id");

            builder.Property (e => e.Date)
                .HasColumnName ("date")
                .HasColumnType ("date");

            builder.Property (e => e.Headding)
                .HasColumnName ("headding")
                .HasColumnType ("text");

            builder.Property (e => e.NewsContent)
                .HasColumnName ("news_content")
                .HasColumnType ("text");

            builder.Property (e => e.PostBy)
                .HasColumnName ("post_by")
                .HasColumnType ("varchar(8)");
        }
    }
}