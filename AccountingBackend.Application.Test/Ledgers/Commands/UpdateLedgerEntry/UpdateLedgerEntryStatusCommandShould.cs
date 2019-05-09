using System;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Exceptions;
/*
 * @CreateTime: May 9, 2019 11:48 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 10, 2019 12:02 AM
 * @Description: Modify Here, Please 
 */
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Application.Ledgers.Commands.UpdateLedgerEntry;
using AccountingBackend.Domain;
using MediatR;
using Moq;
using Xunit;

namespace AccountingBackend.Application.Test.Ledgers.Commands.UpdateLedgerEntry {

    public class UpdateLedgerEntryStatusCommandShould {
        private readonly Mock<IAccountingDatabaseService> Mockdatabase;
        private UpdateLedgerStatusCommandHandler handler;
        public UpdateLedgerEntryStatusCommandShould () {
            Mockdatabase = new Mock<IAccountingDatabaseService> ();
            Mockdatabase.Setup (c => c.SaveAsync ()).Returns (Task.CompletedTask);
            Mockdatabase.Setup (c => c.Ledger.Update (new Ledger ()));

            Mockdatabase.Setup (c => c.Ledger.FindAsync (1)).ReturnsAsync (new Ledger () {
                Id = 1,
                    Description = "Ledger Description",
                    VoucherId = "JV/001",
                    Reference = "CH-111",
                    Date = DateTime.Now,
                    IsPosted = 0
            });
        }

        /// <summary>
        /// tests successful operation comple when every parameter is provided as required
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task UpdateLedgerEntryStatusSuccessfuly () {
            // Arrange
            handler = new UpdateLedgerStatusCommandHandler (Mockdatabase.Object);
            UpdateLedgerStatusCommand command = new UpdateLedgerStatusCommand () {
                Id = 1,
                Posted = 1
            };
            // Act
            var result = await handler.Handle (command, CancellationToken.None);

            // Assert
            Assert.Equal (Unit.Value, result);
        }

        /// <summary>
        /// tests the throwing of not found exception when requested to 
        /// update a none existing ledger entry Id
        /// </summary>
        [Fact]
        public void ThrowNotFoundExceptionWhenProvidedInvalidId () {
            // Arrange
            handler = new UpdateLedgerStatusCommandHandler (Mockdatabase.Object);
            UpdateLedgerStatusCommand command = new UpdateLedgerStatusCommand () {
                Id = 2,
                Posted = 1
            };

            // Assert
            Assert.ThrowsAsync<NotFoundException> (() => handler.Handle (command, CancellationToken.None));
        }
    }
}