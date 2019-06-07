/*
 * @CreateTime: Jun 7, 2019 5:34 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 7, 2019 5:34 PM
 * @Description: Modify Here, Please 
 */
namespace BackendSecurity.Domain.SmartSystems {
    public class DepartmentGroupRole {

        public uint Id { get; set; }
        public uint? GroupId { get; set; }

        public virtual UserGroup Group { get; set; }
    }
}