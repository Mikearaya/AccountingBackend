/*
 * @CreateTime: Apr 29, 2019 8:05 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 29, 2019 10:38 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Application.Users.Commands.CreateUser;
using BackendSecurity.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Moq;
using Xunit;

namespace AccountingBackend.Application.Test.Users.Commands.CreateUser {
    public class CreateUserCommandHandlerShould {

        private readonly Mock<UserManager<ApplicationUser>> _MockUserManager;
        private readonly Mock<ISecurityDatabaseService> _MockSecurityDatabase;

        private readonly Mock<IUserStore<ApplicationUser>> _MockUserStore;

        public CreateUserCommandHandlerShould () {

            _MockSecurityDatabase = new Mock<ISecurityDatabaseService> ();
            _MockUserStore = new Mock<IUserStore<ApplicationUser>> ();

            _MockUserManager = new Mock<UserManager<ApplicationUser>> (_MockUserStore.Object, null, null, null, null, null, null, null, null);

            _MockUserManager.Setup (c => c.CreateAsync (new ApplicationUser () {

                UserName = "Mikearaya",
                    PasswordHash = "000000",

            })).ReturnsAsync (new IdentityResult ());

        }
        //TODO: figure out the correct way to test user manager
        [Fact]
        public void BeInstantiatedAsync () {

            // Arrange
            IRequestHandler<CreateUserCommand, string> handler = new CreateUserCommandHandler (_MockUserManager.Object);
            var builder = new StringBuilder ();
            // Act
            var result = handler.Handle (new CreateUserCommand () { userName = "mikae" }, default);

            // Assert

            result.Equals (false);
        }

    }
}