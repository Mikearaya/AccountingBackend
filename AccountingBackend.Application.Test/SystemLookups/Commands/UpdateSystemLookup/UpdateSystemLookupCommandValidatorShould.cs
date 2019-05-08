/*
 * @CreateTime: May 8, 2019 4:22 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 8, 2019 4:23 AM
 * @Description: Modify Here, Please 
 */
using AccountingBackend.Application.SystemLookups.Commands.UpdateSystemLookup;
using FluentValidation.TestHelper;
using Xunit;

namespace AccountingBackend.Application.Test.SystemLookups.Commands.UpdateSystemLookup {
    public class UpdateSystemLookupCommandValidatorShould {

        private UpdateSystemLookupCommandValidator validator;
        public UpdateSystemLookupCommandValidatorShould () {
            validator = new UpdateSystemLookupCommandValidator ();

        }

    }
}