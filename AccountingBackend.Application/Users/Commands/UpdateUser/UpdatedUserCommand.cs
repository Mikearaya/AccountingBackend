/*
 * @CreateTime: Apr 26, 2019 11:16 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 26, 2019 12:27 PM
 * @Description: Modify Here, Please 
 */
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace AccountingBackend.Application.Users.Commands.UpdateUser {
    public class UpdateUserCommand : IRequest {
        [Required]
        public string Id { get; set; }

        [Required]
        public string UserName { get; set; }

        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}