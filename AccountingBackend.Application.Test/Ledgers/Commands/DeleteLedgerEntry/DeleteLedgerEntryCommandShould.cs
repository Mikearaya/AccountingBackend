/*
 * @CreateTime: May 10, 2019 12:13 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 10, 2019 12:26 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Exceptions;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Application.Ledgers.Commands.DeleteLedgerEntry;
using AccountingBackend.Domain;
using MediatR;
using Moq;
using Xunit;

namespace AccountingBackend.Application.Test.Ledgers.Commands.DeleteLedgerEntry {
    public class DeleteLedgerEntryCommandShould : DatabaseTestBase {
        private DeleteLedgerEntryCommandHandler handler;

        public DeleteLedgerEntryCommandShould () : base () { }

        /// <summary>
        /// test the successful deletion of ledger entry when provided with a valid/existing id
        /// </summary>
        [Fact]
        public async Task DeleteLedgerEntrySuccessfuly () {
            // Arrange
            handler = new DeleteLedgerEntryCommandHandler (_Database);
            DeleteLedgerEntryCommand command = new DeleteLedgerEntryCommand () { Id = 10 };
            // Act
            var result = await handler.Handle (command, CancellationToken.None);

            // Assert
            Assert.Equal (Unit.Value, result);
        }

        /// <summary>
        /// tests the throwing of not found exception when requested to delete a non existing ledger id
        /// </summary>
        [Fact]
        public void ThrowNotFoundException () {
            // Arrange
            handler = new DeleteLedgerEntryCommandHandler (_Database);
            DeleteLedgerEntryCommand command = new DeleteLedgerEntryCommand () { Id = 2 };

            // Assert
            Assert.ThrowsAsync<NotFoundException> (() => handler.Handle (command, CancellationToken.None));
        }
    }
}