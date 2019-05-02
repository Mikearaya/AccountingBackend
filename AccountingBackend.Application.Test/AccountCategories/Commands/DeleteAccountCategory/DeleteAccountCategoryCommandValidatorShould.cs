/*
 * @CreateTime: May 2, 2019 2:14 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 2, 2019 2:16 PM
 * @Description: Modify Here, Please 
 */
using AccountingBackend.Application.AccountCategories.Commands.DeleteAccountCategory;
using FluentValidation.TestHelper;
using Xunit;

namespace AccountingBackend.Application.Test.AccountCategories.Commands.DeleteAccountCategory {
    public class DeleteAccountCategoryCommandValidatorShould {

        private DeleteAccountCategoryCommandValidator validator;
        public DeleteAccountCategoryCommandValidatorShould () {
            validator = new DeleteAccountCategoryCommandValidator ();
        }

        [Fact]
        public void HaveErrorWhenIdIsNullOrZero () {
            validator.ShouldHaveValidationErrorFor (category => category.Id, 0);
        }

        [Fact]
        public void NotHaveErrorWhenIdIsNotNullOrZero () {
            validator.ShouldNotHaveValidationErrorFor (category => category.Id, 2);
        }
    }
}