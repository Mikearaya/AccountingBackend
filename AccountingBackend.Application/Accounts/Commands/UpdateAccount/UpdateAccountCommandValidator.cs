/*
 * @CreateTime: May 2, 2019 7:02 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 2, 2019 7:02 PM
 * @Description: Modify Here, Please 
 */
using FluentValidation;

namespace AccountingBackend.Application.Accounts.Commands.UpdateAccount {
    public class UpdateAccountCommandValidator : AbstractValidator<UpdateAccountCommand> {
        public UpdateAccountCommandValidator () {

            RuleFor (x => x.Id).NotEmpty ().NotNull ();
            RuleFor (x => x.Name).NotEmpty ().NotNull ();
            RuleFor (x => x.AccountId).MinimumLength (4).NotEmpty ().NotNull ();

        }
    }
}