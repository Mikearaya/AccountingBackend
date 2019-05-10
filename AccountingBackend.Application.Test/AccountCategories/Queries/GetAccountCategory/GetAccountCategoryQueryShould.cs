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

        private GetAccountCategoryQueryHandler handler;
        public GetAccountCategoryQueryShould () {
            handler = new GetAccountCategoryQueryHandler (_Database);
        }

        [Fact]
        public async Task ReturnAccountCategory () {
            // Arrange
            GetAccountCategoryQuery query = new GetAccountCategoryQuery () {
                Id = 3
            };

            // Act
            var result = await handler.Handle (query, CancellationToken.None);

            // Assert
            Assert.Equal (3, result.Id);
        }

        [Fact]
        public void ThrowNotFoundException () {
            // Arrange
            GetAccountCategoryQuery query = new GetAccountCategoryQuery () {
                Id = 100
            };

            // Assert
            Assert.ThrowsAsync<NotFoundException> (() => handler.Handle (query, CancellationToken.None));
        }
    }
}