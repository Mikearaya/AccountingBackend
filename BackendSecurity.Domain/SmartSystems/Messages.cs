/*
 * @CreateTime: Jun 7, 2019 5:36 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 7, 2019 5:36 PM
 * @Description: Modify Here, Please 
 */
using System;

namespace BackendSecurity.Domain.SmartSystems {
    public class Messages {
        public int MessageId { get; set; }
        public string SendBy { get; set; }
        public string SendTo { get; set; }
        public DateTime DateOfSent { get; set; }
        public string Message { get; set; }
        public string StatusBySender { get; set; }
        public string StatusByReceiver { get; set; }
        public sbyte ReadStatus { get; set; }
        public sbyte Draft { get; set; }
        public string Subject { get; set; }
    }
}