/*
 * @CreateTime: May 3, 2019 8:50 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 3, 2019 9:28 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Accounts.Commands.UpdateAccount;
using AccountingBackend.Application.Exceptions;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Domain;
using MediatR;
using Moq;
using Xunit;

namespace AccountingBackend.Application.Test.Accounts.Commands.UpdateAccount {
    public class UpdateAccountCommandShould : DatabaseTestBase {

        [Fact]
        public async Task UpdateAccountSuccessfuly () {
            // Arrange
            UpdateAccountCommand updateCommand = new UpdateAccountCommand () {
                Id = 10,
                AccountId = "0000",
                Name = "Account Payable Update",
                Active = 1,
                ParentAccount = 1,
            };

            UpdateAccountCommandHandler handler = new UpdateAccountCommandHandler (_Database);
            // Act
            var result = await handler.Handle (updateCommand, CancellationToken.None);
            // Assert
            Assert.Equal (Unit.Value, result);
        }

        [Fact]
        public async Task ThrowNotFoundExceptionForNonExistingAccountId () {
            // Arrange
            UpdateAccountCommand updateCommand = new UpdateAccountCommand () {
                Id = 2,
                AccountId = "0000",
                Name = "Account Payable Update",
                Active = 1,
                ParentAccount = 1,
            };
            UpdateAccountCommandHandler handler = new UpdateAccountCommandHandler (_Database);

            await Assert.ThrowsAsync<NotFoundException> (() => handler.Handle (updateCommand, CancellationToken.None));

        }
    }
}