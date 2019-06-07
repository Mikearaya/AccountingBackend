using System.Collections.Generic;

namespace BackendSecurity.Domain.SmartSystems {
    public class UserGroup {
        public UserGroup () {
            DepartmentGroupRole = new HashSet<DepartmentGroupRole> ();
            Users = new HashSet<Users> ();
        }

        public uint Id { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<DepartmentGroupRole> DepartmentGroupRole { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}