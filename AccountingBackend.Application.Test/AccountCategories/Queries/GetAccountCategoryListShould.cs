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

namespace AccountingBackend.Application.Test.AccountCategories.Queries {
    public class GetAccountCategoryListShould {
        private readonly Mock<IAccountingDatabaseService> Mockdatabase;
        private readonly List<AccountCategoryView> catagoryViewList;
        private GetAccountCatugoryQueryListQueryHandler handler;
        public GetAccountCategoryListShould () {
            Mockdatabase = new Mock<IAccountingDatabaseService> ();

            catagoryViewList = new List<AccountCategoryView> () {
                new AccountCategoryView (),
                new AccountCategoryView (),
            };
            Mockdatabase.Setup (c => c.SaveAsync ());
        }

        //TODO: Test account categoryviewlistquery handler
        public async Task ReturnListOfAccountCategoryView () {
            // Arrange
            handler = new GetAccountCatugoryQueryListQueryHandler (Mockdatabase.Object);

            Mockdatabase.Setup (c => c.AccountCatagory.Select (AccountCategoryView.Projection)
                    .ToListAsync (CancellationToken.None))
                .ReturnsAsync (catagoryViewList);

            // Act
            var result = await handler.Handle (new GetAccountCategoryListQuery (), CancellationToken.None);

            // Assert
            Assert.Equal (2, result.Count ());
        }
    }
}