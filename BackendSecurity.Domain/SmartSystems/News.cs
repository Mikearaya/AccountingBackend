/*
 * @CreateTime: Jun 7, 2019 5:37 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 7, 2019 5:37 PM
 * @Description: Modify Here, Please 
 */
using System;

namespace BackendSecurity.Domain.SmartSystems {
    public class News {
        public uint Id { get; set; }
        public string Headding { get; set; }
        public string NewsContent { get; set; }
        public DateTime? Date { get; set; }
        public string PostBy { get; set; }
    }
}