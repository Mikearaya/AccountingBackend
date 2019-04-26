/*
 * @CreateTime: Apr 26, 2019 10:39 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 26, 2019 10:39 AM
 * @Description: Modify Here, Please 
 */
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace AccountingBackend.Application.Models {
    public class AuthenticationQuery : IRequest<AppUserAuth> {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

    }
}