using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Exceptions;
/*
 * @CreateTime: May 9, 2019 2:36 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 12, 2019 3:18 PM
 * @Description: Modify Here, Please 
 */
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Application.Ledgers.Commands.UpdateLedgerEntry;
using AccountingBackend.Application.Ledgers.Models;
using AccountingBackend.Domain;
using MediatR;
using Moq;
using Xunit;

namespace AccountingBackend.Application.Test.Ledgers.Commands.UpdateLedgerEntry {
    public class UpdateLedgerEntryCommandHandlerShould : DatabaseTestBase {

        private UpdateLedgerEntryCommandHandler handler;

        /// <summary>
        /// tests the successful completion of update when ecery parameter is provided as suggested
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task UpdateSuccessfully () {
            // Arrange
            handler = new UpdateLedgerEntryCommandHandler (_Database);
            UpdateLedgerEntryCommand command = new UpdateLedgerEntryCommand () {
                Id = 11,
                Description = "updated Description",
                Date = DateTime.Now,
                Posted = 0,
                VoucherId = "JV/001",
                Reference = "CH--11",
                Entries = new List<UpdatedLedgerEntryModel> () {
                new UpdatedLedgerEntryModel () { Id = 22, Debit = 110, Credit = 0, AccountId = 10 },
                new UpdatedLedgerEntryModel () { Id = 23, Debit = 0, Credit = 110, AccountId = 11 }
                }
            };
            // Act
            var result = await handler.Handle (command, CancellationToken.None);
            // Assert

            Assert.Equal (Unit.Value, result);
        }

        /// <summary>
        /// testing the return of not found exception when attempting to update non existing ledger entry
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ThrowNotFoundExceptionWhenGivenNonExistingId () {
            // Arrange
            handler = new UpdateLedgerEntryCommandHandler (_Database);
            UpdateLedgerEntryCommand command = new UpdateLedgerEntryCommand () {
                Id = 2,
                Description = "updated Description",
                Date = DateTime.Now,
                Posted = 1,
                VoucherId = "JV/001",
                Reference = "CH--11",
                Entries = new List<UpdatedLedgerEntryModel> () {
                new UpdatedLedgerEntryModel () { Id = 10, Debit = 110, Credit = 0, AccountId = 10 },
                new UpdatedLedgerEntryModel () { Id = 11, Debit = 0, Credit = 110, AccountId = 11 }
                }
            };
            // Act
            await Assert.ThrowsAsync<NotFoundException> (() => handler.Handle (command, CancellationToken.None));
        }

        /// <summary>
        /// tests disallowing of update to a posted ledger entry 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ThrowValidationExceptionWhenUpdatingPostedLedgerEntry () {
            // Arrange
            handler = new UpdateLedgerEntryCommandHandler (_Database);
            UpdateLedgerEntryCommand command = new UpdateLedgerEntryCommand () {
                Id = 10,
                Description = "updated Description",
                Date = DateTime.Now,
                Posted = 1,
                VoucherId = "JV/001",
                Reference = "CH--11",
                Entries = new List<UpdatedLedgerEntryModel> () {
                new UpdatedLedgerEntryModel () { Id = 20, Debit = 117, Credit = 0, AccountId = 10 },
                new UpdatedLedgerEntryModel () { Id = 21, Debit = 0, Credit = 110, AccountId = 11 }
                }
            };
            // Act
            await Assert.ThrowsAsync<ValidationException> (() => handler.Handle (command, CancellationToken.None));
        }

        /// <summary>
        /// testing the validation of ensuring balanced entries are being made
        /// otherwhise throwing validation error
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ThrowValidationExceptionWhenUpdatingUnbalancedLedgerEntry () {
            // Arrange

            handler = new UpdateLedgerEntryCommandHandler (_Database);
            UpdateLedgerEntryCommand command = new UpdateLedgerEntryCommand () {
                Id = 11,
                Description = "updated Description",
                Date = DateTime.Now,
                Posted = 1,
                VoucherId = "JV/001",
                Reference = "CH--11",
                Entries = new List<UpdatedLedgerEntryModel> () {
                new UpdatedLedgerEntryModel () { Id = 22, Debit = 110, Credit = 0, AccountId = 10 },
                new UpdatedLedgerEntryModel () { Id = 23, Debit = 0, Credit = 110, AccountId = 11 },
                new UpdatedLedgerEntryModel () { Id = 0, Debit = 0, Credit = 100, AccountId = 11 },
                new UpdatedLedgerEntryModel () { Id = 0, Debit = 220, Credit = 0, AccountId = 12 }
                }
            };

            // Assert

            await Assert.ThrowsAsync<ValidationException> (() => handler.Handle (command, CancellationToken.None));
        }

        /// <summary>
        /// testing of throwing not found exception when attempting to delete non existing ledger entry
        /// </summary>
        /// <returns></returns>

        [Fact]
        public async Task ThrowNotFoundExceptionWhenDeletingNonExistingEntryId () {
            // Arrange

            handler = new UpdateLedgerEntryCommandHandler (_Database);
            UpdateLedgerEntryCommand command = new UpdateLedgerEntryCommand () {
                Id = 1,
                Description = "updated Description",
                Date = DateTime.Now,
                Posted = 0,
                VoucherId = "JV/001",
                Reference = "CH--11",
                Entries = new List<UpdatedLedgerEntryModel> () {
                new UpdatedLedgerEntryModel () { Id = 100, Debit = 110, Credit = 0, AccountId = 10 },
                new UpdatedLedgerEntryModel () { Id = 11, Debit = 0, Credit = 110, AccountId = 11 },
                new UpdatedLedgerEntryModel () { Id = 0, Debit = 0, Credit = 220, AccountId = 11 },
                new UpdatedLedgerEntryModel () { Id = 0, Debit = 220, Credit = 0, AccountId = 12 }
                },
                DeletedIds = new List<int> {
                100,
                200
                }

            };

            // Assert

            await Assert.ThrowsAsync<NotFoundException> (() => handler.Handle (command, CancellationToken.None));
        }

        /// <summary>
        /// tests the successful update and delete operation completion of updatedcommandhandler
        /// </summary>
        /// <returns></returns>

        [Fact]
        public async Task DeleteEntrySuccessful () {
            // Arrange

            handler = new UpdateLedgerEntryCommandHandler (_Database);
            UpdateLedgerEntryCommand command = new UpdateLedgerEntryCommand () {
                Id = 11,
                Description = "updated Description",
                Date = DateTime.Now,
                Posted = 0,
                VoucherId = "JV/001",
                Reference = "CH--11",
                Entries = new List<UpdatedLedgerEntryModel> () {
                new UpdatedLedgerEntryModel () { Id = 22, Debit = 110, Credit = 0, AccountId = 10 },
                new UpdatedLedgerEntryModel () { Id = 23, Debit = 0, Credit = 110, AccountId = 11 },
                new UpdatedLedgerEntryModel () { Id = 0, Debit = 0, Credit = 220, AccountId = 11 },
                new UpdatedLedgerEntryModel () { Id = 0, Debit = 220, Credit = 0, AccountId = 12 }
                },
                DeletedIds = new List<int> {
                22
                }

            };

            var result = await handler.Handle (command, CancellationToken.None);

            // Assert

            Assert.Equal (Unit.Value, result);
        }
    }

}