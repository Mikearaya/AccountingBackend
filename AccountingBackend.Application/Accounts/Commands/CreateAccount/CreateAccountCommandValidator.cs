/*
 * @CreateTime: Apr 24, 2019 6:48 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 3, 2019 2:58 PM
 * @Description: Modify Here, Please 
 */
using FluentValidation;

namespace AccountingBackend.Application.Accounts.Commands.CreateAccount {
    public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand> {
        public CreateAccountCommandValidator () {
            RuleFor (x => x.AccountId).MinimumLength (4).NotEmpty ().NotNull ();
            RuleFor (x => x.Active).NotNull ().NotNull ();
            RuleFor (x => x.Name).NotNull ().NotEmpty ();

            RuleFor (x => x.CatagoryId).NotEmpty ().NotNull ();
        }
    }
}