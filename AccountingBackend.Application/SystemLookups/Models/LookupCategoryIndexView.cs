/*
 * @CreateTime: May 12, 2019 2:19 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 12, 2019 2:28 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq.Expressions;
using AccountingBackend.Domain;

namespace AccountingBackend.Application.SystemLookups.Models {
    public class SystemLookupCategoryIndexView {
        public string Id { get; set; }
        public string Name { get; set; }

        public static Expression<Func<SystemLookup, SystemLookupCategoryIndexView>> Project {
            get {
                return lookup => new SystemLookupCategoryIndexView () {
                    Id = lookup.Value,
                    Name = lookup.Value,
                };
            }
        }
    }
}