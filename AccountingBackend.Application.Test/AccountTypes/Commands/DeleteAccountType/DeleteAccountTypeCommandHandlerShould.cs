/*
 * @CreateTime: May 14, 2019 2:18 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 14, 2019 2:58 PM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.AccountTypes.Commands.DeleteAccountType;
using AccountingBackend.Application.Exceptions;
using MediatR;
using Xunit;

namespace AccountingBackend.Application.Test.AccountTypes.Commands.DeleteAccountType {
    public class DeleteAccountTypeCommandHandlerShould : DatabaseTestBase {

        /// <summary>
        /// tests the successful deletion of account type
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task DeleteAccountTypeSuccessfuly () {
            // Arrange
            DeleteAccountTypeCommand command = new DeleteAccountTypeCommand () {
                Id = 6
            };
            DeleteAccountTypeCommandHandler handler = new DeleteAccountTypeCommandHandler (_Database);
            // Act
            var result = await handler.Handle (command, CancellationToken.None);
            // Assert
            Assert.Equal (result, Unit.Value);
        }

        /// <summary>
        /// tests the throwing of error when attempting to delete account type that doesnt exists
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ThrowNotFoundExceptionForIdNotExists () {
            // Arrange
            DeleteAccountTypeCommand command = new DeleteAccountTypeCommand () {
                Id = 100
            };
            DeleteAccountTypeCommandHandler handler = new DeleteAccountTypeCommandHandler (_Database);
            // Act
            await Assert.ThrowsAsync<NotFoundException> (() => handler.Handle (command, CancellationToken.None));

        }

        /// <summary>
        /// tests the successful validation exception return when attempting to delete system defined account types
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ThrowsValidationExceptionWhenDeleteingSystemType () {
            // Arrange
            DeleteAccountTypeCommand command = new DeleteAccountTypeCommand () {
                Id = 10
            };
            DeleteAccountTypeCommandHandler handler = new DeleteAccountTypeCommandHandler (_Database);
            // Act
            await Assert.ThrowsAsync<ValidationException> (() => handler.Handle (command, CancellationToken.None));
        }
    }
}