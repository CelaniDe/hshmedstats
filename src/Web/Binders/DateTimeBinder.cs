using hshmedstats.Application.Helpers;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace hshmedstats.Web.Binders
{
    public class DateTimeBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var modelName = bindingContext.ModelName;
            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

            if (valueProviderResult != ValueProviderResult.None && !string.IsNullOrEmpty(valueProviderResult.FirstValue))
            {
                bindingContext.ModelState.SetModelValue(bindingContext.ModelName, valueProviderResult);
                var dateTime = DateTime.ParseExact(valueProviderResult.FirstValue, Format.DATE_FORMAT, CultureInfo.InvariantCulture);
                bindingContext.Result = ModelBindingResult.Success(dateTime);
            }

            return Task.CompletedTask;
        }
    }
}
