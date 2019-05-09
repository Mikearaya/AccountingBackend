/*
 * @CreateTime: May 9, 2019 8:12 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 9, 2019 8:56 AM
 * @Description: Modify Here, Please 
 */
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

    }
}