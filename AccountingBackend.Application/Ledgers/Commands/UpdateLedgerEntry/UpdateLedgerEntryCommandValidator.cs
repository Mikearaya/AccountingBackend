/*
 * @CreateTime: May 8, 2019 2:44 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 8, 2019 2:50 PM
 * @Description: Modify Here, Please 
 */
using AccountingBackend.Application.Ledgers.Models;
using FluentValidation;

namespace AccountingBackend.Application.Ledgers.Commands.UpdateLedgerEntry {
    public class UpdateLedgerEntryCommandValidator : AbstractValidator<UpdateLedgerEntryCommand> {
        public UpdateLedgerEntryCommandValidator () {
            RuleFor (x => x.Description).NotNull ().NotEmpty ();
            RuleFor (x => x.VoucherId).NotNull ().NotEmpty ();
            RuleFor (x => x.Date).NotNull ().NotEmpty ();
            RuleFor (x => x.Id).NotNull ().NotEmpty ();
            RuleFor (x => x.Entries).NotNull ().NotEmpty ();
            RuleForEach (x => x.Entries).SetValidator (new LedgerEntryValidator ());
        }

        public class LedgerEntryValidator : AbstractValidator<UpdatedLedgerEntryModel> {
            public LedgerEntryValidator () {
                RuleFor (x => x.Credit).NotNull ().NotEmpty ().When (d => d.Debit == 0)
                    .WithMessage ("Credit can not be 0 when debit is also 0");
                RuleFor (x => x.Debit).NotNull ().NotEmpty ().When (d => d.Credit == 0)
                    .WithMessage ("debit can not be 0 when credit is also 0");
                RuleFor (x => x.AccountId).NotNull ().NotEmpty ();
            }

        }
    }
}