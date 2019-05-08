/*
 * @CreateTime: May 8, 2019 2:57 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 8, 2019 2:58 PM
 * @Description: Modify Here, Please 
 */
using FluentValidation;

namespace AccountingBackend.Application.Ledgers.Commands.DeleteLedgerEntry {
    public class DeleteLedgerEntryCommandValidator : AbstractValidator<DeleteLedgerEntryCommand> {
        public DeleteLedgerEntryCommandValidator () {

            RuleFor (x => x.Id).NotNull ().NotEmpty ();
        }
    }
}