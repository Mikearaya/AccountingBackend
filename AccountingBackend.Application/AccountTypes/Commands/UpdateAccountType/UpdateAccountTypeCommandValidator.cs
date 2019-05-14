/*
 * @CreateTime: May 14, 2019 10:49 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 14, 2019 10:49 AM
 * @Description: Modify Here, Please 
 */
using FluentValidation;

namespace AccountingBackend.Application.AccountTypes.Commands.UpdateAccountType {
    public class UpdateAccountTypeCommandValidator : AbstractValidator<UpdateAccountTypeCommand> {
        public UpdateAccountTypeCommandValidator () {
            RuleFor (x => x.Id).NotEmpty ().NotNull ();
            RuleFor (x => x.IsTypeOf).NotEmpty ().NotNull ();
            RuleFor (x => x.Type).NotEmpty ().NotNull ();
        }
    }
}