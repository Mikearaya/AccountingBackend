/*
 * @CreateTime: Apr 30, 2019 1:39 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 30, 2019 1:48 PM
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
    public class DeleteAccountCategoryCommandShould {
        private readonly Mock<IAccountingDatabaseService> Mockdatabase;
        private readonly AccountCatagory accountCategory;
        public DeleteAccountCategoryCommandShould () {

            accountCategory = new AccountCatagory () {
                Id = 1,
                Type = "Asset",
                Catagory = "Cash"
            };

            Mockdatabase = new Mock<IAccountingDatabaseService> ();

            Mockdatabase.Setup (d => d.SaveAsync ()).Returns (Task.CompletedTask);
        }

        [Fact]
        public async void DeleteAccountSuccessfully () {
            //Given

            Mockdatabase.Setup (c => c.AccountCatagory.FindAsync (1)).ReturnsAsync ((accountCategory));
            Mockdatabase.Setup (c => c.AccountCatagory.Remove (accountCategory));
            DeleteAccountCategoryCommandHandler handler = new DeleteAccountCategoryCommandHandler (Mockdatabase.Object);

            //When
            var result = await handler.Handle (new DeleteAccountCategoryCommand () { Id = 1 }, CancellationToken.None);

            //Then
            Assert.Equal (MediatR.Unit.Value, result);
        }

        [Fact]
        public async void ThrowsNotFoundException () {
            // Arrange
            Mockdatabase.Setup (c => c.AccountCatagory.FindAsync (1)).ReturnsAsync ((accountCategory));
            Mockdatabase.Setup (c => c.AccountCatagory.Remove (accountCategory));
            DeleteAccountCategoryCommandHandler handler = new DeleteAccountCategoryCommandHandler (Mockdatabase.Object);
            // Act
            await Assert.ThrowsAsync<NotFoundException> (() => handler.Handle (new DeleteAccountCategoryCommand () { Id = 2 }, CancellationToken.None));
            // Assert
        }

    }
}