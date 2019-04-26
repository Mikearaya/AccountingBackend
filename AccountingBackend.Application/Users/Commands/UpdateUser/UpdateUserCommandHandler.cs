/*
 * @CreateTime: Apr 26, 2019 11:11 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 26, 2019 12:27 PM
 * @Description: Modify Here, Please 
 */

using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Exceptions;
using AccountingBackend.Application.Users.Models;
using AccountingBackend.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AccountingBackend.Application.Users.Commands.UpdateUser {
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand> {
        private readonly UserManager<ApplicationUser> _userManager;

        public UpdateUserCommandHandler (
            UserManager<ApplicationUser> userManager
        ) {
            _userManager = userManager;
        }

        public async Task<Unit> Handle (UpdateUserCommand request, CancellationToken cancellationToken) {
            var user = await _userManager.Users
                .FirstOrDefaultAsync (u => u.Id == request.Id);

            if (user == null) {
                throw new NotFoundException ("User", request.Id);
            }

            user.UserName = request.UserName;
            user.Email = request.Email;
            user.PhoneNumber = request.PhoneNumber;

            await _userManager.UpdateAsync (user);

            return Unit.Value;
        }
    }
}