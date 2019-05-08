/*
 * @CreateTime: May 8, 2019 4:15 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 8, 2019 4:21 AM
 * @Description: Modify Here, Please 
 */
using AccountingBackend.Application.SystemLookups.Commands.DeleteSystemLookup;
using FluentValidation.TestHelper;
using Xunit;

namespace AccountingBackend.Application.Test.SystemLookups.Commands.DeleteSystemLookup {
    public class DeleteSystemLookupCommandValidatorShould {
        private DeleteSystemLookupCommandValidator validator;
        public DeleteSystemLookupCommandValidatorShould () {
            validator = new DeleteSystemLookupCommandValidator ();

        }

        [Fact]
        public void ThrowsErrorIfIdIsNotSet () {
            validator.ShouldHaveValidationErrorFor (x => x.Id, 0);
        }

        [Fact]
        public void NotHaveErrorIfIdIsSet () {
            validator.ShouldNotHaveValidationErrorFor (x => x.Id, 2);
        }
    }
}