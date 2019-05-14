/*
 * @CreateTime: May 14, 2019 2:07 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 14, 2019 2:08 PM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.AccountTypes.Queries.GetAccountType;
using AccountingBackend.Application.Exceptions;
using Xunit;

namespace AccountingBackend.Application.Test.AccountTypes.Queries.GetAccountType {
    public class GetAccountTypeQueryHandlerShould : DatabaseTestBase {
        /// <summary>
        /// tests the return of single account type instance when provided a valid account type id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ReturnSingleInstanceOfAccountTypeSuccessfuly () {
            GetAccountTypeQuery query = new GetAccountTypeQuery () {
                Id = 6
            };
            GetAccountTypeQueryHandler handler = new GetAccountTypeQueryHandler (_Database);
            // Act
            var result = await handler.Handle (query, CancellationToken.None);
            // Assert
            Assert.Equal (6u, result.Id);
        }

        /// <summary>
        /// tests the return of not found exception when requested for account type id that does not 
        /// exist
        /// </summary>
        [Fact]
        public async Task ThrowNotFoundExceptionWhenIdDoesNotExists () {
            GetAccountTypeQuery query = new GetAccountTypeQuery () {
                Id = 100
            };
            GetAccountTypeQueryHandler handler = new GetAccountTypeQueryHandler (_Database);
            // Act
            await Assert.ThrowsAsync<NotFoundException> (() => handler.Handle (query, CancellationToken.None));
        }

        /// <summary>
        /// tests the return of not found exception when requested for system generated account type
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ThrowNotFoundExceptionWhenRequestedForSystemGeneratedType () {
            GetAccountTypeQuery query = new GetAccountTypeQuery () {
                Id = 1
            };
            GetAccountTypeQueryHandler handler = new GetAccountTypeQueryHandler (_Database);
            // Act
            await Assert.ThrowsAsync<NotFoundException> (() => handler.Handle (query, CancellationToken.None));
        }
    }
}