/*
 * @CreateTime: Jan 27, 2019 7:14 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 26, 2019 10:49 AM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Exceptions;
using AccountingBackend.Application.Models;
using AccountingBackend.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AccountingBackend.Application.Security {
    public class AuthenticationQueryHandler : IRequestHandler<AuthenticationQuery, AppUserAuth> {
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthenticationQueryHandler (UserManager<ApplicationUser> userManager) {
            _userManager = userManager;
        }
        public async Task<AppUserAuth> Handle (AuthenticationQuery request, CancellationToken cancellationToken) {
            var user = await _userManager.FindByNameAsync (request.UserName);

            if (user != null && await _userManager.CheckPasswordAsync (user, request.Password)) {
                return new AppUserAuth ();
            }
            throw new NotFoundException ("Username or password not correct");

        }
    }
}