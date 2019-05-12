using System.Collections.Generic;
using System.Linq;
using System.Threading;
/*
 * @CreateTime: May 10, 2019 3:39 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 12, 2019 3:04 PM
 * @Description: Modify Here, Please 
 */
using System.Threading.Tasks;
using AccountingBackend.Application.SystemLookups.Models;
using AccountingBackend.Application.SystemLookups.Queries.GetSystemLookupList;
using Xunit;

namespace AccountingBackend.Application.Test.SystemLookups.Queries.GetSystemLookupList {
    public class GetSystemLookupByTypeQueryShould : DatabaseTestBase {
        private GetSystemLookupByTypeQueryHandler handler;

        [Fact]
        public async Task ReturnSystemLookupsSuccessfuly () {
            // Arrange
            handler = new GetSystemLookupByTypeQueryHandler (_Database);
            GetSystemLookupByTypeQuery query = new GetSystemLookupByTypeQuery () {
                Type = "Cost Center"
            };

            // Act
            var result = await handler.Handle (query, CancellationToken.None);
            // Assert

            Assert.True ((result as List<SystemLookUpIndexModel>).Count () > 0);

        }

    }
}