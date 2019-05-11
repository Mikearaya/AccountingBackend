/*
 * @CreateTime: May 7, 2019 5:46 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 7, 2019 5:59 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Exceptions;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Application.SystemLookups.Commands.UpdateSystemLookup;
using AccountingBackend.Application.SystemLookups.Models;
using AccountingBackend.Domain;
using MediatR;
using Moq;
using Xunit;

namespace AccountingBackend.Application.Test.SystemLookups.Commands.UpdateSystemLookup {
    public class UpdateSystemLookUpCommandShould : DatabaseTestBase {

        [Fact]
        public async Task UpdateSuccessfuly () {

            //Given
            UpdateSystemLookupCommandHandler handler = new UpdateSystemLookupCommandHandler (_Database);
            //When
            var result = await handler.Handle (new UpdateSystemLookupCommand {
                Lookups = new [] {
                    new UpdatedSystemLookupModel () { Id = 10, Value = "Production Updated", Type = "Cost Center" },
                        new UpdatedSystemLookupModel () { Id = 11, Value = "Production Updated", Type = "Cost Center" }
                }
            }, CancellationToken.None);

            //Then
            Assert.Equal (Unit.Value, result);
        }

        [Fact]
        public async Task ThrowNotFoundException () {
            //Given
            UpdateSystemLookupCommandHandler handler = new UpdateSystemLookupCommandHandler (_Database);
            //Assert
            await Assert.ThrowsAsync<NotFoundException> (() => handler.Handle (new UpdateSystemLookupCommand {
                Lookups = new [] {
                    new UpdatedSystemLookupModel () { Id = 1, Value = "Production Updated", Type = "Cost Center" },
                        new UpdatedSystemLookupModel () { Id = 3, Value = "Production Updated", Type = "Cost Center" }
                }
            }, CancellationToken.None));
        }
    }
}