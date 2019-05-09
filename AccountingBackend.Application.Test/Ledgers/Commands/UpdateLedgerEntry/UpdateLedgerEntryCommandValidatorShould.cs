/*
 * @CreateTime: May 10, 2019 12:03 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 10, 2019 12:07 AM
 * @Description: Modify Here, Please 
 */
using System;
using AccountingBackend.Application.Ledgers.Commands.UpdateLedgerEntry;
using FluentValidation.TestHelper;
using Xunit;

namespace AccountingBackend.Application.Test.Ledgers.Commands.UpdateLedgerEntry {
    public class UpdateLedgerEntryCommandValidatorShould {

        private UpdateLedgerEntryCommandValidator validator;

        public UpdateLedgerEntryCommandValidatorShould () {
            validator = new UpdateLedgerEntryCommandValidator ();
        }

        [Fact]
        public void HaveErrorWhenIdIsNull () {
            validator.ShouldHaveValidationErrorFor (x => x.Id, 0);
        }

        [Fact]
        public void NotHaveErrorWhenIdIsNotNull () {
            validator.ShouldNotHaveValidationErrorFor (x => x.Id, 10);
        }

        [Fact]
        public void HaveErrorWhenDescriptionIsNullOrEmpty () {
            validator.ShouldHaveValidationErrorFor (x => x.Description, null as string);
        }

        [Fact]
        public void NotHaveValidationErrorWhenDescriptionIsNotNullOrEmpty () {
            validator.ShouldNotHaveValidationErrorFor (x => x.Description, "description");
        }

        [Fact]
        public void HaveErrorWhenVoucherIdIsNullOrEmpty () {
            validator.ShouldHaveValidationErrorFor (x => x.VoucherId, null as string);
        }

        [Fact]
        public void NotHaveValidationErrorWhenVoucherIdIsNotNullOrEmpty () {
            validator.ShouldNotHaveValidationErrorFor (x => x.VoucherId, "description");
        }

        [Fact]
        public void NotHaveValidationErrorWhenDateIsNotNullOrEmpty () {
            validator.ShouldNotHaveValidationErrorFor (x => x.Date, DateTime.Now);
        }

        [Fact]
        public void NotHaveValidationErrorWhenReferenceIsNotNullOrEmpty () {
            validator.ShouldNotHaveValidationErrorFor (x => x.Reference, null as string);
        }

        [Fact]
        public void NotHaveValidationErrorWhenIsNotNullOrEmpty () {
            validator.ShouldNotHaveValidationErrorFor (x => x.Date, DateTime.Now);
        }

    }
}