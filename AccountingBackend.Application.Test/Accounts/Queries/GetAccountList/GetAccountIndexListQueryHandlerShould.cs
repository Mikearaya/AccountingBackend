using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Accounts.Models;
/*
 * @CreateTime: May 10, 2019 4:23 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 10, 2019 4:33 PM
 * @Description: Modify Here, Please 
 */
using AccountingBackend.Application.Accounts.Queries.GetAccountsList;
using Xunit;

namespace AccountingBackend.Application.Test.Accounts.Queries.GetAccountList {
    public class GetAccountIndexListQueryHandlerShould : DatabaseTestBase {

        private GetAccountIndexListQueryHandler handler;
        public GetAccountIndexListQueryHandlerShould () {
            handler = new GetAccountIndexListQueryHandler (_Database);
        }

        [Fact]
        public async Task ReturnListOfAccountsIndexSuccessfuly () {
            // Arrange
            GetAccountIndexListQuery query = new GetAccountIndexListQuery ();
            // Act
            var result = await handler.Handle (query, CancellationToken.None);

            // Assert
            Assert.IsType<List<AccountIndexView>> (result);
            Assert.True ((result as List<AccountIndexView>).Count () > 0);
        }
    }
}