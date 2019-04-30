/*
 * @CreateTime: Apr 30, 2019 1:39 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 30, 2019 1:48 PM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using AccountingBackend.Application.AccountCategories.Commands.DeleteAccountCategory;
using AccountingBackend.Application.Exceptions;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Domain;
using Moq;
using Xunit;

namespace AccountingBackend.Application.Test.AccountCategories.Commands {
    public class DeleteAccountCategoryCommandShould {
        private readonly Mock<IAccountingDatabaseService> Mockdatabase;

        public DeleteAccountCategoryCommandShould () {
            Mockdatabase = new Mock<IAccountingDatabaseService> ();
            Mockdatabase.Setup (c => c.AccountCatagory.Remove (new AccountCatagory () {
                Id = 1,
                    Type = "Asset",
                    Name = "Cash"
            }));
        }

        [Fact]
        public async void DeleteAccountSuccessfully () {
            //Given

            Mockdatabase.Setup (c => c.AccountCatagory.FindAsync (1)).ReturnsAsync ((new AccountCatagory () {
                Id = 1,
                    Type = "Asset",
                    Name = "Cash"
            }));

            DeleteAccountCategoryCommandHandler handler = new DeleteAccountCategoryCommandHandler (Mockdatabase.Object);

            //When
            var result = await handler.Handle (new DeleteAccountCategoryCommand () { Id = 1 }, CancellationToken.None);

            //Then
            Assert.NotNull (result);
        }

        [Fact]
        public async void ThrowsNotFoundException () {
            // Arrange

            Mockdatabase.Setup (c => c.AccountCatagory.FindAsync (1)).ReturnsAsync ((new AccountCatagory () {
                Id = 1,
                    Type = "Asset",
                    Name = "Cash"
            }));

            DeleteAccountCategoryCommandHandler handler = new DeleteAccountCategoryCommandHandler (Mockdatabase.Object);
            // Act
            await Assert.ThrowsAsync<NotFoundException> (() => handler.Handle (new DeleteAccountCategoryCommand () { Id = 2 }, CancellationToken.None));
            // Assert
        }

    }
}