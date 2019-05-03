/*
 * @CreateTime: May 2, 2019 6:01 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 3, 2019 3:09 PM
 * @Description: Modify Here, Please 
 */
using AccountingBackend.Application.Accounts.Commands.CreateAccount;
using FluentValidation.TestHelper;
using Xunit;

namespace AccountingBackend.Application.Test.Accounts.Commands.CreateAccount {
    public class CreateAccountCommandValidatorShould {
        private CreateAccountCommandValidator validator;
        public CreateAccountCommandValidatorShould () {
            validator = new CreateAccountCommandValidator ();
        }

        [Fact]
        public void HaveErrorWhenIdIsNullOrEmpty () {
            validator.ShouldHaveValidationErrorFor (c => c.AccountId, null as string);
            validator.ShouldHaveValidationErrorFor (c => c.AccountId, "");
        }

        [Fact]
        public void NotHaveErrorWhenIdIsNotNullOrEmpty () {

            validator.ShouldNotHaveValidationErrorFor (c => c.AccountId, "0000");
        }

        [Fact]
        public void HaveErrorWhenOrganizationIdIsNull () {
            validator.ShouldHaveValidationErrorFor (c => c.OrganizationId, 0);
        }

        [Fact]
        public void NotHaveErrorWhenOrganizationIdIsNotNull () {
            validator.ShouldNotHaveValidationErrorFor (c => c.OrganizationId, 1);
        }

        [Fact]
        public void HaveValidationErrorWhenCatagoryIdIsNull () {
            validator.ShouldHaveValidationErrorFor (c => c.CatagoryId, 0);
        }

        [Fact]
        public void NotHaveValidationErrorWhenCatagoryIdIsNotNull () {
            validator.ShouldNotHaveValidationErrorFor (c => c.CatagoryId, 10);
        }

        [Fact]
        public void HaveErrorWhenNameIsNullOrEmpty () {
            validator.ShouldHaveValidationErrorFor (c => c.Name, null as string);
            validator.ShouldHaveValidationErrorFor (c => c.Name, "");
        }

        [Fact]
        public void NotHaveErrorWhenNameIsNotNullOrEmpty () {
            validator.ShouldNotHaveValidationErrorFor (c => c.Name, "0101");
        }

    }
}