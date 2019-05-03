/*
 * @CreateTime: May 3, 2019 10:27 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 3, 2019 10:31 AM
 * @Description: Modify Here, Please 
 */
using AccountingBackend.Application.Accounts.Commands.DeleteAccount;
using FluentValidation;
using FluentValidation.TestHelper;
using Xunit;

namespace AccountingBackend.Application.Test.Accounts.Commands.DeleteAccount {
    public class DeleteAccountComandValidatorShould : AbstractValidator<DeleteAccountCommand> {

        private DeleteAccountCommandValidator validator;
        public DeleteAccountComandValidatorShould () {
            validator = new DeleteAccountCommandValidator ();
        }

        [Fact]
        public void HaveErrorIfIdIsNull () {
            validator.ShouldHaveValidationErrorFor (x => x.Id, 0);
        }

        [Fact]
        public void NotHaveErrorIfIdIsNotNull () {
            validator.ShouldNotHaveValidationErrorFor (x => x.Id, 1000);
        }

    }
}