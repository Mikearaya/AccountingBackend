/*
 * @CreateTime: Apr 30, 2019 2:00 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 30, 2019 2:00 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using AccountingBackend.Application.AccountCategories.Models;
using MediatR;

namespace AccountingBackend.Application.AccountCategories.Queries.GetAccountCategoryList {
    public class GetAccountCategoryListQuery : IRequest<IEnumerable<AccountCategoryView>> {

    }
}