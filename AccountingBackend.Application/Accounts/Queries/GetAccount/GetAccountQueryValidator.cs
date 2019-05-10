/*
 * @CreateTime: May 3, 2019 11:01 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 10, 2019 4:39 PM
 * @Description: Modify Here, Please 
 */
using FluentValidation;

namespace AccountingBackend.Application.Accounts.Queries.GetAccount {
    public class GetAccountQueryValidator : AbstractValidator<GetAccountQuery> {
        public GetAccountQueryValidator () {
            RuleFor (x => x.Id).NotEmpty ().NotNull ();
        }
    }
}