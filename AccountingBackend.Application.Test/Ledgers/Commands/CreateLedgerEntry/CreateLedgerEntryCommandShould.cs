/*
 * @CreateTime: May 8, 2019 9:54 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 10, 2019 10:42 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Exceptions;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Application.Ledgers.Commands.CreateLedgerEntry;
using AccountingBackend.Application.Ledgers.Models;
using AccountingBackend.Domain;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace AccountingBackend.Application.Test.Ledgers.Commands.CreateLedgerEntry {
    public class CreateLedgerEntryCommandShould : DatabaseTestBase {
        private CreateLedgerEntryCommandHandler handler;
        public CreateLedgerEntryCommandShould () {
            handler = new CreateLedgerEntryCommandHandler (_Database);
        }

        [Fact]
        public async Task CreateEntrySuccessfuly () {

            // Arrange
            CreateLedgerEntryCommand command = new CreateLedgerEntryCommand () {
                Description = "Testing Ledger entry working",
                Reference = "",
                VoucherId = "JV/088",
                Date = DateTime.Now,
                Posted = 0,
                Entries = new List<NewLedgerEntryModel> () {
                new NewLedgerEntryModel () { Credit = 100, Debit = 0, AccountId = 1 },
                new NewLedgerEntryModel () { Debit = 100, Credit = 0, AccountId = 2 }
                }
            };

            // Act
            var result = await handler.Handle (command, CancellationToken.None);

            // Assert
            Assert.NotEqual (0, result);
        }

        [Fact]
        public async Task ThrowValidationErrorWhenVoucherIdExist () {
            //Given
            CreateLedgerEntryCommand command = new CreateLedgerEntryCommand () {
                Description = "Testing Ledger entry working",
                Reference = "",
                VoucherId = "JV/001",
                Date = DateTime.Now,
                Posted = 0,
                Entries = new List<NewLedgerEntryModel> () {
                new NewLedgerEntryModel () { Credit = 100, Debit = 0, AccountId = 1 },
                new NewLedgerEntryModel () { Debit = 100, Credit = 0, AccountId = 2 }
                }
            };
            //When

            //Then
            await Assert.ThrowsAsync<ValidationException> (() => handler.Handle (command, CancellationToken.None));
        }

        [Fact]
        public async Task ThrowsValidationErrorWhenLessThanTwoAccountsAreAffected () {
            //Given
            CreateLedgerEntryCommand command = new CreateLedgerEntryCommand () {
                Description = "Testing Ledger entry working",
                Reference = "",
                VoucherId = "JV/090",
                Date = DateTime.Now,
                Posted = 0,
                Entries = new List<NewLedgerEntryModel> () {
                new NewLedgerEntryModel () { Credit = 100, Debit = 0, AccountId = 1 },
                }
            };
            //When

            //Then
            await Assert.ThrowsAsync<ValidationException> (() => handler.Handle (command, CancellationToken.None));
        }

        [Fact]
        public async Task ThrowsValidationErrorWhenEntriesDontBalance () {
            //Given
            CreateLedgerEntryCommand command = new CreateLedgerEntryCommand () {
                Description = "Testing Ledger entry working",
                Reference = "",
                VoucherId = "JV/090",
                Date = DateTime.Now,
                Posted = 0,
                Entries = new List<NewLedgerEntryModel> () {
                new NewLedgerEntryModel () { Credit = 100, Debit = 0, AccountId = 1 },
                new NewLedgerEntryModel () { Debit = 50, Credit = 0, AccountId = 2 }

                }
            };
            //When

            //Then
            await Assert.ThrowsAsync<ValidationException> (() => handler.Handle (command, CancellationToken.None));
        }

    }
}