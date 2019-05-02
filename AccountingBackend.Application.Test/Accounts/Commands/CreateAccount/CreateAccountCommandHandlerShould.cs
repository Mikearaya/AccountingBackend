/*
 * @CreateTime: May 2, 2019 5:27 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 2, 2019 6:52 PM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Accounts.Commands.CreateAccount;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Domain;
using Moq;
using Xunit;

namespace AccountingBackend.Application.Test.Accounts.Commands.CreateAccount {
    public class CreateAccountCommandHandlerShould {
        private CreateAccountCommandHandler handler;

        private CreateAccountCommand accountModel;
        Mock<IAccountingDatabaseService> Mockdatabase;
        public CreateAccountCommandHandlerShould () {
            Mockdatabase = new Mock<IAccountingDatabaseService> ();
            Mockdatabase.Setup (d => d.SaveAsync ());

            Mockdatabase.Setup (d => d.SaveAsync ()).Returns (Task.CompletedTask);
        }

        [Fact]
        public async Task CreateAccountSuccessfuly () {
            // Arrange
            Mockdatabase.Setup (d => d.Account.Add (new Account () {

                AccountId = "0000",
                    AccountName = "Cash",
                    Active = 0,
                    CatagoryId = 1,
                    OpeningBalance = 100
            }));

            handler = new CreateAccountCommandHandler (Mockdatabase.Object);
            accountModel = new CreateAccountCommand () {
                Id = "0000",
                Name = "Cash",
                Active = 0,
                CatagoriId = 1,
                OpeningBalance = 100,
                OrganizationId = 1,
            };

            // Act
            var response = await handler.Handle (accountModel, CancellationToken.None);

            // Assert
            Assert.Equal (0, response);

        }
    }
}