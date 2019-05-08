/*
 * @CreateTime: May 8, 2019 8:40 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 8, 2019 9:01 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using AccountingBackend.Application.Ledgers.Models;
using FluentValidation;

namespace AccountingBackend.Application.Ledgers.Commands.CreateLedgerEntry {
    public class CreateLedgerEntryCommandValidator : AbstractValidator<CreateLedgerEntryCommand> {
        public CreateLedgerEntryCommandValidator () {
            RuleFor (x => x.Description).NotEmpty ().NotNull ();
            RuleFor (x => x.VoucherId).NotEmpty ().NotNull ();
            RuleFor (x => x.Date).NotEmpty ().NotNull ();
            RuleForEach (x => x.Entries).SetValidator (new LedgerEntryValidator ());
        }

    }

    public class LedgerEntryValidator : AbstractValidator<NewLedgerEntryModel> {
        public LedgerEntryValidator () {
            RuleFor (x => x.Credit).NotNull ().NotEmpty ().When (d => d.Debit == 0)
                .WithMessage ("Credit can not be 0 when debit is also 0");
            RuleFor (x => x.Debit).NotNull ().NotEmpty ().When (d => d.Credit == 0)
                .WithMessage ("debit can not be 0 when credit is also 0");
            RuleFor (x => x.AccountId).NotNull ().NotEmpty ();
        }

    }
}