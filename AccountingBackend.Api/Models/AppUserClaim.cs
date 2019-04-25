/*
 * @CreateTime: Apr 25, 2019 1:55 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 25, 2019 2:47 PM
 * @Description: Modify Here, Please 
 */
using Microsoft.AspNetCore.Identity;

namespace AccountingBackend.Api.Models {
    public class AppUserClaim : IdentityUserClaim<int> {
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

    }
}