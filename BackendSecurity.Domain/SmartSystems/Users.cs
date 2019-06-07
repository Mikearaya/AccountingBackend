/*
 * @CreateTime: Jun 7, 2019 5:38 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 7, 2019 5:38 PM
 * @Description: Modify Here, Please 
 */
using System;

namespace BackendSecurity.Domain.SmartSystems {
    public class Users {

        public string EmployeeId { get; set; }
        public uint? GroupId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public string Status { get; set; }

        public virtual UserGroup Group { get; set; }
    }
}