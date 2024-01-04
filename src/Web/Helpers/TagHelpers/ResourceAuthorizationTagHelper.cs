using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Linq;
using System.Threading.Tasks;

namespace hshmedstats.Web.Helpers.TagHelpers
{
    [HtmlTargetElement(Attributes = "authorized-asp-roles")]
    public class ResourceAuthorizationTagHelper : TagHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ResourceAuthorizationTagHelper(
            IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        [HtmlAttributeName("authorized-asp-roles")]
        public string Roles { get; set; }

        [HtmlAttributeName("asp-hidden")]
        public bool IsHidden { get; set; } = false;

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            await base.ProcessAsync(context, output);

            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext != null)
            {
                if (Roles.Split(",").ToList().All(a => !httpContext.User.IsInRole(a)))
                {
                    if (!IsHidden)
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

