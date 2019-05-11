/*
 * @CreateTime: May 10, 2019 4:06 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 10, 2019 4:13 PM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Accounts.Models;
using AccountingBackend.Application.Accounts.Queries.GetAccount;
using AccountingBackend.Application.Exceptions;
using Xunit;

namespace AccountingBackend.Application.Test.Accounts.Queries.GetAccount {
    public class GetAccountQueryHandlerShould : DatabaseTestBase {
        private GetAccountQueryHandler handler;

        public GetAccountQueryHandlerShould () : base () {
            handler = new GetAccountQueryHandler (_Database);
        }

        [Fact]
        public async Task ReturnSingleAccountBasedOnIdSuccessfuly () {
            // Arrange
            GetAccountQuery query = new GetAccountQuery () {
                Id = 10
            };
            // Act
            var result = await handler.Handle (query, CancellationToken.None);

            // Assert
            Assert.Equal (10, result.Id);
            Assert.IsType<AccountViewModel> (result);
        }

        [Fact]
        public void ThrowNotFoundException () {
            // Arrange
            GetAccountQuery query = new GetAccountQuery () {
                Id = 100
            };
            // Act

            // Assert
            Assert.ThrowsAsync<NotFoundException> (() => handler.Handle (query, CancellationToken.None));
        }
    }
}