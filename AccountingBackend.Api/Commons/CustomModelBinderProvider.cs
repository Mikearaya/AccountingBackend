using AccountingBackend.Commons.QueryHelpers;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AccountingBackend.Api.Commons {
    public class CustomModelBinderProvider : IModelBinderProvider {
        public IModelBinder GetBinder (ModelBinderProviderContext context) {
            if (context.Metadata.ModelType == typeof (Filter))
                return new CustomModelBinder ();

            return null;
        }
    }
}