/*
 * @CreateTime: May 7, 2019 10:27 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 7, 2019 10:28 AM
 * @Description: Modify Here, Please 
 */
using FluentValidation;

namespace AccountingBackend.Application.SystemLookups.Commands.UpdateSystemLookup {
    public class UpdateSystemLookupCommandValidator : AbstractValidator<UpdateSystemLookupCommand> {
        public UpdateSystemLookupCommandValidator () {
            RuleFor (x => x.Lookups).NotNull ();
        }
    }
}