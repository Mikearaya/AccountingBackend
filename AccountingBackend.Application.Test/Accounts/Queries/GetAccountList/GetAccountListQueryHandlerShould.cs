using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Accounts.Models;
/*
 * @CreateTime: May 10, 2019 4:17 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 10, 2019 4:22 PM
 * @Description: Modify Here, Please 
 */
using AccountingBackend.Application.Accounts.Queries.GetAccountsList;
using AccountingBackend.Application.Models;
using Xunit;

namespace AccountingBackend.Application.Test.Accounts.Queries.GetAccountList {
    public class GetAccountListQueryHandlerShould : DatabaseTestBase {

        private GetAccountsListQueryHandler handler;
        public GetAccountListQueryHandlerShould () {
            handler = new GetAccountsListQueryHandler (_Database);
        }

        [Fact]
        public async Task ReturnListOfAccountsSuccessfuly () {
            // Arrange
            GetAccountsListQuery query = new GetAccountsListQuery ();
            // Act
            var result = await handler.Handle (query, CancellationToken.None);
            // Assert

            Assert.IsType<FilterResultModel<AccountViewModel>> (result);
            Assert.True ((result as FilterResultModel<AccountViewModel>).Items.Count () > 0);
        }
    }
}