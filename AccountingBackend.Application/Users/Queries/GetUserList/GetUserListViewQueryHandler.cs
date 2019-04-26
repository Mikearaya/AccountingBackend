/*
 * @CreateTime: Apr 26, 2019 11:02 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 26, 2019 12:32 PM
 * @Description: Modify Here, Please 
 */

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Users.Models;
using BackendSecurity.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AccountingBackend.Application.Users.Queries.GetUserList {
    public class GetUserListViewQueryHandler : IRequestHandler<GetUsersListViewQuery, IEnumerable<UserViewModel>> {
        private readonly UserManager<ApplicationUser> _userManger;

        public GetUserListViewQueryHandler (
            UserManager<ApplicationUser> userManager
        ) {
            _userManger = userManager;
        }

        public async Task<IEnumerable<UserViewModel>> Handle (GetUsersListViewQuery request, CancellationToken cancellationToken) {
            return await _userManger.Users
                .Select (UserViewModel.Projection)
                .ToListAsync ();
        }
    }
}