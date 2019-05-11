/*
 * @CreateTime: May 8, 2019 4:04 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 8, 2019 4:13 AM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Exceptions;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Application.SystemLookups.Commands.DeleteSystemLookup;
using AccountingBackend.Domain;
using MediatR;
using Moq;
using Xunit;

namespace AccountingBackend.Application.Test.SystemLookups.Commands.DeleteSystemLookup {
    public class DeleteSystemLookupCommandShould : DatabaseTestBase {

        [Fact]
        public async Task DeleteSingleIntanceSuccessfuly () {
            // Arrange
            DeleteSystemLookupCommandHandler handler = new DeleteSystemLookupCommandHandler (_Database);
            DeleteSystemLookupCommand command = new DeleteSystemLookupCommand () { Id = 10 };
            // Act
            var result = await handler.Handle (command, CancellationToken.None);

            // Assert
            Assert.Equal (Unit.Value, result);
        }

        [Fact]
        public async Task ThrowNotFoundException () {
            // Arrange
            DeleteSystemLookupCommandHandler handler = new DeleteSystemLookupCommandHandler (_Database);
            DeleteSystemLookupCommand command = new DeleteSystemLookupCommand () { Id = 2 };
            // Assert
            var result = await
            Assert.ThrowsAsync<NotFoundException> (() => handler.Handle (command, CancellationToken.None));
        }
    }
}