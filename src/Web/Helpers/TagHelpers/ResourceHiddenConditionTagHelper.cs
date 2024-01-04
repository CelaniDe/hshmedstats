namespace hshmedstats.Web.Helpers.TagHelpers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Razor.TagHelpers;
    using System.Linq;
    using System.Threading.Tasks;

    namespace hshmedstats.Web.Helpers.TagHelpers
    {
        [HtmlTargetElement(Attributes = "hidden-asp-condition")]
        public class ResourceHiddenConditionTagHelper : TagHelper
        {
            private readonly IHttpContextAccessor _httpContextAccessor;

            public ResourceHiddenConditionTagHelper(
                IHttpContextAccessor httpContextAccessor)
            {
                _httpContextAccessor = httpContextAccessor;
            }

            [HtmlAttributeName("hidden-asp-condition")]
            public bool Condition { get; set; }

            public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
            {
                await base.ProcessAsync(context, output);

                var httpContext = _httpContextAccessor.HttpContext;
                if (httpContext != null)
                {
                        if (!Condition)
                        {
                            output.SuppressOutput();
                        }
                        else
                        {
                            output.Attributes.Add(new TagHelperAttribute("hidden", "hidden"));
                        }
                }

            }
        }
    }


}
