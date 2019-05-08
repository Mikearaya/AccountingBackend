/*
 * @CreateTime: May 7, 2019 5:40 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 7, 2019 5:44 PM
 * @Description: Modify Here, Please 
 */
using AccountingBackend.Application.SystemLookups.Commands.CreateSystemLookup;
using FluentValidation;
using FluentValidation.TestHelper;
using Xunit;

namespace AccountingBackend.Application.Test.SystemLookups.Commands.CreateSysystemLookup {
    public class CreateSystemLookupCommandValidatorShould : AbstractValidator<CreateSystemLookupCommand> {
        private CreateSystemLookupCommandValidator validator;
        public CreateSystemLookupCommandValidatorShould () {
            validator = new CreateSystemLookupCommandValidator ();
        }

    }
}