/*
 * @CreateTime: May 9, 2019 8:12 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 9, 2019 8:44 AM
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

        [Fact]
        public async Task ReturnSingleLedgerEntry () {
            // Arrange
            var response = await _client.GetAsync ($"{_ApiUrl}/10");
            response.EnsureSuccessStatusCode ();
            // Act
            var entry = await Utilities.GetResponseContent<LedgerEntryViewModel> (response);
            Assert.Equal (10, entry.Id);
            Assert.True (entry.LedgerEntries.Count () > 1);

            // Assert
        }

        [Fact]
        public async Task ReturnNotFoundWhenRequestedNoneExistingId () {
            // Arrange
            var response = await _client.GetAsync ($"{_ApiUrl}/100");
            // Act

            // Assert
            Assert.Equal (HttpStatusCode.NotFound, response.StatusCode);
        }

    }
}