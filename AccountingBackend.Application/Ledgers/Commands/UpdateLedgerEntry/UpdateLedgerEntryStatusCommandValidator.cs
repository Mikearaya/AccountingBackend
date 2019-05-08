/*
 * @CreateTime: May 8, 2019 5:51 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 8, 2019 5:52 PM
 * @Description: Modify Here, Please 
 */
using FluentValidation;

namespace AccountingBackend.Application.Ledgers.Commands.UpdateLedgerEntry {
    public class UpdateLedgerEntryStatusCommandValidator : AbstractValidator<UpdateLedgerStatusCommand> {

        public UpdateLedgerEntryStatusCommandValidator () {
            RuleFor (x => x.Id).NotNull ().NotEmpty ();
            RuleFor (x => x.Posted).NotNull ().NotEmpty ();
        }
    }
}