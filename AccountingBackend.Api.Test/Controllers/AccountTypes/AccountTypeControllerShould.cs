using System.Net;
/*
 * @CreateTime: May 14, 2019 3:45 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 14, 2019 3:49 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AccountingBackend.Api.Test.Commons;
using AccountingBackend.Application.AccountTypes.Models;
using Xunit;

namespace AccountingBackend.Api.Test.Controllers.AccountTypes {
    public class AccountTypeControllerShould : IClassFixture<CustomWebApplicationFactory<Startup>> {
        private HttpClient _client;
        private string _ApiUrl = "api/account-types";

        public AccountTypeControllerShould (CustomWebApplicationFactory<Startup> factory) {
            _client = factory.CreateClient ();
        }

        [Fact]
        public async Task ReturnListOfAccountTypesSuccessfuly () {
            // Arrange
            var response = await _client.GetAsync (_ApiUrl);
            // Act
            response.EnsureSuccessStatusCode ();
            var accountType = await Utilities.GetResponseContent<IEnumerable<AccountTypeView>> (response);
            // Assert
            Assert.Equal (HttpStatusCode.OK, response.StatusCode);

            Assert.IsAssignableFrom<IEnumerable<AccountTypeView>> (accountType);

        }

        [Fact]
        public async Task ReturnListOfAccountTypeIndexesSuccessfuly () {
            // Arrange
            var response = await _client.GetAsync ($"{_ApiUrl}/index");
            // Act
            response.EnsureSuccessStatusCode ();
            var accountTypeIndex = await Utilities.GetResponseContent<IEnumerable<AccountTypeIndexView>> (response);
            // Assert
            Assert.Equal (HttpStatusCode.OK, response.StatusCode);

            Assert.IsAssignableFrom<IEnumerable<AccountTypeIndexView>> (accountTypeIndex);
        }

        [Fact]
        public async Task ReturnListOfSystemAccountTypeIndexesSuccessfuly () {
            // Arrange
            var response = await _client.GetAsync ($"{_ApiUrl}/index?main=0");
            // Act
            response.EnsureSuccessStatusCode ();
            var accountTypeIndex = await Utilities.GetResponseContent<IEnumerable<AccountTypeIndexView>> (response);
            // Assert
            Assert.Equal (HttpStatusCode.OK, response.StatusCode);
            Assert.False (accountTypeIndex.Any (a => a.TypeOf == null));
            Assert.IsAssignableFrom<IEnumerable<AccountTypeIndexView>> (accountTypeIndex);
        }

    }
}