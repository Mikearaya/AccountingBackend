/*
 * @CreateTime: May 14, 2019 11:11 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 14, 2019 11:11 AM
 * @Description: Modify Here, Please 
 */
using AccountingBackend.Application.AccountTypes.Models;
using MediatR;

namespace AccountingBackend.Application.AccountTypes.Queries.GetAccountType {
    public class GetAccountTypeQuery : IRequest<AccountTypeView> {
        public uint Id { get; set; }

    }
}