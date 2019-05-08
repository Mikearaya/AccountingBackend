/*
 * @CreateTime: May 7, 2019 10:36 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 8, 2019 4:20 AM
 * @Description: Modify Here, Please 
 */
using FluentValidation;

namespace AccountingBackend.Application.SystemLookups.Commands.DeleteSystemLookup {
    public class DeleteSystemLookupCommandValidator : AbstractValidator<DeleteSystemLookupCommand> {
        public DeleteSystemLookupCommandValidator () {
            RuleFor (x => x.Id).NotEmpty ().NotNull ();
        }
    }
}