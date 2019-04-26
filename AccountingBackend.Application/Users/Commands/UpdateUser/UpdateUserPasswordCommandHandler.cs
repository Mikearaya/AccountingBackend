/*
 * @CreateTime: Apr 26, 2019 11:09 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 26, 2019 12:29 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Exceptions;
using AccountingBackend.Application.Users.Models;
using BackendSecurity.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AccountingBackend.Application.Users.Commands.UpdateUser {
    public class UpdatePasswordCommandHandler : IRequestHandler<UpdateUserPasswordCommand, Unit> {
        private readonly UserManager<ApplicationUser> _userManager;

        public UpdatePasswordCommandHandler (UserManager<ApplicationUser> userManager) {
            _userManager = userManager;
        }

        public async Task<Unit> Handle (UpdateUserPasswordCommand request, CancellationToken cancellationToken) {
            var user = await _userManager.FindByIdAsync (request.Id);

            if (user == null) {
                throw new NotFoundException ("User", request.Id);
            }

            var result = await _userManager.ChangePasswordAsync (user, request.CurrentPassword, request.NewPassword);

            if (!result.Succeeded) {
                throw new Exception (result.Errors.ToString ());
            }
            return Unit.Value;;

        }
    }
}