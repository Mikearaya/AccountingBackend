/*
 * @CreateTime: May 1, 2019 1:34 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 1, 2019 1:56 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AccountingBackend.Api.Test.Commons;
using AccountingBackend.Application.AccountCategories.Models;
using Newtonsoft.Json;
using Xunit;

namespace AccountingBackend.Api.Test.Controllers {
    public class AccountCategoryControllerShould : IClassFixture<CustomWebApplicationFactory<Startup>> {

        private readonly HttpClient _client;
        private readonly string _Api_Url = "api/account-categories";
        public AccountCategoryControllerShould (CustomWebApplicationFactory<Startup> factory) {

            _client = factory.CreateClient ();
        }

        /// <summary>
        /// tests successful return of categories list
        /// </summary>
        [Fact]
        public async Task ReturnSuccessStatusCode () {
            // Arrange
            var response = await _client.GetAsync (_Api_Url);

            response.EnsureSuccessStatusCode ();
            var categories = await Utilities.GetResponseContent<IEnumerable<AccountCategoryView>> (response);

            Assert.IsAssignableFrom<List<AccountCategoryView>> (categories);
            Assert.Equal (2, categories.Count ());

            // Assert
        }

        /// <summary>
        /// tests if api return single account category
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ShouldReturnSingleAccountCategory () {
            // Arrange

            var response = await _client.GetAsync ($"{_Api_Url}/1");
            response.EnsureSuccessStatusCode ();
            // Act
            var categories = await Utilities.GetResponseContent<AccountCategoryView> (response);
            Assert.Equal (1, categories.Id);
            // Assert
        }

        //TODO: Do testing for post put and delete
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>

        public async Task CreateAccountCategorySuccessfuly () {
            var request = new {
                Body = new {
                CategoryName = "Cash",
                AccountType = "Asset"
                }
            };

            var response = await _client.PostAsync (_Api_Url, ContentHelper.GetStringContent (request.Body));

            response.EnsureSuccessStatusCode ();
            Console.WriteLine (response.Content.ReadAsStringAsync ());

            var categories = await Utilities.GetResponseContent<AccountCategoryView> (response);

            // Assert
            Assert.Equal ("Cash", categories.CategoryName);

        }

        [Fact]
        public async Task UpdateAccountCategorySuccessfuly () {
            // Arrange
            var request = new {
                Body = new {
                Id = 1,
                CategoryName = "Account Payable",
                AccountType = "Asset",
                }
            };

            // Act
            var response = await _client.PutAsync ($"{_Api_Url}/1", ContentHelper.GetStringContent (request.Body));

            // Assert
            response.EnsureSuccessStatusCode ();
        }

    }

    public static class ContentHelper {
        public static StringContent GetStringContent (object obj) => new StringContent (JsonConvert.SerializeObject (obj), Encoding.Default, "application/json");
    }
}