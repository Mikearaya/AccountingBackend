/*
 * @CreateTime: Jun 5, 2019 9:31 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 5, 2019 2:18 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq;
using System.Linq.Expressions;
using AccountingBackend.Domain;

namespace AccountingBackend.Application.Reports.Models {
    public class CostOfGoodsSoldItemsModel {

        public string AccountName { get; set; }
        public float? Value { get; set; }

        public static Expression<Func<AccountCatagory, CostOfGoodsSoldItemsModel>> Projection {
            get {
                return category => new CostOfGoodsSoldItemsModel () {
                    AccountName = category.Catagory,
                    Value = category.Account.Sum (a => a.LedgerEntry.Sum (e => (float?) e.Credit)) - category.Account.Sum (a => a.LedgerEntry.Sum (e => (float?) e.Debit))
                };
            }
        }
    }
}