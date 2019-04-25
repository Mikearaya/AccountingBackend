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

namespace AccountingBackend.Domain.Identity {
    public partial class AspNetUserClaims : IdentityUserClaim<string> {

        public ApplicationUser User { get; set; }
    }
}