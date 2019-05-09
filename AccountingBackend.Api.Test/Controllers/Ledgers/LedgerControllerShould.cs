/*
 * @CreateTime: May 9, 2019 8:12 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 9, 2019 10:33 AM
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
            Assert.True (entry.LedgerEntries.Count () > 1);
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
            var response = await _client.GetAsync (_ApiUrl);
            response.EnsureSuccessStatusCode ();
            // Act
            var entries = await Utilities.GetResponseContent<List<JornalEntryListView>> (response);

            // Assert
            Assert.True (entries.Count () > 0);
        }

        /// <summary>
        /// tests the creation of ledger entry successfuly when every thing is passed is
        /// set to valid value
        /// </summary>
        [Fact]
        public async Task CreatesLedgerEntrySuccessfuly () {
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

    }
}