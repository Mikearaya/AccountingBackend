using System.Threading;
using System.Threading.Tasks;
/*
 * @CreateTime: May 14, 2019 3:09 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 14, 2019 3:16 PM
 * @Description: Modify Here, Please 
 */
using AccountingBackend.Application.AccountTypes.Commands.UpdateAccountType;
using AccountingBackend.Application.Exceptions;
using MediatR;
using Xunit;

namespace AccountingBackend.Application.Test.AccountTypes.Commands.UpdateAccountType {
    public class UpdateAccountTypeCommandHandlerShould : DatabaseTestBase {

        [Fact]
        public async Task UpdateAccountTypeSuccessfuly () {
            // Arrange
            UpdateAccountTypeCommand command = new UpdateAccountTypeCommand () {
                Id = 6,
                Type = "Account Payable",
                IsTypeOf = 12
            };
            UpdateAccountTypeCommandHandler handler = new UpdateAccountTypeCommandHandler (_Database);
            // Act
            var result = await handler.Handle (command, CancellationToken.None);

            // Assert
            Assert.Equal (Unit.Value, result);
        }

        [Fact]
        public void ThrowNotFoundExceptionWhenProvidedNonExistingAccountId () {
            // Arrange
            UpdateAccountTypeCommand command = new UpdateAccountTypeCommand () {
                Id = 100,
                Type = "Account Payable",
                IsTypeOf = 12
            };
            UpdateAccountTypeCommandHandler handler = new UpdateAccountTypeCommandHandler (_Database);
            Assert.ThrowsAsync<NotFoundException> (() => handler.Handle (command, CancellationToken.None));

            // Assert
        }

    }
}