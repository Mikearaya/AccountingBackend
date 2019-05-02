/*
 * @CreateTime: May 2, 2019 1:51 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 2, 2019 2:16 PM
 * @Description: Modify Here, Please 
 */
using AccountingBackend.Application.AccountCategories.Commands.CreateAccountCategory;
using FluentValidation.TestHelper;
using Xunit;

namespace AccountingBackend.Application.Test.AccountCategories.Commands.CreateAccountCategory {
    public class CreateAccountCategoryCommandValidatorShould {

        private CreateAccountCategoryCommandValidator validator;
        public CreateAccountCategoryCommandValidatorShould () {
            validator = new CreateAccountCategoryCommandValidator ();

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