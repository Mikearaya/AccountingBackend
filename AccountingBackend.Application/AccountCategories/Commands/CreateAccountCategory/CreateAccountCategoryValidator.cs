/*
 * @CreateTime: Apr 30, 2019 8:35 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 1, 2019 1:47 PM
 * @Description: Modify Here, Please 
 */
using FluentValidation;

namespace AccountingBackend.Application.AccountCategories.Commands.CreateAccountCategory {
    public class CreateAccountCategoryValidator : AbstractValidator<CreateAccountCategoryCommand> {
        public CreateAccountCategoryValidator () {

            RuleFor (c => c.CategoryName).NotEmpty ().NotNull ();
            RuleFor (c => c.AccountType).NotEmpty ().NotNull ();
        }
    }
}