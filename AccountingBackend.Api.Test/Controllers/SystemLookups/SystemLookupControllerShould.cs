/*
 * @CreateTime: May 7, 2019 11:59 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 7, 2019 2:48 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AccountingBackend.Api.Test.Commons;
using AccountingBackend.Application.Accounts.Models;
using AccountingBackend.Application.SystemLookups.Models;
using MediatR;
using Moq;
using Xunit;

namespace AccountingBackend.Api.Test.Controllers.SystemLookups {
    public class SystemLookupControllerShould : IClassFixture<CustomWebApplicationFactory<Startup>> {

        private HttpClient _client;
        private readonly string _ApiUrl = "api/system-lookups";
        private readonly Mock<IMediator> _Mediator = new Mock<IMediator> ();
        public SystemLookupControllerShould (CustomWebApplicationFactory<Startup> factory) {
            _client = factory.CreateClient ();
        }

        [Fact]
        public async Task ReturnListOfSystemlookupsSuccessfuly () {
            // Arrange
            var response = await _client.GetAsync (_ApiUrl);
            // Act

            response.EnsureSuccessStatusCode ();
            // Assert
            var lookups = await Utilities.GetResponseContent<IEnumerable<SystemLookupViewModel>> (response);

            // Assert

            Assert.IsType<List<SystemLookupViewModel>> (lookups);

        }

        [Fact]
        public async Task ReturnsSingleInstanceOfSystemLookupSuccessfuly () {
            // Arrange
            var response = await _client.GetAsync ($"{_ApiUrl}/30");
            // Act

            response.EnsureSuccessStatusCode ();
            // Assert
            var lookups = await Utilities.GetResponseContent<SystemLookupViewModel> (response);

            // Assert

            Assert.IsAssignableFrom<SystemLookupViewModel> (lookups);
        }

        [Fact]
        public async Task ReturnsNotFoundResponse () {
            // Arrange
            var response = await _client.GetAsync ($"{_ApiUrl}/430");
            // Act
            //Assert
            Assert.Equal (HttpStatusCode.NotFound, response.StatusCode);
        }

    }
}