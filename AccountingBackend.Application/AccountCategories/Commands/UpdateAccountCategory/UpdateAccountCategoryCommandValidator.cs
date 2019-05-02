/*
 * @CreateTime: Apr 30, 2019 10:40 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 2, 2019 2:13 PM
 * @Description: Modify Here, Please 
 */
using AccountingBackend.Application.Interfaces;
using FluentValidation;

namespace AccountingBackend.Application.AccountCategories.Commands.UpdateAccountCategory {
    public class UpdateAccountCategoryCommandValidator : AbstractValidator<UpdateAccountCategoryCommand> {
        public UpdateAccountCategoryCommandValidator () {

            RuleFor (c => c.Id).NotNull ().NotEqual (0);
            RuleFor (c => c.CategoryName).NotEmpty ().NotNull ();
            RuleFor (c => c.AccountType).NotEmpty ().NotNull ();
        }
    }
}