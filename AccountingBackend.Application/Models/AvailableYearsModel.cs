/*
 * @CreateTime: May 22, 2019 4:54 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 22, 2019 5:02 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq.Expressions;
using AccountingBackend.Domain;

namespace AccountingBackend.Application.Models {
    public class AvailableYearsModel {
        public string Year { get; set; }

        public static Expression<Func<Account, AvailableYearsModel>> Projection {
            get {
                return account => new AvailableYearsModel () { Year = account.Year };
            }
        }
    }
}