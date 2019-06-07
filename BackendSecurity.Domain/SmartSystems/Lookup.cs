/*
 * @CreateTime: Jun 7, 2019 5:35 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 7, 2019 5:35 PM
 * @Description: Modify Here, Please 
 */
namespace BackendSecurity.Domain.SmartSystems {
    public class Lookup {
        public uint Id { get; set; }
        public string LookUpType { get; set; }
        public string LookUpValue { get; set; }
        public sbyte? Status { get; set; }
    }
}