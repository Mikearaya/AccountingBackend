/*
 * @CreateTime: Jun 7, 2019 5:50 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 7, 2019 5:50 PM
 * @Description: Modify Here, Please 
 */
using BackendSecurity.Domain.SmartSystems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendSecurity.Persistance.SmartSystems {
    public class MyReportConfiguration : IEntityTypeConfiguration<MyReport> {
        public void Configure (EntityTypeBuilder<MyReport> builder) {

            builder.ToTable ("my_report");

            builder.Property (e => e.Id).HasColumnName ("id");

            builder.Property (e => e.BaseReport)
                .HasColumnName ("base_report")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.Description)
                .HasColumnName ("description")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.MyOptions)
                .HasColumnName ("my_options")
                .HasColumnType ("text");

            builder.Property (e => e.ReportOwner)
                .HasColumnName ("report_owner")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.ReportStatus)
                .HasColumnName ("report_status")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.ReportTitle)
                .HasColumnName ("report_title")
                .HasColumnType ("varchar(45)");
        }
    }
}