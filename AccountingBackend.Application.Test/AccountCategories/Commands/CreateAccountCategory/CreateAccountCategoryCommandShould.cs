/*
 * @CreateTime: Apr 30, 2019 10:11 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 2, 2019 2:02 PM
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

namespace AccountingBackend.Application.Test.AccountCategories.Commands.CreateAccountCategory {
    public class CreateAccountCategoryCommandShould : DatabaseTestBase {

        [Fact]
        public async Task CreateAccount () {
            //Given
            CreateAccountCategoryCommandHandler handler = new CreateAccountCategoryCommandHandler (_Database);
            //When
            var result = await handler.Handle (new CreateAccountCategoryCommand () {
                AccountType = 1,
                    CategoryName = "Cash"
            }, CancellationToken.None);
            //Then

            Assert.NotEqual (0, result);
        }

    }
}