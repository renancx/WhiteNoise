using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WhiteNoise.Shared.TagHelpers
{
    public class EmailTagHelper : TagHelper
    {
        public string Dominio { get; set; } = "gmail.com";

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            var prefixo = await output.GetChildContentAsync();
            var email = prefixo.GetContent() + "@" + Dominio;
            output.Attributes.SetAttribute("href", "mailto:" + email);
            output.Content.SetContent(email);
        }
    }
}
