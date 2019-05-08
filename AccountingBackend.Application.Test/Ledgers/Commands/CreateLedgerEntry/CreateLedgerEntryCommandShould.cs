/*
 * @CreateTime: May 8, 2019 9:54 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 8, 2019 10:50 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Interfaces;
using AccountingBackend.Application.Ledgers.Commands.CreateLedgerEntry;
using AccountingBackend.Application.Ledgers.Models;
using AccountingBackend.Domain;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace AccountingBackend.Application.Test.Ledgers.Commands.CreateLedgerEntry {
    public class CreateLedgerEntryCommandShould {

        private Mock<IAccountingDatabaseService> _Mockdatabase;
        public CreateLedgerEntryCommandShould () {

            _Mockdatabase = new Mock<IAccountingDatabaseService> ();
            _Mockdatabase.Setup (x => x.SaveAsync ()).Returns (Task.CompletedTask);
        }

        public async Task CreateNewLedgerEntrySuccessfuly () {
            var isUnitq = false;
            // Arrange
            _Mockdatabase.Setup (x => x.Ledger.Any (It.IsAny<Expression<Func<Ledger, bool>>> ()))
                .Callback<Expression<Func<Ledger, bool>>> (
                    expression => {
                        var func = expression.Compile ();
                        isUnitq = func (new Ledger () { VoucherId = "JV/001" });
                    })
                .Returns (() => isUnitq);
            //  _Mockdatabase.Setup (x => x.Ledger.AnyAsync (d => d.VoucherId.ToLower ().Trim () == "JV/001")).ReturnsAsync (false);
            _Mockdatabase.Setup (x => x.Ledger.Add (new Ledger ()));

            CreateLedgerEntryCommand command = new CreateLedgerEntryCommand () {
                Description = "Testing Ledger entry working",
                VoucherId = "JV/001",
                Date = DateTime.Now,
                Posted = 0,
                Entries = new List<NewLedgerEntryModel> () {
                new NewLedgerEntryModel () { Credit = 100, AccountId = 1 },
                new NewLedgerEntryModel () { Debit = 100, AccountId = 2 }
                }
            };

            CreateLedgerEntryCommandHandler handler = new CreateLedgerEntryCommandHandler (_Mockdatabase.Object);
            // Act
            var result = await handler.Handle (command, CancellationToken.None);

            // Assert
            Assert.Equal (0, result);
        }
    }
}