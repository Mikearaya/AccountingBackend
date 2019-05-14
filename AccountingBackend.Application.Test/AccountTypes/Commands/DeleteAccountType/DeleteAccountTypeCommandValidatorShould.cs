/*
 * @CreateTime: May 14, 2019 3:21 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 14, 2019 3:22 PM
 * @Description: Modify Here, Please 
 */
using AccountingBackend.Application.AccountTypes.Commands.DeleteAccountType;
using FluentValidation.TestHelper;
using Xunit;

namespace AccountingBackend.Application.Test.AccountTypes.Commands.DeleteAccountType {
    public class DeleteAccountTypeCommandValidatorShould {

        private DeleteAccountTypeCommandValidator validator;
        public DeleteAccountTypeCommandValidatorShould () {
            validator = new DeleteAccountTypeCommandValidator ();
        }

        [Fact]
        public void HaveErrorWhenIdIsNull () {
            validator.ShouldHaveValidationErrorFor (x => x.Id, 0u);
        }

        [Fact]
        public void NotHaveErrorWhenIdIsNotNull () {
            validator.ShouldNotHaveValidationErrorFor (x => x.Id, 100u);
        }
    }
}