/*
 * @CreateTime: May 7, 2019 11:59 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 7, 2019 12:34 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
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
            var account = await Utilities.GetResponseContent<IEnumerable<AccountViewModel>> (response);

            // Assert

            Assert.IsType<List<AccountViewModel>> (account);

        }

    }
}