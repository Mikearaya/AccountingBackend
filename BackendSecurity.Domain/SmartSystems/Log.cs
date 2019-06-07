/*
 * @CreateTime: Jun 7, 2019 5:56 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 7, 2019 5:56 PM
 * @Description: Modify Here, Please 
 */
using System;

namespace BackendSecurity.Domain.SmartSystems {
    public class Log {
        public uint LogId { get; set; }
        public string Table { get; set; }
        public string UniqueId { get; set; }
        public string Action { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public DateTime? Time { get; set; }

    }
}