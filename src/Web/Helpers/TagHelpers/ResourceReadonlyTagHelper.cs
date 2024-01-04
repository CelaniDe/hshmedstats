using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Linq;
using System.Threading.Tasks;

namespace hshmedstats.Web.Helpers.TagHelpers
{
    [HtmlTargetElement(Attributes = "readonly-asp-roles,readonly-condition")]
    public class ResourceReadonlyTagHelper : TagHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ResourceReadonlyTagHelper(
            IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        [HtmlAttributeName("readonly-asp-roles")]
        public string Roles { get; set; }
        [HtmlAttributeName("readonly-condition")]
        public bool Condition { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            await base.ProcessAsync(context, output);

            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext != null)
            {
                if (Roles.Split(",").ToList().Any(a => httpContext.User.IsInRole(a)) && Condition)
                {
                    output.Attributes.Add(new TagHelperAttribute("readonly", "readonly"));
                }
            }

        }
    }
}

