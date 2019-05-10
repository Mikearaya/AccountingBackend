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
 * @Last Modified Time: May 10, 2019 2:28 PM
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
    public class UpdateLedgerEntryCommandHandlerShould {

        private readonly Mock<IAccountingDatabaseService> Mockdatabase;
        private UpdateLedgerEntryCommandHandler handler;
        public UpdateLedgerEntryCommandHandlerShould () {
            Mockdatabase = new Mock<IAccountingDatabaseService> ();
            Mockdatabase.Setup (d => d.SaveAsync ()).Returns (Task.CompletedTask);
            Mockdatabase.Setup (d => d.Ledger.FindAsync (1)).ReturnsAsync (new Ledger () {
                Id = 1,
                    VoucherId = "JV/001",
                    Date = DateTime.Now,
                    Description = "test",
                    Reference = "CH--001",
                    IsPosted = 0,
                    DateAdded = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    LedgerEntry = new List<LedgerEntry> () {
                        new LedgerEntry () { Id = 1, AccountId = 10, Credit = 0, Debit = 100, DateAdded = DateTime.Now, DateUpdated = DateTime.Now },
                            new LedgerEntry () { Id = 2, AccountId = 11, Credit = 100, Debit = 0, DateAdded = DateTime.Now, DateUpdated = DateTime.Now },
                    }
            });

            Mockdatabase.Setup (d =>
                    d.LedgerEntry.FindAsync (1))
                .ReturnsAsync (new LedgerEntry () {
                    Id = 1, AccountId = 10, Credit = 0, Debit = 100, DateAdded = DateTime.Now, DateUpdated = DateTime.Now
                });
            Mockdatabase.Setup (d =>
                    d.LedgerEntry.FindAsync (2))
                .ReturnsAsync (new LedgerEntry () {
                    Id = 2, AccountId = 11, Credit = 100, Debit = 0, DateAdded = DateTime.Now, DateUpdated = DateTime.Now
                });

            Mockdatabase.Setup (d => d.LedgerEntry.Remove (new LedgerEntry ()));
            Mockdatabase.Setup (d => d.LedgerEntry.Update (new LedgerEntry ()));
            Mockdatabase.Setup (d => d.LedgerEntry.Add (new LedgerEntry ()));

        }

        /// <summary>
        /// tests the successful completion of update when ecery parameter is provided as suggested
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task UpdateSuccessfully () {
            // Arrange
            handler = new UpdateLedgerEntryCommandHandler (Mockdatabase.Object);
            UpdateLedgerEntryCommand command = new UpdateLedgerEntryCommand () {
                Id = 1,
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
            handler = new UpdateLedgerEntryCommandHandler (Mockdatabase.Object);
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
            Mockdatabase.Setup (d => d.Ledger.FindAsync (2)).ReturnsAsync (new Ledger () {
                Id = 2,
                    VoucherId = "JV/001",
                    Date = DateTime.Now,
                    Description = "test",
                    Reference = "CH--001",
                    IsPosted = 1,
                    DateAdded = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    LedgerEntry = new List<LedgerEntry> () {
                        new LedgerEntry () { Id = 3, AccountId = 10, Credit = 0, Debit = 100, DateAdded = DateTime.Now, DateUpdated = DateTime.Now },
                            new LedgerEntry () { Id = 4, AccountId = 11, Credit = 100, Debit = 0, DateAdded = DateTime.Now, DateUpdated = DateTime.Now },
                    }
            });
            handler = new UpdateLedgerEntryCommandHandler (Mockdatabase.Object);
            UpdateLedgerEntryCommand command = new UpdateLedgerEntryCommand () {
                Id = 2,
                Description = "updated Description",
                Date = DateTime.Now,
                Posted = 0,
                VoucherId = "JV/001",
                Reference = "CH--11",
                Entries = new List<UpdatedLedgerEntryModel> () {
                new UpdatedLedgerEntryModel () { Id = 10, Debit = 110, Credit = 0, AccountId = 10 },
                new UpdatedLedgerEntryModel () { Id = 11, Debit = 0, Credit = 110, AccountId = 11 }
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

            handler = new UpdateLedgerEntryCommandHandler (Mockdatabase.Object);
            UpdateLedgerEntryCommand command = new UpdateLedgerEntryCommand () {
                Id = 1,
                Description = "updated Description",
                Date = DateTime.Now,
                Posted = 0,
                VoucherId = "JV/001",
                Reference = "CH--11",
                Entries = new List<UpdatedLedgerEntryModel> () {
                new UpdatedLedgerEntryModel () { Id = 10, Debit = 110, Credit = 0, AccountId = 10 },
                new UpdatedLedgerEntryModel () { Id = 11, Debit = 0, Credit = 110, AccountId = 11 },
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

            handler = new UpdateLedgerEntryCommandHandler (Mockdatabase.Object);
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

            handler = new UpdateLedgerEntryCommandHandler (Mockdatabase.Object);
            UpdateLedgerEntryCommand command = new UpdateLedgerEntryCommand () {
                Id = 1,
                Description = "updated Description",
                Date = DateTime.Now,
                Posted = 0,
                VoucherId = "JV/001",
                Reference = "CH--11",
                Entries = new List<UpdatedLedgerEntryModel> () {
                new UpdatedLedgerEntryModel () { Id = 10, Debit = 110, Credit = 0, AccountId = 10 },
                new UpdatedLedgerEntryModel () { Id = 11, Debit = 0, Credit = 110, AccountId = 11 },
                new UpdatedLedgerEntryModel () { Id = 0, Debit = 0, Credit = 220, AccountId = 11 },
                new UpdatedLedgerEntryModel () { Id = 0, Debit = 220, Credit = 0, AccountId = 12 }
                },
                DeletedIds = new List<int> {
                1,
                2
                }

            };

            var result = await handler.Handle (command, CancellationToken.None);

            // Assert

            Assert.Equal (Unit.Value, result);
        }
    }

}