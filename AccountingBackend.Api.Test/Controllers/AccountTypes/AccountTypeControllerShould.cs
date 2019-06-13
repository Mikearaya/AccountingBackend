using System.Net;
/*
 * @CreateTime: May 14, 2019 3:45 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 14, 2019 3:49 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AccountingBackend.Api.Test.Commons;
using AccountingBackend.Application.AccountTypes.Models;
using AccountingBackend.Application.Models;
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
            var response = await _client.PostAsync ($"{_ApiUrl}/filter", Utilities.GetStringContent (new { }));
            // Act
            response.EnsureSuccessStatusCode ();
            var accountType = await Utilities.GetResponseContent<FilterResultModel<AccountTypeView>> (response);
            // Assert
            Assert.Equal (HttpStatusCode.OK, response.StatusCode);

            Assert.IsAssignableFrom<FilterResultModel<AccountTypeView>> (accountType);

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
            Assert.False (accountTypeIndex.FirstOrDefault (a => a.TypeOf == null) != null);
            Assert.IsAssignableFrom<IEnumerable<AccountTypeIndexView>> (accountTypeIndex);
        }

        [Fact]
        public async Task CreateAccountTypeSuccessfuly () {
            // Arrange
            var request = new {
                Body = new {
                IsTypeOf = 1,
                Type = "Account Recievable",
                SummerizeReport = 1
                }
            };

            // Act
            var response = await _client.PostAsync ($"{_ApiUrl}", Utilities.GetStringContent (request.Body));
            var accountType = await Utilities.GetResponseContent<AccountTypeView> (response);
            // Assert
            Assert.Equal (HttpStatusCode.Created, response.StatusCode);

            Assert.IsType<AccountTypeView> (accountType);
        }

        [Fact]
        public async Task UpdateAccountTypeSuccessfuly () {
            // Arrange
            var request = new {
                Body = new {
                Id = 6,
                IsTypeOf = 1,
                Type = "Account Recievable",
                SummerizeReport = 1
                }
            };

            // Act
            var response = await _client.PutAsync ($"{_ApiUrl}/6", Utilities.GetStringContent (request.Body));
            response.EnsureSuccessStatusCode ();
            // Assert
            Assert.Equal (HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public async Task ReturnNotFoundStatusCode () {
            // Arrange
            var request = new {
                Body = new {
                Id = 100,
                IsTypeOf = 1,
                Type = "Account Recievable",
                SummerizeReport = 1
                }
            };

            // Act
            var response = await _client.PutAsync ($"{_ApiUrl}/100", Utilities.GetStringContent (request.Body));
            // Assert
            Assert.Equal (HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task DeleteAccountTypeSuccessfuly () {
            // Act
            var response = await _client.DeleteAsync ($"{_ApiUrl}/7");
            response.EnsureSuccessStatusCode ();
            // Assert
            Assert.Equal (HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public async Task Return404StatusCodeWhenAttemptingDeleteNonExisting () {
            // Act
            var response = await _client.DeleteAsync ($"{_ApiUrl}/100");

            // Assert
            Assert.Equal (HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Return422StatusCodeWhenDeletingSystemAccountTypes () {
            // Act
            var response = await _client.DeleteAsync ($"{_ApiUrl}/10");

            // Assert
            Assert.Equal (HttpStatusCode.UnprocessableEntity, response.StatusCode);
        }
    }
}