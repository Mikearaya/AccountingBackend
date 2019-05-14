/*
 * @CreateTime: May 14, 2019 2:08 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 14, 2019 2:09 PM
 * @Description: Modify Here, Please 
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.AccountTypes.Queries.GetAccountTypeList;
using Xunit;

namespace AccountingBackend.Application.Test.AccountTypes.Queries.GetAccountTypeList {
    public class GetAccountTypeIndexQueryHandlerShould : DatabaseTestBase {
        /// <summary>
        /// tests the return of account type index view only generated by when 
        /// requested
        /// </summary>
        /// <returns></returns>

        [Fact]
        public async Task ReturnUserGeneratedAccountTypeIndexSuccessfuly () {
            GetAccountTypeIndexQuery query = new GetAccountTypeIndexQuery () {
                Main = false
            };
            GetAccountTypeIndexQueryHandler handler = new GetAccountTypeIndexQueryHandler (_Database);
            // Act
            var result = await handler.Handle (query, CancellationToken.None);

            // Assert
            Assert.False (result.Any (a => a.TypeOf == 0));
        }

        /// <summary>
        /// tests return of system generate account types only when requested
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ReturnSystemAccountTypeIndexSuccessfuly () {
            GetAccountTypeIndexQuery query = new GetAccountTypeIndexQuery () {
                Main = true
            };
            GetAccountTypeIndexQueryHandler handler = new GetAccountTypeIndexQueryHandler (_Database);
            // Act
            var result = await handler.Handle (query, CancellationToken.None);

            // Assert
            Assert.False (result.Any (a => a.TypeOf != 0));

        }

    }
}