/*
 * @CreateTime: May 7, 2019 10:04 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 7, 2019 10:10 AM
 * @Description: Modify Here, Please 
 */
using FluentValidation;

namespace AccountingBackend.Application.SystemLookups.Commands.CreateSystemLookup {
    public class CreateSystemLookupCommandValidator : AbstractValidator<CreateSystemLookupCommand> {
        public CreateSystemLookupCommandValidator () {
            RuleForEach (x => x.Lookups).NotNull ();
        }
    }
}