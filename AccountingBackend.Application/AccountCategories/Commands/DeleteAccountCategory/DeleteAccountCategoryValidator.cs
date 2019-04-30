/*
 * @CreateTime: Apr 30, 2019 1:35 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 30, 2019 1:36 PM
 * @Description: Modify Here, Please 
 */
using FluentValidation;

namespace AccountingBackend.Application.AccountCategories.Commands.DeleteAccountCategory {
    public class DeleteAccountCategoryValidator : AbstractValidator<DeleteAccountCategoryCommand> {
        public DeleteAccountCategoryValidator () {
            RuleFor (c => c.Id).NotEmpty ().NotNull ();
        }
    }
}