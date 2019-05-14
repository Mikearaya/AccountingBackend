/*
 * @CreateTime: May 14, 2019 3:00 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 14, 2019 3:07 PM
 * @Description: Modify Here, Please 
 */
using AccountingBackend.Application.AccountTypes.Commands.CreateAccountType;
using FluentValidation.TestHelper;
using Xunit;

namespace AccountingBackend.Application.Test.AccountTypes.Commands.CreateAccountType {
    public class CreateAccountTypeCommandValidatorShould {
        private CreateAccountTypeCommandValidator validator;

        public CreateAccountTypeCommandValidatorShould () {
            validator = new CreateAccountTypeCommandValidator ();
        }

        [Fact]
        public void HaveErrorWhenTypeIsNullOrEmpty () {
            validator.ShouldHaveValidationErrorFor (x => x.Type, null as string);
            validator.ShouldHaveValidationErrorFor (x => x.Type, "");
        }

        [Fact]
        public void NotHaveErrorWhenTypeIsNotNullOrEmpty () {
            validator.ShouldNotHaveValidationErrorFor (x => x.Type, "Account Recievable");
        }

        [Fact]
        public void NotHaveErrorWhenTypeOfIsNull () {
            validator.ShouldNotHaveValidationErrorFor (x => x.IsTypeOf, null);
        }

        [Fact]
        public void NotHaveErrorWhenTypeOfIsNotNull () {
            validator.ShouldNotHaveValidationErrorFor (x => x.IsTypeOf, 100u);
        }
    }
}