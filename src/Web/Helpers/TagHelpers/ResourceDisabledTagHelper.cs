using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Linq;
using System.Threading.Tasks;

namespace hshmedstats.Web.Helpers.TagHelpers
{
    [HtmlTargetElement(Attributes = "disabled-asp-roles,disabled-condition")]
    public class ResourceDisabledTagHelper : TagHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ResourceDisabledTagHelper(
            IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        [HtmlAttributeName("disabled-asp-roles")]
        public string Roles { get; set; }
        [HtmlAttributeName("disabled-condition")]
        public bool Condition { get; set; }
        [HtmlAttributeName("disabled-asp-message")]
        public string Message { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            await base.ProcessAsync(context, output);

            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext != null)
            {
                if (Roles.Split(",").ToList().Any(a => httpContext.User.IsInRole(a)) && Condition)
                {
                    if (output.TagName == "button")
                    {
                        if (!string.IsNullOrEmpty(Message))
                        {
                            output.PreElement.AppendHtml($"<span class=\"d-inline-block\" data-toggle=\"tooltip\" data-placement=\"bottom\" title=\"{Message}\">");
                            output.PostElement.AppendHtml("</span>");
                            output.Attributes.Add("style", "pointer-events:none;");
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(Message))
                        {
                            output.Attributes.Add(new TagHelperAttribute("data-toggle", "tooltip"));
                            output.Attributes.Add(new TagHelperAttribute("data-placement", "bottom"));
                            output.Attributes.Add(new TagHelperAttribute("title", Message));

                        }
                    }

                    output.Attributes.Add(new TagHelperAttribute("disabled", "disabled"));
                }
            }

        }
    }
}

