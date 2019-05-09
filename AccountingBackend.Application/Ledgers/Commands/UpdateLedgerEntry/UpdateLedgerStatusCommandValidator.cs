/*
 * @CreateTime: May 8, 2019 5:51 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 10, 2019 12:09 AM
 * @Description: Modify Here, Please 
 */
using FluentValidation;

namespace AccountingBackend.Application.Ledgers.Commands.UpdateLedgerEntry {
    public class UpdateLedgerStatusCommandValidator : AbstractValidator<UpdateLedgerStatusCommand> {

        public UpdateLedgerStatusCommandValidator () {
            RuleFor (x => x.Id).NotNull ().NotEmpty ();
            RuleFor (x => x.Posted).NotNull ().NotEmpty ();
        }
    }
}