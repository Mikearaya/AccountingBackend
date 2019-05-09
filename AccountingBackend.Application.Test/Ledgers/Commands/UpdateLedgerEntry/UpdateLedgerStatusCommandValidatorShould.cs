/*
 * @CreateTime: May 10, 2019 12:08 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 10, 2019 12:11 AM
 * @Description: Modify Here, Please 
 */
using AccountingBackend.Application.Ledgers.Commands.UpdateLedgerEntry;
using FluentValidation.TestHelper;
using Xunit;

namespace AccountingBackend.Application.Test.Ledgers.Commands.UpdateLedgerEntry {
    public class UpdateLedgerStatusCommandValidatorShould {
        private UpdateLedgerStatusCommandValidator validator;

        public UpdateLedgerStatusCommandValidatorShould () {
            validator = new UpdateLedgerStatusCommandValidator ();
        }

        [Fact]
        public void HaveErrorWhenIdIsNull () {
            validator.ShouldHaveValidationErrorFor (x => x.Id, 0);
        }

        [Fact]
        public void NotHaveErrorWhenIdIsNotNull () {
            validator.ShouldNotHaveValidationErrorFor (x => x.Id, 10);
        }
    }
}