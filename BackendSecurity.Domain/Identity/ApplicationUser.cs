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
    public class ApplicationUser : IdentityUser<string> {
        public ApplicationUser () {
            AspNetUserClaims = new HashSet<ApplicationUserClaims> ();
            AspNetUserLogins = new HashSet<AspNetUserLogins> ();
            AspNetUserRoles = new HashSet<AspNetUserRoles> ();
            AspNetUserTokens = new HashSet<AspNetUserTokens> ();
        }

        public ICollection<ApplicationUserClaims> AspNetUserClaims { get; set; }
        public ICollection<AspNetUserLogins> AspNetUserLogins { get; set; }
        public ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
        public ICollection<AspNetUserTokens> AspNetUserTokens { get; set; }
    }
}