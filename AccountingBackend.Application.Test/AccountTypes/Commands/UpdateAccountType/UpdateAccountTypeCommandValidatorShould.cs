/*
 * @CreateTime: May 14, 2019 3:18 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 14, 2019 3:19 PM
 * @Description: Modify Here, Please 
 */
using AccountingBackend.Application.AccountTypes.Commands.UpdateAccountType;
using FluentValidation.TestHelper;
using Xunit;

namespace AccountingBackend.Application.Test.AccountTypes.Commands.UpdateAccountType {
    public class UpdateAccountTypeCommandValidatorShould {
        UpdateAccountTypeCommandValidator validator;

        public UpdateAccountTypeCommandValidatorShould () {
            validator = new UpdateAccountTypeCommandValidator ();
        }

        [Fact]
        public void HaveErrorWhenIdIsNull () {
            validator.ShouldHaveValidationErrorFor (x => x.Id, 0u);
        }

        [Fact]
        public void NotHaveErrorWhenIdIsNotNull () {
            validator.ShouldNotHaveValidationErrorFor (x => x.Id, 100u);
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
        public void HaveErrorWhenTypeOfIsNull () {
            validator.ShouldHaveValidationErrorFor (x => x.IsTypeOf, 0u);
        }

        [Fact]
        public void NotHaveErrorWhenTypeOfIsNotNull () {
            validator.ShouldNotHaveValidationErrorFor (x => x.IsTypeOf, 100u);
        }

    }
}