/*
 * @CreateTime: Apr 30, 2019 8:35 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 2, 2019 2:14 PM
 * @Description: Modify Here, Please 
 */
using FluentValidation;

namespace AccountingBackend.Application.AccountCategories.Commands.CreateAccountCategory {
    public class CreateAccountCategoryCommandValidator : AbstractValidator<CreateAccountCategoryCommand> {
        public CreateAccountCategoryCommandValidator () {

            RuleFor (c => c.CategoryName).NotEmpty ().NotNull ();
            RuleFor (c => c.AccountType).NotEmpty ().NotNull ();
        }
    }
}