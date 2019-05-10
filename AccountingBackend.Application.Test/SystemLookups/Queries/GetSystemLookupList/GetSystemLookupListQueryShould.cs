using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.SystemLookups.Models;
/*
 * @CreateTime: May 10, 2019 3:27 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 10, 2019 3:36 PM
 * @Description: Modify Here, Please 
 */
using AccountingBackend.Application.SystemLookups.Queries.GetSystemLookupList;
using Xunit;

namespace AccountingBackend.Application.Test.SystemLookups.Queries.GetSystemLookupList {
    public class GetSystemLookupListQueryShould : DatabaseTestBase {
        private GetSystemLookupListQueryHandler handler;
        public GetSystemLookupListQueryShould () {
            handler = new GetSystemLookupListQueryHandler (_Database);
        }

        [Fact]
        public async Task ReturnListOfSystemLookupViewModel () {
            // Arrange
            GetSystemLookupListQuery query = new GetSystemLookupListQuery ();
            // Act
            var result = await handler.Handle (query, CancellationToken.None);

            // Assert
            Assert.IsType<List<SystemLookupViewModel>> (result);
            Assert.True ((result as List<SystemLookupViewModel>).Count () > 0);
        }
    }
}