/*
 * @CreateTime: May 3, 2019 10:10 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 7, 2019 4:47 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Accounts.Commands.DeleteAccount;
using AccountingBackend.Application.Exceptions;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Domain;
using MediatR;
using Moq;
using Xunit;

namespace AccountingBackend.Application.Test.Accounts.Commands.DeleteAccount {
    public class DeleteAccountCommandShould : DatabaseTestBase {

        [Fact]
        public async Task DeleteAccountSuccessfuly () {
            // Arrange
            DeleteAccountCommandHandler handler = new DeleteAccountCommandHandler (_Database);
            //Act
            var result = await handler.Handle (new DeleteAccountCommand () { Id = 10 }, CancellationToken.None);
            //Assert
            Assert.Equal (Unit.Value, result);

        }

        [Fact]
        public async Task ThrowNotFoundExceptionForAccountIdThatDoesnotExist () {
            // Arrange
            DeleteAccountCommandHandler handler = new DeleteAccountCommandHandler (_Database);

            await Assert.ThrowsAsync<NotFoundException> (() => handler.Handle (new DeleteAccountCommand () { Id = 2 }, CancellationToken.None));
        }
    }
}