/*
 * @CreateTime: Apr 26, 2019 11:02 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 26, 2019 12:32 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using AccountingBackend.Application.Users.Models;
using MediatR;

namespace AccountingBackend.Application.Users.Queries.GetUserList {
    public class GetUsersListViewQuery : IRequest<IEnumerable<UserViewModel>> {

    }
}