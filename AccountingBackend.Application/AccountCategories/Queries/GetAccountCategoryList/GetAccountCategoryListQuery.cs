/*
 * @CreateTime: Apr 30, 2019 2:00 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 4, 2019 7:58 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using AccountingBackend.Application.AccountCategories.Models;
using AccountingBackend.Application.Models;
using AccountingBackend.Commons.QueryHelpers;
using MediatR;

namespace AccountingBackend.Application.AccountCategories.Queries.GetAccountCategoryList {
    public class GetAccountCategoryListQuery : ApiQueryString, IRequest<FilterResultModel<AccountCategoryView>> {

    }
}