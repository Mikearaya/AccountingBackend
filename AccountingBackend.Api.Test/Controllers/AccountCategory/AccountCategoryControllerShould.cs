/*
 * @CreateTime: May 1, 2019 1:34 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 4, 2019 10:23 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AccountingBackend.Api.Test.Commons;
using AccountingBackend.Application.AccountCategories.Models;
using AccountingBackend.Application.Exceptions;
using AccountingBackend.Application.Models;
using Newtonsoft.Json;
using Xunit;

namespace AccountingBackend.Api.Test.Controllers {
    public class AccountCategoryControllerShould : IClassFixture<CustomWebApplicationFactory<Startup>> {

        private readonly HttpClient _client;
        private readonly string _ApiUrl = "api/account-categories";
        public AccountCategoryControllerShould (CustomWebApplicationFactory<Startup> factory) {

            _client = factory.CreateClient ();
        }

        /// <summary>
        /// tests successful return of categories list
        /// </summary>
        [Fact]
        public async Task ReturnListOfAccountCategoriesSuccessSuccessfuly () {
            // Arrange
            var response = await _client.PostAsync ($"{_ApiUrl}/filter", Utilities.GetStringContent (new { }));

            response.EnsureSuccessStatusCode ();
            var categories = await Utilities.GetResponseContent<FilterResultModel<AccountCategoryView>> (response);

            Assert.IsAssignableFrom<FilterResultModel<AccountCategoryView>> (categories);
            Assert.True (((FilterResultModel<AccountCategoryView>) categories).Items.Count () > 0);

            // Assert
        }

        /// <summary>
        /// tests if api return single account category
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ShouldReturnSingleAccountCategory () {
            // Arrange

            var response = await _client.GetAsync ($"{_ApiUrl}/2");
            response.EnsureSuccessStatusCode ();
            // Act
            var categories = await Utilities.GetResponseContent<AccountCategoryView> (response);
            Assert.Equal (2, categories.Id);
            // Assert
        }

        /// <summary>
        /// tests if api return not found response  single account category request 
        /// with non existing Id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ReturnNotFoundForNonExistingAccountCategoryId () {
            // Arrange

            var response = await _client.GetAsync ($"{_ApiUrl}/1000");
            // Act
            Assert.Equal (HttpStatusCode.NotFound, response.StatusCode);
            // Assert
        }

        /// <summary>
        /// creates account category successfuly
        /// </summary>
        /// <returns></returns>

        [Fact]
        public async Task CreateAccountCategorySuccessfuly () {
            var request = new {
                Body = new {
                CategoryName = "Account Recievable",
                AccountType = 10
                }
            };

            var response = await _client.PostAsync (_ApiUrl, Utilities.GetStringContent (request.Body));
            response.EnsureSuccessStatusCode ();

            // Assert
            Assert.Equal (HttpStatusCode.Created, response.StatusCode);

        }

        /// <summary>
        /// Tests update/put request for successful response
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task UpdateAccountCategorySuccessfuly () {
            // Arrange
            var request = new {
                Body = new {
                Id = 1,
                CategoryName = "Account Payable",
                AccountType = 1,
                }
            };

            // Act
            var response = await _client.PutAsync ($"{_ApiUrl}/2", Utilities.GetStringContent (request.Body));
            response.EnsureSuccessStatusCode ();

            // Assert
            Assert.Equal (HttpStatusCode.NoContent, response.StatusCode);
        }

        /// <summary>
        /// test update/put request for 404 not found response by giving a wrong url
        /// </summary>
        [Fact]
        public async Task ReturnNotFoundResponseForNonExistingId () {
            // Arrange
            // Arrange
            var request = new {
                Body = new {
                Id = 1000,
                CategoryName = "Account Payable",
                AccountType = "Asset",
                }
            };
            var response = await _client.GetAsync ($"{_ApiUrl}/1000");

            // Act
            Assert.Equal (HttpStatusCode.NotFound, response.StatusCode);
            // Assert
        }

        /// <summary>
        /// testing delete request for a successful completion
        /// </summary>
        /// <returns></returns>

        [Fact]
        public async Task DeleteAccountCategorySuccessfuly () {
            // Arrange
            var response = await _client.DeleteAsync ($"{_ApiUrl}/3");
            response.EnsureSuccessStatusCode ();
            // Act

            // Assert
            Assert.Equal (HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public async Task ReturnNotFoundForNonExistingAccountCategoryDeleteRequest () {
            // Arrange
            var response = await _client.DeleteAsync ($"{_ApiUrl}/1000");
            // Act

            // Assert
            Assert.Equal (HttpStatusCode.NotFound, response.StatusCode);
        }

        /// <summary>
        /// tests successful return of categories cantegory index api request
        /// </summary>
        [Fact]
        public async Task ReturnIndexForListOfAccountCategoriesSuccessfuly () {
            // Arrange
            var response = await _client.GetAsync ($"{_ApiUrl}/index");

            response.EnsureSuccessStatusCode ();
            var categories = await Utilities.GetResponseContent<IEnumerable<AccountCategoryIndexView>> (response);

            Assert.IsAssignableFrom<List<AccountCategoryIndexView>> (categories);
            Assert.True (categories.Count () > 0);

            // Assert
        }

    }

}