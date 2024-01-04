using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace hshmedstats.Web.Binders
{
    public class CountryBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var propertyName = bindingContext.ModelName;
            var propertyValueResult = bindingContext.ValueProvider.GetValue(propertyName);

            if (propertyValueResult != ValueProviderResult.None && !string.IsNullOrEmpty(propertyValueResult.FirstValue))
            {
                var country = propertyValueResult.FirstValue.Contains("(") ? propertyValueResult.FirstValue.Substring(0, propertyValueResult.FirstValue.IndexOf('(') - 1) : propertyValueResult.FirstValue;
                bindingContext.ModelState.SetModelValue(propertyName, new ValueProviderResult(country));
                bindingContext.Result = ModelBindingResult.Success(country);
            }

            return Task.CompletedTask;
        }
    }
}
