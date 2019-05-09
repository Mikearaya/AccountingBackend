/*
 * @CreateTime: May 10, 2019 12:22 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 10, 2019 12:24 AM
 * @Description: Modify Here, Please 
 */
using AccountingBackend.Application.Ledgers.Commands.DeleteLedgerEntry;
using FluentValidation.TestHelper;
using Xunit;

namespace AccountingBackend.Application.Test.Ledgers.Commands.DeleteLedgerEntry {
    public class DeleteLedgerEntryCommandValidatorShould {
        private DeleteLedgerEntryCommandValidator validator;

        public DeleteLedgerEntryCommandValidatorShould () {
            validator = new DeleteLedgerEntryCommandValidator ();
        }

        [Fact]
        public void HaveErrorWhenIdIsNull () {
            validator.ShouldHaveValidationErrorFor (x => x.Id, 0);
        }

        [Fact]
        public void NotHaveErrorWhenIdIsNotNull () {
            validator.ShouldNotHaveValidationErrorFor (x => x.Id, 1000);
        }
    }
}