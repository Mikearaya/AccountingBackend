/*
 * @CreateTime: May 3, 2019 10:10 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 3, 2019 10:24 AM
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
    public class DeleteAccountCommandShould {
        private Mock<IAccountingDatabaseService> MockDatabase;
        private DeleteAccountCommandHandler handler;
        private Account account;
        public DeleteAccountCommandShould () {
            MockDatabase = new Mock<IAccountingDatabaseService> ();

            account = new Account () {
                Id = 1,
                AccountId = "0002",
                AccountName = "Account Payble",
                Active = 0,
                CatagoryId = 1,
                ParentAccount = 2,
                OpeningBalance = 200,
                DateUpdated = DateTime.Now,
                Year = "1990",
            };

            MockDatabase.Setup (d => d.SaveAsync ()).Returns (Task.CompletedTask);
            MockDatabase.Setup (d => d.Account.FindAsync (1)).ReturnsAsync (account);
        }

        [Fact]
        public async Task DeleteAccountSuccessfuly () {
            // Arrange
            handler = new DeleteAccountCommandHandler (MockDatabase.Object);
            //Act
            var result = await handler.Handle (new DeleteAccountCommand () { Id = 1 }, CancellationToken.None);
            //Assert
            Assert.Equal (Unit.Value, result);

        }

        [Fact]
        public async Task ThrowNotFoundExceptionForAccountIdThatDoesnotExist () {
            // Arrange
            handler = new DeleteAccountCommandHandler (MockDatabase.Object);

            await Assert.ThrowsAsync<NotFoundException> (() => handler.Handle (new DeleteAccountCommand () { Id = 2 }, CancellationToken.None));
        }
    }
}