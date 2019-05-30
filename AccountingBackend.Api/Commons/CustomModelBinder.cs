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
using Newtonsoft.Json;

namespace AccountingBackend.Api.Commons {
    public class CustomModelBinder : IModelBinder {
        public Task BindModelAsync (ModelBindingContext bindingContext) {
            var jsonString = bindingContext.ActionContext.HttpContext.Request.Query["query"];
            ApiQueryString result = JsonConvert.DeserializeObject<ApiQueryString> (jsonString);

            bindingContext.Result = ModelBindingResult.Success (result);
            return Task.CompletedTask;
        }
    }
}