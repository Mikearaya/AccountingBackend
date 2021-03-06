/*
 * @CreateTime: May 1, 2019 8:32 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 2, 2019 12:54 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.AccountCategories.Models;
using AccountingBackend.Application.AccountCategories.Queries.GetAccountCategory;
using AccountingBackend.Application.Exceptions;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Domain;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace AccountingBackend.Application.Test.AccountCategories.Queries.GetAccountCategory {
    public class GetAccountCategoryQueryShould : DatabaseTestBase {

        [Fact]
        public async Task ReturnAccountCategory () {
            // Arrange
            GetAccountCategoryQueryHandler handler = new GetAccountCategoryQueryHandler (_Database);

            GetAccountCategoryQuery query = new GetAccountCategoryQuery () {
                Id = 10
            };

            // Act
            var result = await handler.Handle (query, CancellationToken.None);

            // Assert
            Assert.Equal (10, result.Id);
        }

        [Fact]
        public void ThrowNotFoundException () {
            // Arrange
            GetAccountCategoryQueryHandler handler = new GetAccountCategoryQueryHandler (_Database);
            GetAccountCategoryQuery query = new GetAccountCategoryQuery () {
                Id = 100
            };

            // Assert
            Assert.ThrowsAsync<NotFoundException> (() => handler.Handle (query, CancellationToken.None));
        }
    }
}