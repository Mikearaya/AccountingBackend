/*
 * @CreateTime: Apr 26, 2019 11:04 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 26, 2019 12:23 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Exceptions;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Application.Users.Models;
using AccountingBackend.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AccountingBackend.Application.Users.Commands.CreateUser {
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string> {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAccountingSecurityDatabase _database;

        public CreateUserCommandHandler (
            UserManager<ApplicationUser> userManager,
            IAccountingSecurityDatabase database
        ) {
            _userManager = userManager;
            _database = database;
        }

        public async Task<string> Handle (CreateUserCommand request, CancellationToken cancellationToken) {

            var userModel = new ApplicationUser () {
                UserName = request.userName,
                PasswordHash = "000000",

            };
            var result = await _userManager.CreateAsync (userModel, "000000");

            await _database.SaveAsync ();

            return userModel.Id;
            throw new Exception (result.Errors.ToString ());
        }
    }
}