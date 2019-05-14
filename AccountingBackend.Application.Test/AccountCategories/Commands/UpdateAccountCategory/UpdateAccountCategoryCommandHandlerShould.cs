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
using MediatR;
using Moq;
using Xunit;

namespace AccountingBackend.Application.Test.AccountCategories.Commands {
    public class UpdateAccountCategoryCommandHandlerShould : DatabaseTestBase {

        [Fact]
        public async Task NotThrowNotFoundException () {
            //Given
            UpdateAccountCategoryCommand command = new UpdateAccountCategoryCommand () {
                Id = 10,
                AccountType = 1,
                CategoryName = "Petty Cash"
            };

            UpdateAccountCategoryCommandHandler handler = new UpdateAccountCategoryCommandHandler (_Database);
            //When
            var result = await handler.Handle (command, CancellationToken.None);

            //Then
            Assert.Equal (Unit.Value, result);
        }

        /// <summary>
        /// Tests with none  existing id and checks if it throws error
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ThrowNotFoundException () {
            //Given
            UpdateAccountCategoryCommand command = new UpdateAccountCategoryCommand () {
                Id = 1,
                AccountType = 1,
                CategoryName = "Petty Cash"
            };
            UpdateAccountCategoryCommandHandler handler = new UpdateAccountCategoryCommandHandler (_Database);
            //When

            //Then
            await Assert.ThrowsAsync<NotFoundException> (() => handler.Handle (command, CancellationToken.None));

        }

    }
}