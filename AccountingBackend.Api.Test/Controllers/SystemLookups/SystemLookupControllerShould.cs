/*
 * @CreateTime: May 7, 2019 11:59 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 7, 2019 3:58 PM
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="factory"></param>
        public SystemLookupControllerShould (CustomWebApplicationFactory<Startup> factory) {
            _client = factory.CreateClient ();
        }

        /// <summary>
        /// tests the successful return system look up array list
        /// </summary>
        /// <returns></returns>

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

        /// <summary>
        /// tests the successful return system look up array list based on look up type type
        /// </summary>
        /// <returns></returns>

        [Fact]
        public async Task ReturnListOfSystemlookupTypeSuccessfuly () {
            // Arrange
            var response = await _client.GetAsync ($"{_ApiUrl}/type?Type=Cost Center");
            // Act

            response.EnsureSuccessStatusCode ();
            // Assert
            var lookups = await Utilities.GetResponseContent<IEnumerable<SystemLookupViewModel>> (response);

            // Assert

            Assert.IsType<List<SystemLookupViewModel>> (lookups);

        }

        /// <summary>
        /// test the return of single instance of system look up object based on the id provided
        /// </summary>
        /// <returns></returns>

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

        /// <summary>
        /// tests not found reponse been reponded when requested for non existing system look up Id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ReturnsNotFoundResponse () {
            // Arrange
            var response = await _client.GetAsync ($"{_ApiUrl}/430");
            // Act
            //Assert
            Assert.Equal (HttpStatusCode.NotFound, response.StatusCode);
        }

        /// <summary>
        /// test the successful completion of system lookup
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreatesSystemLookupSuccessfully () {
            // Arrange

            var request = new {
                body = new {
                lookUps = new [] {
                new {
                value = "Production",
                type = "Cost center"
                }, new {
                value = "Manufacturing",
                type = "Cost center"
                }
                }
                }
            };
            // Act

            var response = await _client.PostAsync (_ApiUrl, Utilities.GetRequestContent (request.body));
            response.EnsureSuccessStatusCode ();
            // Assert

        }

        /// <summary>
        /// tests successful reponse when updating system lookup
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task UpdateSystemLookupSuccessfully () {
            // Arrange

            var request = new {
                body = new {
                lookUps = new [] {
                new {
                Id = 30,
                value = "Production",
                type = "Cost center"
                }, new {
                Id = 50,
                value = "Manufacturing",
                type = "Cost center"
                }
                }
                }
            };
            // Act

            var response = await _client.PutAsync (_ApiUrl, Utilities.GetRequestContent (request.body));
            response.EnsureSuccessStatusCode ();
            // Assert

        }

        /// <summary>
        /// tests if there not found response is produced when none existing id is provided in the 
        /// system look up array
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ReturnNotFoundForNonExistingIdOnUpdate () {
            // Arrange

            var request = new {
                body = new {
                lookUps = new [] {
                new {
                Id = 60,
                value = "Production",
                type = "Cost center"
                }, new {
                Id = 50,
                value = "Manufacturing",
                type = "Cost center"
                }
                }
                }
            };
            // Act

            // Assert
            var response = await _client.PutAsync (_ApiUrl, Utilities.GetRequestContent (request.body));
            Assert.Equal (HttpStatusCode.NotFound, response.StatusCode);

        }
    }

}