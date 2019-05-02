/*
 * @CreateTime: May 1, 2019 8:32 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 1, 2019 9:39 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.AccountCategories.Models;
using AccountingBackend.Application.AccountCategories.Queries.GetAccountCategory;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Domain;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

//TODO: Test account category get queries

namespace AccountingBackend.Application.Test.AccountCategories.Queries {
    public class GetAccountCategoryQueryShould {

        private readonly Mock<IAccountingDatabaseService> MockDatabase;
        private readonly AccountCategoryView accountCatagory;
        private GetAccountCategoryQueryHandler getQueryHandler;
        public GetAccountCategoryQueryShould () {
            MockDatabase = new Mock<IAccountingDatabaseService> ();
            accountCatagory = new AccountCategoryView () {
                Id = 1,
                AccountType = "Asset",
                CategoryName = "Cash",
                DateAdded = DateTime.Now,
                DateUpdated = DateTime.Now
            };
        }

        public async void ReturnAccountCategory () {
            // Arrange
            MockDatabase.Setup (d => d.AccountCatagory.Select (AccountCategoryView.Projection).FirstOrDefaultAsync (a => a.Id == 1, CancellationToken.None)).Returns (Task.FromResult (accountCatagory));

            getQueryHandler = new GetAccountCategoryQueryHandler (MockDatabase.Object);

            // Act
            var result = await getQueryHandler.Handle (new GetAccountCategoryQuery () { Id = 1 }, CancellationToken.None);

            // Assert

            Assert.Equal (accountCatagory, result);
        }
    }
}