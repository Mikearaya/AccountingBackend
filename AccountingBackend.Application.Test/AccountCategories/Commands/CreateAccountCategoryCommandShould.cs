/*
 * @CreateTime: Apr 30, 2019 10:11 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 1, 2019 1:47 PM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
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
        public async Task CreateAccount () {
            //Given
            Mockdatabase.Setup (d => d.SaveAsync ()).Returns (Task.CompletedTask);
            CreateAccountCategoryCommandHandler handler = new CreateAccountCategoryCommandHandler (Mockdatabase.Object);
            //When
            var result = await handler.Handle (new CreateAccountCategoryCommand () {
                AccountType = "Asset",
                    CategoryName = "Cash"
            }, CancellationToken.None);
            //Then

            Assert.Equal (0, result);
        }

    }
}