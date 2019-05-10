/*
 * @CreateTime: May 10, 2019 4:35 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 10, 2019 4:38 PM
 * @Description: Modify Here, Please 
 */
using AccountingBackend.Application.Accounts.Queries.GetAccount;
using FluentValidation.TestHelper;
using Xunit;

namespace AccountingBackend.Application.Test.Accounts.Queries.GetAccount {
    public class GetAccountQueryValidatorShould {
        private GetAccountQueryValidator validator;

        public GetAccountQueryValidatorShould () {
            validator = new GetAccountQueryValidator ();
        }

        [Fact]
        public void HaveErrorWhenIdIsNull () {
            validator.ShouldHaveValidationErrorFor (c => c.Id, 0);
        }

        [Fact]
        public void NotHaveErrorWhenIdIsNotNull () {
            validator.ShouldNotHaveValidationErrorFor (x => x.Id, 100);
        }
    }
}