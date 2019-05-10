/*
 * @CreateTime: May 2, 2019 12:14 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 2, 2019 12:53 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.AccountCategories.Models;
using AccountingBackend.Application.AccountCategories.Queries.GetAccountCategoryList;
using AccountingBackend.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace AccountingBackend.Application.Test.AccountCategories.Queries.GetAccountCategoryList {
    public class GetAccountCategoryListShould : DatabaseTestBase {

        private GetAccountCatugoryQueryListQueryHandler handler;
        public GetAccountCategoryListShould () {
            handler = new GetAccountCatugoryQueryListQueryHandler (_Database);
        }
        public async Task ReturnListOfAccountCategoryView () {
            // Arrange
            GetAccountCategoryListQuery query = new GetAccountCategoryListQuery ();

            // Act
            var result = await handler.Handle (query, CancellationToken.None);

            // Assert
            Assert.True (result.Count () > 0);
        }
    }
}