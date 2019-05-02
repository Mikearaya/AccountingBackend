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
using System.Threading.Tasks;
using AccountingBackend.Application.AccountCategories.Commands.UpdateAccountCategory;
using AccountingBackend.Application.AccountCategories.Models;
using AccountingBackend.Application.Exceptions;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Domain;
using Moq;
using Xunit;

namespace AccountingBackend.Application.Test.AccountCategories.Commands {
    public class UpdateAccountCategoryCommandHandlerShould {

        private readonly Mock<IAccountingDatabaseService> Mockdatabase;
        private readonly AccountCatagory accountCatagory;

        private readonly UpdateAccountCategoryCommand updateRequest;

        public UpdateAccountCategoryCommandHandlerShould () {
            accountCatagory = new AccountCatagory () {
                Id = 1,
                Type = "Asset",
                Catagory = "Cash",
                DateAdded = DateTime.Now,
                DateUpdated = DateTime.Now
            };

            updateRequest = new UpdateAccountCategoryCommand () {
                Id = 1,
                AccountType = AccountTypes.Asset,
                CategoryName = "Petty Cash"
            };

            Mockdatabase = new Mock<IAccountingDatabaseService> ();
            Mockdatabase.Setup (d => d.SaveAsync ()).Returns (Task.CompletedTask);

        }

        [Fact]
        public async void NotThrowNotFoundException () {
            //Given
            AccountCatagory updatedAccountCatagory = new AccountCatagory () {
                Id = 1,
                Type = "Asset",
                Catagory = "Petty Cash",
                DateAdded = DateTime.Now,
                DateUpdated = DateTime.Now
            };
            Mockdatabase.Setup (c => c.AccountCatagory.FindAsync (1)).ReturnsAsync (accountCatagory);
            Mockdatabase.Setup (c => c.AccountCatagory.Update (updatedAccountCatagory));

            UpdateAccountCategoryCommandHandler handler = new UpdateAccountCategoryCommandHandler (Mockdatabase.Object);
            //When
            var result = await handler.Handle (updateRequest, CancellationToken.None);

            //Then
            Assert.Equal (MediatR.Unit.Value, result);
        }

        /// <summary>
        /// Tests with none  existing id and checks if it throws error
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async void ThrowNotFoundException () {
            //Given
            Mockdatabase.Setup (c => c.AccountCatagory.FindAsync (2)).ReturnsAsync (accountCatagory);
            UpdateAccountCategoryCommandHandler handler = new UpdateAccountCategoryCommandHandler (Mockdatabase.Object);
            //When

            //Then
            await Assert.ThrowsAsync<NotFoundException> (() => handler.Handle (updateRequest, CancellationToken.None));

        }

    }
}