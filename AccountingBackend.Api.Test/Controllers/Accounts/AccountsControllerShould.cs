/*
 * @CreateTime: May 3, 2019 1:54 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 3, 2019 2:51 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AccountingBackend.Api.Test.Commons;
using AccountingBackend.Application.Accounts.Models;
using AccountingBackend.Application.Exceptions;
using Xunit;

namespace AccountingBackend.Api.Test.Controllers.Accounts {
    public class AccountsControllerShould : IClassFixture<CustomWebApplicationFactory<Startup>> {
        private readonly CustomWebApplicationFactory<Startup> _factory;
        private HttpClient _client;
        private string _ApiUrl = "api/accounts";
        public AccountsControllerShould (CustomWebApplicationFactory<Startup> factory) {
            _client = factory.CreateClient ();
        }

        /// <summary>
        /// tests successful return of categories list
        /// </summary>
        [Fact]
        public async Task ReturnListOfAccountsSuccessfuly () {

            // Actions
            var response = await _client.GetAsync (_ApiUrl);

            response.EnsureSuccessStatusCode ();
            var categories = await Utilities.GetResponseContent<IEnumerable<AccountViewModel>> (response);

            // Assert
            Assert.Equal (2, categories.Count ());
            Assert.IsAssignableFrom<List<AccountViewModel>> (categories);
        }

        /// <summary>
        /// tests if api return single account category
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ShouldReturnSingleAccountSuccessfuly () {
            // Arrange

            var response = await _client.GetAsync ($"{_ApiUrl}/10");
            response.EnsureSuccessStatusCode ();
            // Act
            var categories = await Utilities.GetResponseContent<AccountViewModel> (response);
            Assert.Equal (10, categories.Id);
            // Assert
        }

        /// <summary>
        /// tests if api return single account category
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ShouldReturnNotFoundWhenForAccountIdNotExists () {

            var response = await _client.GetAsync ($"{_ApiUrl}/1000");

            Assert.Equal (HttpStatusCode.NotFound, response.StatusCode);

        }
    }
}