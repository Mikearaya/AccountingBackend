/*
 * @CreateTime: May 2, 2019 7:09 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 2, 2019 7:09 PM
 * @Description: Modify Here, Please 
 */
using FluentValidation;

namespace AccountingBackend.Application.Accounts.Commands.DeleteAccount {
    public class DeleteAccountCommandValidator : AbstractValidator<DeleteAccountCommand> {
        public DeleteAccountCommandValidator () {
            RuleFor (x => x.Id).NotEmpty ().NotNull ();
        }
    }
}