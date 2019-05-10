/*
 * @CreateTime: May 10, 2019 11:02 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 10, 2019 11:02 AM
 * @Description: Modify Here, Please 
 */
using System;
using AccountingBackend.Application.Ledgers.Commands.CreateLedgerEntry;
using FluentValidation.TestHelper;
using Xunit;

namespace AccountingBackend.Application.Test.Ledgers.Commands.CreateLedgerEntry {
    public class CreateLedgerEntryCommandValidatorShould {

        private CreateLedgerEntryCommandValidator validator;
        private DateTime? nullDate = null;
        public CreateLedgerEntryCommandValidatorShould () {
            validator = new CreateLedgerEntryCommandValidator ();
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