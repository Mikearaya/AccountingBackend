/*
 * @CreateTime: Apr 24, 2019 5:53 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 24, 2019 6:13 PM
 * @Description: Modify Here, Please 
 */
using System;
using AccountingBackend.Application.Accounts.Models;
using MediatR;

namespace AccountingBackend.Application.Accounts.Queries.GetAccount {
    public class GetAccountQuery : IRequest<AccountViewModel> {
        public string AccountId { get; set; }
    }
}