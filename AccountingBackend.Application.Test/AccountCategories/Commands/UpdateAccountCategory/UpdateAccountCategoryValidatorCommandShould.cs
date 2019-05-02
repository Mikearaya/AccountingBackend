/*
 * @CreateTime: May 2, 2019 2:02 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 2, 2019 2:16 PM
 * @Description: Modify Here, Please 
 */
using AccountingBackend.Application.AccountCategories.Commands.UpdateAccountCategory;
using FluentValidation.TestHelper;
using Xunit;

namespace AccountingBackend.Application.Test.AccountCategories.Commands.UpdateAccountCategory {
    public class UpdateAccountCategoryCommandValidatorShould {

        private UpdateAccountCategoryCommandValidator validator;
        public UpdateAccountCategoryCommandValidatorShould () {
            validator = new UpdateAccountCategoryCommandValidator ();
        }

        [Fact]
        public void HaveErrorWhenIdIsNullOrZero () {
            validator.ShouldHaveValidationErrorFor (category => category.Id, 0);
        }

        [Fact]
        public void NotHaveErrorWhenIdIsNotNullOrZero () {
            validator.ShouldNotHaveValidationErrorFor (category => category.Id, 1);
        }

        [Fact]
        public void HaveErrorWhenCategoryNameIsNullOrEmpty () {
            validator.ShouldHaveValidationErrorFor (category => category.CategoryName, null as string);
            validator.ShouldHaveValidationErrorFor (category => category.CategoryName, ""
                as string);
        }

        [Fact]
        public void NotHaveErrorWhenCategoryNameIsNotNll () {
            validator.ShouldNotHaveValidationErrorFor (category => category.CategoryName, "Cash");
        }

        [Fact]
        public void HaveErrorWhenAccountTypeIsNullOrEmpty () {
            validator.ShouldHaveValidationErrorFor (category => category.AccountType, null as string);
            validator.ShouldHaveValidationErrorFor (category => category.AccountType, ""
                as string);
        }

        [Fact]
        public void NotHaveErrorWhenAccountTypeIsNotNll () {
            validator.ShouldNotHaveValidationErrorFor (category => category.AccountType, "Cash");
        }
    }
}