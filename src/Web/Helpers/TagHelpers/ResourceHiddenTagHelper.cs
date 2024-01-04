using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Linq;
using System.Threading.Tasks;

namespace hshmedstats.Web.Helpers.TagHelpers
{
    [HtmlTargetElement(Attributes = "hidden-asp-roles")]
    public class ResourceHiddenTagHelper : TagHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ResourceHiddenTagHelper(
            IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        [HtmlAttributeName("hidden-asp-roles")]
        public string Roles { get; set; }
        [HtmlAttributeName("hidden-condition")]
        public bool Condition { get; set; } = true;


        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            await base.ProcessAsync(context, output);

            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext != null)
            {
                if (Roles.Split(",").ToList().Any(a => httpContext.User.IsInRole(a)) && Condition)
                {
                    output.Attributes.Add(new TagHelperAttribute("hidden", "hidden"));
                }
            }

        }
    }
}

