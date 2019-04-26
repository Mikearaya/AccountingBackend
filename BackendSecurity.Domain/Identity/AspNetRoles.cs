/*
 * @CreateTime: Apr 25, 2019 3:11 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 25, 2019 3:11 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace BackendSecurity.Domain.Identity {
    public partial class ApplicationRole : IdentityRole<string> {
        public ApplicationRole () {
            AspNetRoleClaims = new HashSet<AspNetRoleClaims> ();
            AspNetUserRoles = new HashSet<AspNetUserRoles> ();
        }
        public string Access { get; set; }
        public ICollection<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
    }
}