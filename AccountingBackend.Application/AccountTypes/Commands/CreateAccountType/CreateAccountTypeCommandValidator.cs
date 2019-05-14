/*
 * @CreateTime: May 14, 2019 10:37 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 14, 2019 10:38 AM
 * @Description: Modify Here, Please 
 */
using FluentValidation;

namespace AccountingBackend.Application.AccountTypes.Commands.CreateAccountType {
    public class CreateAccountTypeCommandValidator : AbstractValidator<CreateAccountTypeCommand> {
        public CreateAccountTypeCommandValidator () {
            RuleFor (x => x.IsTypeOf).NotEmpty ().NotNull ();
            RuleFor (x => x.Type).NotEmpty ().NotNull ();
        }
    }
}