/*
 * @CreateTime: Apr 30, 2019 1:35 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 2, 2019 2:13 PM
 * @Description: Modify Here, Please 
 */
using FluentValidation;

namespace AccountingBackend.Application.AccountCategories.Commands.DeleteAccountCategory {
    public class DeleteAccountCategoryCommandValidator : AbstractValidator<DeleteAccountCategoryCommand> {
        public DeleteAccountCategoryCommandValidator () {
            RuleFor (c => c.Id).NotEmpty ().NotNull ();
        }
    }
}