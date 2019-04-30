/*
 * @CreateTime: Apr 30, 2019 8:35 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 30, 2019 1:18 PM
 * @Description: Modify Here, Please 
 */
using FluentValidation;

namespace AccountingBackend.Application.AccountCategories.Commands.CreateAccountCategory {
    public class CreateAccountCategoryValidator : AbstractValidator<CreateAccountCategoryCommand> {
        public CreateAccountCategoryValidator () {

            RuleFor (c => c.CategoryName).NotEmpty ().NotNull ();
            RuleFor (c => c.AccountType).IsInEnum ().NotEmpty ().NotNull ();
        }
    }
}