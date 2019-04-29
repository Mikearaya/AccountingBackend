/*
 * @CreateTime: Apr 26, 2019 12:22 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 29, 2019 10:04 AM
 * @Description: Modify Here, Please 
 */

using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace AccountingBackend.Application.Users.Commands.CreateUser {
    public class CreateUserCommand : IRequest<string> {
        [Required]
        public string userName { get; set; }
    }
}