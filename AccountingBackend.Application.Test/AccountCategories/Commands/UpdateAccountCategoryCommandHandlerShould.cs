/*
 * @CreateTime: Apr 30, 2019 11:08 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 30, 2019 1:22 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Threading;
using AccountingBackend.Application.AccountCategories.Commands.UpdateAccountCategory;
using AccountingBackend.Application.AccountCategories.Models;
using AccountingBackend.Application.Exceptions;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Domain;
using Moq;
using Xunit;

namespace AccountingBackend.Application.Test.AccountCategories.Commands {
    public class UpdateAccountCategoryCommandHandlerShould {

        Mock<IAccountingDatabaseService> Mockdatabase;
        public UpdateAccountCategoryCommandHandlerShould () {
            Mockdatabase = new Mock<IAccountingDatabaseService> ();

        }

        [Fact]
        public async void NotThrowNotFoundException () {
            //Given
            Mockdatabase.Setup (c => c.AccountCatagory.FindAsync (1)).ReturnsAsync (new AccountCatagory () {
                Id = 1,
                    Type = "Asset",
                    Name = "Cash",
                    DateAdded = DateTime.Now,
                    DateUpdated = DateTime.Now
            });
            UpdateAccountCategoryCommandHandler handler = new UpdateAccountCategoryCommandHandler (Mockdatabase.Object);
            //When
            var result = await handler.Handle (new UpdateAccountCategoryCommand () {
                Id = 1,
                    AccountType = AccountTypes.Asset,
                    CategoryName = "Cash"
            }, CancellationToken.None);

            //Then
            Assert.NotNull (result);
        }

        /// <summary>
        /// Tests with none  existing id and checks if it throws error
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async void ThrowNotFoundException () {
            //Given
            Mockdatabase.Setup (c => c.AccountCatagory.FindAsync (1)).ReturnsAsync (new AccountCatagory () {
                Id = 1,
                    Type = "Asset",
                    Name = "Cash",
                    DateAdded = DateTime.Now,
                    DateUpdated = DateTime.Now
            });
            UpdateAccountCategoryCommandHandler handler = new UpdateAccountCategoryCommandHandler (Mockdatabase.Object);
            //When

            //Then
            await Assert.ThrowsAsync<NotFoundException> (() => handler.Handle (new UpdateAccountCategoryCommand () {
                Id = 2,
                    AccountType = AccountTypes.Asset,
                    CategoryName = "Cash"
            }, CancellationToken.None));

        }

    }
}