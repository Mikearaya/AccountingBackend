/*
 * @CreateTime: Apr 30, 2019 1:39 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 2, 2019 1:56 PM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.AccountCategories.Commands.DeleteAccountCategory;
using AccountingBackend.Application.Exceptions;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Domain;
using Moq;
using Xunit;

namespace AccountingBackend.Application.Test.AccountCategories.Commands {
    public class DeleteAccountCategoryCommandShould : DatabaseTestBase {

        [Fact]
        public async Task DeleteAccountSuccessfully () {
            //Given
            DeleteAccountCategoryCommandHandler handler = new DeleteAccountCategoryCommandHandler (_Database);

            //When
            var result = await handler.Handle (new DeleteAccountCategoryCommand () { Id = 10 }, CancellationToken.None);

            //Then
            Assert.Equal (MediatR.Unit.Value, result);
        }

        [Fact]
        public async Task ThrowsNotFoundException () {
            // Arrange

            DeleteAccountCategoryCommandHandler handler = new DeleteAccountCategoryCommandHandler (_Database);
            // Act
            await Assert.ThrowsAsync<NotFoundException> (() => handler.Handle (new DeleteAccountCategoryCommand () { Id = 2 }, CancellationToken.None));
            // Assert
        }

    }
}