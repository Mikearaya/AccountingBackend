/*
 * @CreateTime: May 2, 2019 5:27 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 10, 2019 1:06 PM
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
    public class CreateAccountCommandHandlerShould : DatabaseTestBase {
        private CreateAccountCommandHandler handler;

        private CreateAccountCommand accountModel;

        [Fact]
        public async Task CreateAccountSuccessfuly () {
            // Arrange
            handler = new CreateAccountCommandHandler (_Database);
            accountModel = new CreateAccountCommand () {
                AccountId = "0000",
                Name = "Cash",
                Active = 0,
                CatagoryId = 1,
                OpeningBalance = 100,
                CostCenterId = 1
            };

            // Act
            var response = await handler.Handle (accountModel, CancellationToken.None);

            // Assert
            Assert.NotEqual (0, response);

        }
    }
}