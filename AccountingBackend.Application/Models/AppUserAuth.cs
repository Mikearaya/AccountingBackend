/*
 * @CreateTime: Apr 25, 2019 2:33 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 7, 2019 4:51 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BackendSecurity.Domain.Identity;

namespace AccountingBackend.Application.Models {
    public class AppUserAuth {

        public AppUserAuth () : base () {
            UserName = "Not Authorized";
            BearerToken = string.Empty;
        }
        public string UserName { get; set; }
        public string BearerToken { get; set; }
        public bool IsAuthenticated { get; set; }
        public List<ApplicationUserClaims> Claims { get; set; }

    }
}