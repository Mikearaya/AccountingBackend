/*
 * @CreateTime: Apr 26, 2019 11:16 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 26, 2019 12:25 PM
 * @Description: Modify Here, Please 
 */
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace AccountingBackend.Application.Users.Commands.DeleteUser {
    public class DeleteUserCommand : IRequest {
        [Required]
        public string Id { get; set; }
    }
}