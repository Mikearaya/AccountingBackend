/*
 * @CreateTime: May 3, 2019 1:54 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 7, 2019 2:28 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AccountingBackend.Api.Test.Commons;
using AccountingBackend.Application.Accounts.Models;
using AccountingBackend.Application.Exceptions;
using AccountingBackend.Application.Models;
using Xunit;

namespace AccountingBackend.Api.Test.Controllers.Accounts {
    public class AccountsControllerShould : IClassFixture<CustomWebApplicationFactory<Startup>> {

        private HttpClient _client;
        private string _ApiUrl = "api/accounts";
        public AccountsControllerShould (CustomWebApplicationFactory<Startup> factory) {
            _client = factory.CreateClient ();
        }

        /// <summary>
        /// tests successful return of  list
        /// </summary>
        [Fact]
        public async Task ReturnListOfAccountsSuccessfuly () {

            // Actions
            var response = await _client.PostAsync ($"{_ApiUrl}/filter", Utilities.GetStringContent (new { }));

            response.EnsureSuccessStatusCode ();
            var account = await Utilities.GetResponseContent<FilterResultModel<AccountViewModel>> (response);

            // Assert

            Assert.IsAssignableFrom<FilterResultModel<AccountViewModel>> (account);
        }

        /// <summary>
        /// tests if api return single account category
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ReturnSingleAccountSuccessfuly () {
            // Arrange

            var response = await _client.GetAsync ($"{_ApiUrl}/10");
            response.EnsureSuccessStatusCode ();
            // Act
            var account = await Utilities.GetResponseContent<AccountViewModel> (response);
            Assert.Equal (10, account.Id);
            // Assert
        }

        /// <summary>
        /// tests if api return single account 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ReturnNotFoundWhenForAccountIdNotExists () {

            var response = await _client.GetAsync ($"{_ApiUrl}/1000");

            Assert.Equal (HttpStatusCode.NotFound, response.StatusCode);

        }

        /// <summary>
        /// tests creates  account request completes  successfuly
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateAccountSuccessfuly () {
            var request = new {
                Body = new {
                accountId = "5330",
                parentAccount = 0,
                catagoryId = 3,
                AccountName = "string",
                active = 1,
                organizationId = 2,
                openingBalance = 4000,
                CostCenterId = 30
                }
            };

            var response = await _client.PostAsync (_ApiUrl, Utilities.GetStringContent (request.Body));
            response.EnsureSuccessStatusCode ();

            var account = await Utilities.GetResponseContent<AccountViewModel> (response);

            // Assert
            Assert.Equal (HttpStatusCode.Created, response.StatusCode);
            Assert.Equal ("5330", account.AccountId);
            Assert.Equal ("string", account.AccountName);
            Assert.True (account.Active);
            Assert.Equal (4000, account.OpeningBalance);
            Assert.Equal (3, account.CategoryId);

        }

        /// <summary>
        /// test if account is successfuly created without cost center
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateAccountWithoutCostCenterSuccessfuly () {
            var request = new {
                Body = new {
                accountId = "5330",
                parentAccount = 0,
                catagoryId = 3,
                AccountName = "string",
                active = 1,
                organizationId = 2,
                openingBalance = 4000,
                }
            };

            var response = await _client.PostAsync (_ApiUrl, Utilities.GetStringContent (request.Body));
            response.EnsureSuccessStatusCode ();

            var account = await Utilities.GetResponseContent<AccountViewModel> (response);

            // Assert
            Assert.Equal (HttpStatusCode.Created, response.StatusCode);
            Assert.Equal ("5330", account.AccountId);
            Assert.Equal ("string", account.AccountName);
            Assert.True (account.Active);
            Assert.Equal (4000, account.OpeningBalance);
            Assert.Equal (3, account.CategoryId);

        }

        /// <summary>
        /// test if account is successfuly created without parent account successfuly
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateAccountWithoutParentAccountSuccessfuly () {
            var request = new {
                Body = new {
                accountId = "5330",
                catagoryId = 3,
                AccountName = "string",
                active = 1,
                organizationId = 2,
                openingBalance = 4000,
                }
            };

            var response = await _client.PostAsync (_ApiUrl, Utilities.GetStringContent (request.Body));
            response.EnsureSuccessStatusCode ();

            var account = await Utilities.GetResponseContent<AccountViewModel> (response);

            // Assert
            Assert.Equal (HttpStatusCode.Created, response.StatusCode);
            Assert.Equal ("5330", account.AccountId);
            Assert.Equal ("string", account.AccountName);
            Assert.True (account.Active);
            Assert.Equal (4000, account.OpeningBalance);
            Assert.Equal (3, account.CategoryId);

        }

        /// <summary>
        /// checks if updat account request completes successfuly
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task UpdateAccountSuccessfuly () {
            //Given

            var request = new {
                Body = new {
                Id = 10,
                AccountName = "Account Recievable",
                AccountId = "5444",
                Active = 0
                }
            };
            var response = await _client.PutAsync ($"{_ApiUrl}/10", Utilities.GetStringContent (request.Body));
            response.EnsureSuccessStatusCode ();
            //When

            //Then
            Assert.Equal (HttpStatusCode.NoContent, response.StatusCode);
        }

        /// <summary>
        /// checks if update account with non existing account id returns not found
        /// http response
        /// </summary>
        /// <returns></returns>

        [Fact]
        public async Task ReturnNotFoundStatusCodeForUpdateWithNoExistingAccountId () {
            //Given
            var request = new {
                Body = new {
                Id = 1000,
                AccountName = "Account Recievable",
                AccountId = "5444",
                Active = 0
                }
            };
            //When
            var response = await _client.PutAsync ($"{_ApiUrl}/100", Utilities.GetStringContent (request.Body));
            //Then
            Assert.Equal (HttpStatusCode.NotFound, response.StatusCode);
        }

        /// <summary>
        /// checks if delete account request completes successfuly
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task DeletesAccountSuccessfuly () {
            var response = await _client.DeleteAsync ($"{_ApiUrl}/11");
            response.EnsureSuccessStatusCode ();

            Assert.Equal (HttpStatusCode.NoContent, response.StatusCode);
        }

        /// <summary>
        /// checks if delete account request with no id 
        /// returns not found http status code
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task DeleteAccountRequestReturnNotFound () {
            var response = await _client.DeleteAsync ($"{_ApiUrl}/1000");

            Assert.Equal (HttpStatusCode.NotFound, response.StatusCode);
        }

        /// <summary>
        /// tests  successful return of account index getter function
        /// </summary>
        [Fact]
        public async Task ReturnIndexForListOfAccountsSuccessfuly () {

            // Actions
            var response = await _client.GetAsync ($"{_ApiUrl}/index");

            response.EnsureSuccessStatusCode ();
            var account = await Utilities.GetResponseContent<IEnumerable<AccountIndexView>> (response);

            // Assert

            Assert.IsAssignableFrom<List<AccountIndexView>> (account);
        }

    }

}