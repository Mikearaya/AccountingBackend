/*
 * @CreateTime: May 14, 2019 11:07 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 14, 2019 11:09 AM
 * @Description: Modify Here, Please 
 */
using FluentValidation;

namespace AccountingBackend.Application.AccountTypes.Commands.DeleteAccountType {
    public class DeleteAccountTypeCommandValidator : AbstractValidator<DeleteAccountTypeCommand> {

        public DeleteAccountTypeCommandValidator () {
            RuleFor (x => x.Id).NotEmpty ().NotNull ();
        }
    }
}