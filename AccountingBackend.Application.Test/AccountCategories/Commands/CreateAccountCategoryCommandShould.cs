/*
 * @CreateTime: Apr 30, 2019 10:11 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 30, 2019 1:20 PM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using AccountingBackend.Application.AccountCategories.Commands.CreateAccountCategory;
using AccountingBackend.Application.AccountCategories.Models;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Domain;
using MediatR;
using Moq;
using Xunit;

namespace AccountingBackend.Application.Test.AccountCategories.Commands {
    public class CreateAccountCategoryCommandShould {

        private readonly Mock<IAccountingDatabaseService> Mockdatabase;

        public CreateAccountCategoryCommandShould () {

            Mockdatabase = new Mock<IAccountingDatabaseService> ();
            Mockdatabase.Setup (c => c.AccountCatagory.Add (new AccountCatagory () {
                Type = "Asset",
                    Catagory = "Cash"
            }));

        }

        [Fact]
        public async void CreateAccount () {
            //Given
            CreateAccountCategoryCommandHandler handler = new CreateAccountCategoryCommandHandler (Mockdatabase.Object);
            //When
            var result = await handler.Handle (new CreateAccountCategoryCommand () {
                AccountType = AccountTypes.Asset,
                    CategoryName = "Cash"
            }, CancellationToken.None);
            //Then

            Assert.Equal (0, result);
        }

    }
}