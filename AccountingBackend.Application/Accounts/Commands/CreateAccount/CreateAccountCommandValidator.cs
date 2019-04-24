/*
 * @CreateTime: Apr 24, 2019 6:48 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 24, 2019 6:51 PM
 * @Description: Modify Here, Please 
 */
using FluentValidation;

namespace AccountingBackend.Application.Accounts.Commands.CreateAccount {
    public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand> {
        public CreateAccountCommandValidator () {
            RuleFor (x => x.AccountId).Length (4).NotEmpty ();
            RuleFor (x => x.AccountType).NotEmpty ();
            RuleFor (x => x.GlType).MaximumLength (15);
            RuleFor (x => x.Active).NotNull ();
            RuleFor (x => x.IsPosting).NotNull ();
            RuleFor (x => x.Name).NotNull ().NotEmpty ();
            RuleFor (x => x.OrganizationId).NotNull ().NotEmpty ();
        }
    }
}