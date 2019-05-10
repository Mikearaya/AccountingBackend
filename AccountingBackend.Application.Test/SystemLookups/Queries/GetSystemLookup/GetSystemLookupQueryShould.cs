using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Exceptions;
using AccountingBackend.Application.SystemLookups.Models;
/*
 * @CreateTime: May 10, 2019 2:33 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 10, 2019 2:33 PM
 * @Description: Modify Here, Please 
 */
using AccountingBackend.Application.SystemLookups.Queries.GetSystemLookup;
using Xunit;

namespace AccountingBackend.Application.Test.SystemLookups.Queries.GetSystemLookup {
    public class GetSystemLookupQueryShould : DatabaseTestBase {

        private GetSystemLookupQueryHandler handler;
        public GetSystemLookupQueryShould () {
            handler = new GetSystemLookupQueryHandler (_Database);
        }

        [Fact]
        public async Task ReturnSystemLookupViewModelBasedOnIdSuccessfuly () {
            // Arrange
            GetSystemLookupQuery query = new GetSystemLookupQuery () {
                Id = 10
            };
            // Act
            var result = await handler.Handle (query, CancellationToken.None);
            // Assert
            Assert.IsType<SystemLookupViewModel> (result);

        }

        [Fact]
        public async Task ThrowNotFoundException () {
            // Arrange
            GetSystemLookupQuery query = new GetSystemLookupQuery () {
                Id = 2
            };
            // Assert
            await Assert.ThrowsAsync<NotFoundException> (() => handler.Handle (query, CancellationToken.None));
        }
    }
}