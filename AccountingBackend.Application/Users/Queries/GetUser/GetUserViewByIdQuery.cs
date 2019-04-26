/*
 * @CreateTime: Apr 26, 2019 11:03 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 26, 2019 12:31 PM
 * @Description: Modify Here, Please 
 */
using AccountingBackend.Application.Users.Models;
using MediatR;

namespace AccountingBackend.Application.Users.Queries.GetUser {
    public class GetUserViewByIdQuery : IRequest<UserViewModel> {
        public string Id { get; set; }
    }
}