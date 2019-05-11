/*
 * @CreateTime: May 7, 2019 5:18 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 7, 2019 5:36 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Application.SystemLookups.Commands.CreateSystemLookup;
using AccountingBackend.Application.SystemLookups.Models;
using AccountingBackend.Domain;
using MediatR;
using Moq;
using Xunit;

namespace AccountingBackend.Application.Test.SystemLookups.Commands.CreateSysystemLookup {
    public class CreateSystemLookupCommandShould : DatabaseTestBase {

        [Fact]
        public async Task CreateSystemLookupsSuccessfuly () {
            CreateSystemLookupCommand createCommand = new CreateSystemLookupCommand () {
                Lookups = new [] {
                new NewSystemLookupModel () { Value = "Production", Type = "Cost Center" },
                new NewSystemLookupModel () { Value = "Manufacturing", Type = "Cost Center" }
                }
            };

            CreateSystemLookupCommandHandler handler = new CreateSystemLookupCommandHandler (_Database);

            //Assert
            var result = await handler.Handle (createCommand, CancellationToken.None);

            Assert.Equal (Unit.Value, result);
        }
    }
}