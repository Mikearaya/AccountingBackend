/*
 * @CreateTime: May 28, 2019 1:30 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 28, 2019 1:44 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Threading.Tasks;
using AccountingBackend.Commons.QueryHelpers;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AccountingBackend.Api.Commons {
    public class CustomModelBinder : IModelBinder {
        public Task BindModelAsync (ModelBindingContext bindingContext) {
            if (bindingContext == null)
                throw new ArgumentNullException (nameof (bindingContext));

            var values = bindingContext.ValueProvider.GetValue ("Value");
            if (values.Length == 0)
                return Task.CompletedTask;

            var splitData = values.FirstValue.Split (new char[] { ',' });
            if (splitData.Length >= 2) {
                var result = new Filter {
                PropertyName = "AccountName",
                Value = "AAAA",
                Operation = Op.Equals
                };
                bindingContext.Result = ModelBindingResult.Success (result);
            }

            return Task.CompletedTask;
        }
    }
}