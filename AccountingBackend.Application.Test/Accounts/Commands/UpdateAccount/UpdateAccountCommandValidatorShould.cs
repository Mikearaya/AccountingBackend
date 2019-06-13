/*
 * @CreateTime: May 3, 2019 9:53 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 3, 2019 10:04 AM
 * @Description: Modify Here, Please 
 */
using AccountingBackend.Application.Accounts.Commands.UpdateAccount;
using FluentValidation;
using FluentValidation.TestHelper;
using Xunit;

namespace AccountingBackend.Application.Test.Accounts.Commands.UpdateAccount {

    public class UpdateAccountCommandValidatorShould : AbstractValidator<UpdateAccountCommand> {
        private UpdateAccountCommandValidator validator;

        public UpdateAccountCommandValidatorShould () {
            validator = new UpdateAccountCommandValidator ();
        }

        [Fact]
        public void HaveErrorWhenAccountIdLengthIsLessThan4Characters () {
            validator.ShouldHaveValidationErrorFor (a => a.AccountId, "000");
        }

        [Fact]
        public void NotHaveErrorWhenAccountIdLengthIsGreaterThan3Characters () {
            validator.ShouldNotHaveValidationErrorFor (a => a.AccountId, "0000");
        }

        [Fact]
        public void HaveErrorWhenIdIsNull () {
            validator.ShouldHaveValidationErrorFor (a => a.Id, 0);
        }

        [Fact]
        public void NotHaveErrorWhenIdIsNotNull () {
            validator.ShouldNotHaveValidationErrorFor (a => a.Id, 1000);
        }

        [Fact]
        public void HaveErrorWhenNameIsEmptyOrNull () {
            validator.ShouldHaveValidationErrorFor (a => a.AccountName, "");
            validator.ShouldHaveValidationErrorFor (a => a.AccountName, null as string);
        }

        [Fact]
        public void NotHaveErrorWhenNameIsNotEmptyOrNull () {
            validator.ShouldNotHaveValidationErrorFor (a => a.AccountName, "Cash");
        }
    }
}