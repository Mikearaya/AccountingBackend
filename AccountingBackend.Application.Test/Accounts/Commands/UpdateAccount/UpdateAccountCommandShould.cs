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
    public class UpdateAccountCommandShould {
        Mock<IAccountingDatabaseService> MockDatabase;
        private UpdateAccountCommandHandler handler;
        private UpdateAccountCommand updateCommand;
        private Account account;
        public UpdateAccountCommandShould () {

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
            MockDatabase.Setup (d => d.Account.Update (account));

        }

        [Fact]
        public async Task UpdateAccountSuccessfuly () {
            // Arrange
            updateCommand = new UpdateAccountCommand () {
                Id = 1,
                AccountId = "0000",
                Name = "Account Payable Update",
                Active = 1,
                ParentAccount = 1,
            };

            MockDatabase.Setup (d => d.Account.Update (account));

            handler = new UpdateAccountCommandHandler (MockDatabase.Object);
            // Act
            var result = await handler.Handle (updateCommand, CancellationToken.None);
            // Assert
            Assert.Equal (Unit.Value, result);
            Assert.Equal ("0000", account.AccountId);
            Assert.Equal ("Account Payable Update", account.AccountName);
            account.Active.Equals (0);
            Assert.Equal (1, account.ParentAccount);
        }

        [Fact]
        public async Task ThrowNotFoundExceptionForNonExistingAccountId () {
            // Arrange
            updateCommand = new UpdateAccountCommand () {
                Id = 2,
                AccountId = "0000",
                Name = "Account Payable Update",
                Active = 1,
                ParentAccount = 1,
            };
            handler = new UpdateAccountCommandHandler (MockDatabase.Object);

            await Assert.ThrowsAsync<NotFoundException> (() => handler.Handle (updateCommand, CancellationToken.None));

        }
    }
}