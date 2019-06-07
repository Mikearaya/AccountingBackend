/*
 * @CreateTime: Jun 7, 2019 5:34 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 7, 2019 5:34 PM
 * @Description: Modify Here, Please 
 */
namespace BackendSecurity.Domain.SmartSystems {
    public class CiSessions {
        public string SessionId { get; set; }
        public string IpAddress { get; set; }
        public string UserAgent { get; set; }
        public uint LastActivity { get; set; }
        public string UserData { get; set; }
    }
}