using Microsoft.AspNetCore.Razor.TagHelpers;

namespace hshmedstats.Web.Helpers.TagHelpers
{
    [HtmlTargetElement(Attributes = "pcs-mandatory")]
    public class MandatoryTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.PostElement.AppendHtml($@"<span style=""color: red; "">*</span>");
        }
    }
}
