/*
 * @CreateTime: Apr 26, 2019 11:16 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 26, 2019 11:16 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq.Expressions;
using AccountingBackend.Domain.Identity;

namespace AccountingBackend.Application.Users.Models {
    public class UserViewModel {
        public string userName { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string id { get; set; }
        public string role { get; set; }
        public string roleId { get; set; }

        public static Expression<Func<ApplicationUser, UserViewModel>> Projection {

            get {
                return user => new UserViewModel () {
                    userName = user.UserName,
                    phoneNumber = user.PhoneNumber,
                    email = user.Email,
                    id = user.Id,
                };
            }

        }

        public static UserViewModel Create (ApplicationUser user) {
            return Projection.Compile ().Invoke (user);
        }
    }
}