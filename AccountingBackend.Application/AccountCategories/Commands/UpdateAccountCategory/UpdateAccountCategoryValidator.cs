/*
 * @CreateTime: Apr 30, 2019 10:40 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 30, 2019 10:59 AM
 * @Description: Modify Here, Please 
 */
using AccountingBackend.Application.Interfaces;
using FluentValidation;

namespace AccountingBackend.Application.AccountCategories.Commands.UpdateAccountCategory {
    public class UpdateAccountCategoryValidator : AbstractValidator<UpdateAccountCategoryCommand> {
        public UpdateAccountCategoryValidator () {

            RuleFor (c => c.Id).NotNull ().NotEqual (0);
            RuleFor (c => c.CategoryName).NotEmpty ().NotNull ();
            RuleFor (c => c.AccountType).IsInEnum ().NotEmpty ().NotNull ();
        }
    }
}