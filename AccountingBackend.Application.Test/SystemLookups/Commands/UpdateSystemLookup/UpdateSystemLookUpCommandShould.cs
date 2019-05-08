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
    public class UpdateSystemLookUpCommandShould {

        public Mock<IAccountingDatabaseService> Mockdatabase;
        public UpdateSystemLookUpCommandShould () {
            Mockdatabase = new Mock<IAccountingDatabaseService> ();

            Mockdatabase.Setup (x => x.SaveAsync ()).Returns (Task.CompletedTask);

            Mockdatabase.Setup (x => x.SystemLookup.Add (new SystemLookup () {
                Type = "Cost Center",
                    Value = "Production",
                    DateAdded = DateTime.Now,
                    DateUpdated = DateTime.Now
            }));

            Mockdatabase.Setup (x => x.SystemLookup.Add (new SystemLookup () {
                Type = "Cost Center",
                    Value = "Manufacturing",
                    DateAdded = DateTime.Now,
                    DateUpdated = DateTime.Now
            }));

            Mockdatabase.Setup (c => c.SystemLookup.FindAsync (1)).ReturnsAsync (new SystemLookup () { Id = 1, Value = "Production", Type = "Cost Center" });
            Mockdatabase.Setup (x => x.SystemLookup.FindAsync (2)).ReturnsAsync (new SystemLookup () { Id = 2, Value = "Manufacturing", Type = "Cost Center" });

        }

        [Fact]
        public async Task UpdateSuccessfuly () {

            //Given
            UpdateSystemLookupCommandHandler handler = new UpdateSystemLookupCommandHandler (Mockdatabase.Object);
            //When
            var result = await handler.Handle (new UpdateSystemLookupCommand {
                Lookups = new [] {
                    new UpdatedSystemLookupModel () { Id = 1, Value = "Production Updated", Type = "Cost Center" },
                        new UpdatedSystemLookupModel () { Id = 2, Value = "Production Updated", Type = "Cost Center" }
                }
            }, CancellationToken.None);

            //Then
            Assert.Equal (Unit.Value, result);
        }

        [Fact]
        public async Task ThrowNotFoundException () {
            //Given
            UpdateSystemLookupCommandHandler handler = new UpdateSystemLookupCommandHandler (Mockdatabase.Object);
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