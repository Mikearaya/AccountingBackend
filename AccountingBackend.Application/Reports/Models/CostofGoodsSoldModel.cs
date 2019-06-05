using System.Linq;
/*
 * @CreateTime: Jun 5, 2019 9:31 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 5, 2019 2:18 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AccountingBackend.Domain;

namespace AccountingBackend.Application.Reports.Models {
    public class CostofGoodsSoldModel {
        public IEnumerable<CostOfGoodsSoldItemsModel> Accounts { get; set; } = new List<CostOfGoodsSoldItemsModel> ();
        public float? TotalProductionCost {
            get {
                return Accounts.Sum (a => a.Value);
            }
        }
        public float? TotalProductionCostForAccount { get; set; }

        public float? WorkInProcessBegining { get; set; }
        public float? WorkInProcessEnding { get; set; }
        public float? FinishedGoodsBeginning { get; set; }
        public float CostOfAvailableGoods { get; set; }

        public static Expression<Func<AccountType, CostofGoodsSoldModel>> Projection {
            get {
                return accountType => new CostofGoodsSoldModel () {
                    Accounts = accountType.AccountCatagory
                    .AsQueryable ()
                    .Select (CostOfGoodsSoldItemsModel.Projection)
                };

            }
        }
    }

}