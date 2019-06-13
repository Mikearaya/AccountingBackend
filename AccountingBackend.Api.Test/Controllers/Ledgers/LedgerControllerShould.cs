/*
 * @CreateTime: May 9, 2019 8:12 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 9, 2019 1:24 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AccountingBackend.Api.Test.Commons;
using AccountingBackend.Application.Ledgers.Models;
using AccountingBackend.Application.Models;
using Xunit;

namespace AccountingBackend.Api.Test.Controllers.Ledgers {
    public class LedgerControllerShould : IClassFixture<CustomWebApplicationFactory<Startup>> {

        private HttpClient _client;
        private string _ApiUrl = "api/ledgers";
        public LedgerControllerShould (CustomWebApplicationFactory<Startup> factory) {
            _client = factory.CreateClient ();
        }

        /// <summary>
        /// tests the successful return of single ledger entry specified by the id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ReturnSingleLedgerEntrySuccessfuly () {
            // Arrange
            var response = await _client.GetAsync ($"{_ApiUrl}/10");
            response.EnsureSuccessStatusCode ();
            // Act
            var entry = await Utilities.GetResponseContent<LedgerEntryViewModel> (response);

            // Assert
            Assert.Equal (10, entry.Id);
            Assert.True (entry.Entries.Count () > 1);
            Assert.Equal (HttpStatusCode.OK, response.StatusCode);
        }

        /// <summary>
        /// test the return of not found http response in the case if the requested id doesnt exist in the system
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ReturnNotFoundWhenRequestedNoneExistingId () {
            // Arrange
            var response = await _client.GetAsync ($"{_ApiUrl}/100");
            // Act

            // Assert
            Assert.Equal (HttpStatusCode.NotFound, response.StatusCode);
        }

        /// <summary>
        /// tests the successful return of list of jornal entries
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ReturnsListsOfJornalEntriesSuccessfully () {
            // Arrange
            var response = await _client.PostAsync ($"{_ApiUrl}/filter", Utilities.GetStringContent (new { }));
            response.EnsureSuccessStatusCode ();
            // Act
            var entries = await Utilities.GetResponseContent<FilterResultModel<JornalEntryListView>> (response);

            // Assert
            Assert.True (((FilterResultModel<JornalEntryListView>) entries).Items.Count () > 0);
            Assert.Equal (HttpStatusCode.OK, response.StatusCode);
        }

        /// <summary>
        /// tests the creation of ledger entry successfuly when every thing is passed is
        /// set to valid value
        /// </summary>
        [Fact]
        public async Task CreatesSuccessfuly () {
            // Arrange
            var request = new {
                Body = new {
                Description = "Test",
                VoucherId = "JV/009",
                Date = DateTime.Now,
                Reference = "CH-01",
                Posted = 0,
                Entries = new [] {
                new { AccountId = 13, Credit = 100, Debit = 0 },
                new { AccountId = 11, Credit = 0, Debit = 100 }
                }
                }
            };
            // Act
            var response = await _client.PostAsync (_ApiUrl, Utilities.GetStringContent (request.Body));

            response.EnsureSuccessStatusCode ();

            // Assert
            Assert.Equal (HttpStatusCode.Created, response.StatusCode);

        }

        /// <summary>
        /// tests if response is 422 when passed a ledger entry without balanced contetnt
        /// </summary>
        /// <returns></returns>

        [Fact]
        public async Task Return422ResponseWhenMakingUnBallanceEntry () {

            // Arrange
            var request = new {
                Body = new {
                Description = "Test",
                VoucherId = "JV/005",
                Date = DateTime.Now,
                Reference = "CH-01",
                Posted = 0,
                Entries = new [] {
                new { AccountId = 10, Credit = 100, Debit = 0 },
                new { AccountId = 11, Credit = 0, Debit = 200 }
                }
                }
            };
            // Act
            var response = await _client.PostAsync (_ApiUrl, Utilities.GetStringContent (request.Body));
            var reesponseContent = await response.Content.ReadAsStringAsync ();
            // Assert
            Assert.Equal (HttpStatusCode.UnprocessableEntity, response.StatusCode);
            Assert.Contains ("not balanced", reesponseContent);
        }

        /// <summary>
        /// tests successful update of ledger entry
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task UpdateSuccessfuly () {
            //Given
            // Arrange
            var request = new {
                Body = new {
                Id = 10,
                Description = "Test",
                VoucherId = "JV/005",
                Date = DateTime.Now,
                Reference = "CH-01",
                Posted = 0,
                Entries = new [] {
                new { Id = 10, AccountId = 10, Credit = 100, Debit = 0 },
                new { Id = 11, AccountId = 11, Credit = 0, Debit = 100 }
                }
                }
            };
            //When
            var response = await _client.PutAsync ($"{_ApiUrl}/10", Utilities.GetStringContent (request.Body));
            response.EnsureSuccessStatusCode ();
            //Then
            Assert.Equal (HttpStatusCode.NoContent, response.StatusCode);
        }

        /// <summary>
        /// tests the return of not found status code when requesting to update a ledger that doesnt exist
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Return404WhenRequestedForUpdateNonExistingId () {
            //Given
            // Arrange
            var request = new {
                Body = new {
                Id = 25,
                Description = "Test",
                VoucherId = "JV/005",
                Date = DateTime.Now,
                Reference = "CH-01",
                Posted = 0,
                Entries = new [] {
                new { Id = 10, AccountId = 10, Credit = 100, Debit = 0 },
                new { Id = 11, AccountId = 11, Credit = 0, Debit = 100 }
                }
                }
            };
            //When
            var response = await _client.PutAsync ($"{_ApiUrl}/10", Utilities.GetStringContent (request.Body));

            //Then
            Assert.Equal (HttpStatusCode.NotFound, response.StatusCode);
        }

        /// <summary>
        /// tests the return of invalid/unprocessable entity reponse when the leger entries dont balance
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Return422WhenRequestedForUpdateNotBallancedEntries () {

            // Arrange
            var request = new {
                Body = new {
                Id = 10,
                Description = "Test",
                VoucherId = "JV/005",
                Date = DateTime.Now,
                Reference = "CH-01",
                Posted = 1,
                Entries = new [] {
                new { Id = 10, AccountId = 10, Credit = 100, Debit = 0 },
                new { Id = 11, AccountId = 11, Credit = 0, Debit = 200 }
                }
                }
            };
            //When
            var response = await _client.PutAsync ($"{_ApiUrl}/10", Utilities.GetStringContent (request.Body));

            //Then
            var responseString = await response.Content.ReadAsStringAsync ();
            Assert.Contains ("unbalanced", responseString);
            Assert.Equal (HttpStatusCode.UnprocessableEntity, response.StatusCode);
        }

        /// <summary>
        /// test for deleting ledger entry by id successfuly
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task DeleteLedgerEntrySuccessfuly () {
            var response = await _client.DeleteAsync ($"{_ApiUrl}/11");
            response.EnsureSuccessStatusCode ();
            Assert.Equal (HttpStatusCode.NoContent, response.StatusCode);
        }

        /// <summary>
        /// tests the return of 404 status code when requested to delete ledger entry with id that doesnt exist
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Return404WhenRequestingToDeleteNonExistingEntry () {
            var response = await _client.DeleteAsync ($"{_ApiUrl}/100");
            Assert.Equal (HttpStatusCode.NotFound, response.StatusCode);
        }

        /// <summary>
        /// tests the successful update of ledger entry status from posted to unposted and vice versa
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ChangeStatusOfLedgerEntrySuccessfuly () {
            //Given
            var request = new {
                Body = new {
                Id = 10,
                Posted = true
                }
            };
            //When
            var beforeUpdate = await _client.GetAsync ($"{_ApiUrl}/10");

            var response = await _client.PutAsync ($"{_ApiUrl}/status/10", Utilities.GetStringContent (request.Body));
            var afterUpdate = await _client.GetAsync ($"{_ApiUrl}/10");
            var before = await Utilities.GetResponseContent<LedgerEntryViewModel> (beforeUpdate);
            var after = await Utilities.GetResponseContent<LedgerEntryViewModel> (afterUpdate);
            response.EnsureSuccessStatusCode ();
            //Then
            Assert.NotEqual (after.Posted, before.Posted);
            Assert.Equal (HttpStatusCode.NoContent, response.StatusCode);
        }

        /// <summary>
        /// tests the return of not found response when attempting to update the status of ledger entry whose id does not exist
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Returns404WhenAttemptingUpdateLedgerEntryStatus () {
            //Given
            var request = new {
                Body = new {
                Id = 1000,
                Posted = true
                }
            };
            //When

            var response = await _client.PutAsync ($"{_ApiUrl}/status/1000", Utilities.GetStringContent (request.Body));

            //Then
            Assert.Equal (HttpStatusCode.NotFound, response.StatusCode);
        }

    }
}