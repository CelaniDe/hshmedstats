using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Threading.Tasks;

namespace hshmedstats.Web.Binders
{
    public class CountryListBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var modelName = bindingContext.ModelName;
            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

            bindingContext.ModelState.SetModelValue(bindingContext.ModelName, valueProviderResult);
            if (valueProviderResult != ValueProviderResult.None && valueProviderResult.Values.Count > 0)
            {
                var countries = new List<string>();
                foreach (var country in valueProviderResult.Values)
                {
                     var result = country.Contains('(') ? country.Substring(0, country.IndexOf('(') - 1) : country;
                    countries.Add(result);
                }
                bindingContext.Result = ModelBindingResult.Success(countries);
            }

            return Task.CompletedTask;
        }
    }
}
