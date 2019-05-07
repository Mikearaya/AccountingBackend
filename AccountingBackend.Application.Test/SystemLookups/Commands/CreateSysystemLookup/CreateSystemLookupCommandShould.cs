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
    public class CreateSystemLookupCommandShould {

        private readonly Mock<IAccountingDatabaseService> _Mockdatabase;
        private CreateSystemLookupCommand createCommand;

        public CreateSystemLookupCommandShould () {

            _Mockdatabase = new Mock<IAccountingDatabaseService> ();

            _Mockdatabase.Setup (x => x.SaveAsync ()).Returns (Task.CompletedTask);

            _Mockdatabase.Setup (x => x.SystemLookup.Add (new SystemLookup () {
                Type = "Cost Center",
                    Value = "Production",
                    DateAdded = DateTime.Now,
                    DateUpdated = DateTime.Now
            }));

            _Mockdatabase.Setup (x => x.SystemLookup.Add (new SystemLookup () {
                Type = "Cost Center",
                    Value = "Manufacturing",
                    DateAdded = DateTime.Now,
                    DateUpdated = DateTime.Now
            }));
        }

        [Fact]
        public async Task CreateSystemLookupsSuccessfuly () {
            createCommand = new CreateSystemLookupCommand () {
                Lookups = new [] {
                new NewSystemLookupModel () { Value = "Production", Type = "Cost Center" },
                new NewSystemLookupModel () { Value = "Manufacturing", Type = "Cost Center" }
                }
            };

            CreateSystemLookupCommandHandler handler = new CreateSystemLookupCommandHandler (_Mockdatabase.Object);

            //Assert
            var result = await handler.Handle (createCommand, CancellationToken.None);

            Assert.Equal (Unit.Value, result);
        }
    }
}