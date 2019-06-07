/*
 * @CreateTime: Jun 7, 2019 5:48 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 7, 2019 5:48 PM
 * @Description: Modify Here, Please 
 */
using BackendSecurity.Domain.SmartSystems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendSecurity.Persistance.SmartSystems {
    public class MessagesConfiguration : IEntityTypeConfiguration<Messages> {
        public void Configure (EntityTypeBuilder<Messages> builder) {
            builder.HasKey (e => e.MessageId)
                .HasName ("PRIMARY");

            builder.ToTable ("messages");

            builder.Property (e => e.MessageId)
                .HasColumnName ("message_id")
                .HasColumnType ("int(20)");

            builder.Property (e => e.DateOfSent)
                .HasColumnName ("date_of_sent")
                .HasColumnType ("timestamp")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                .ValueGeneratedOnAddOrUpdate ();

            builder.Property (e => e.Draft)
                .HasColumnName ("draft")
                .HasColumnType ("tinyint(1)")
                .HasDefaultValueSql ("'0'");

            builder.Property (e => e.Message)
                .IsRequired ()
                .HasColumnName ("message")
                .HasColumnType ("text");

            builder.Property (e => e.ReadStatus)
                .HasColumnName ("read_status")
                .HasColumnType ("tinyint(4)")
                .HasDefaultValueSql ("'0'");

            builder.Property (e => e.SendBy)
                .IsRequired ()
                .HasColumnName ("send_by")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.SendTo)
                .HasColumnName ("send_to")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.StatusByReceiver)
                .IsRequired ()
                .HasColumnName ("status_by_receiver")
                .HasColumnType ("enum('Trash','Deleted','Active','')")
                .HasDefaultValueSql ("'Active'");

            builder.Property (e => e.StatusBySender)
                .IsRequired ()
                .HasColumnName ("status_by_sender")
                .HasColumnType ("enum('Trash','Deleted','Active','')")
                .HasDefaultValueSql ("'Active'");

            builder.Property (e => e.Subject)
                .HasColumnName ("subject")
                .HasColumnType ("varchar(250)");
        }
    }
}