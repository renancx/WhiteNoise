using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WhiteNoise.Shared.TagHelpers
{
    [HtmlTargetElement("list-selector", Attributes = "for,items")]
    public class ListSelectorTagHelper : TagHelper
    {
        private readonly IHtmlGenerator _htmlGenerator;
        private readonly IUrlHelperFactory _urlHelperFactory;

        public ListSelectorTagHelper(
            IHtmlGenerator htmlGenerator,
            IUrlHelperFactory urlHelperFactory)
        {
            _htmlGenerator = htmlGenerator;
            _urlHelperFactory = urlHelperFactory;
        }

        [HtmlAttributeName("for")]
        public string For { get; set; }

        [HtmlAttributeName("items")]
        public IEnumerable<object> Items { get; set; }

        [HtmlAttributeName("quick-create")]
        public string? QuickCreate { get; set; }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.SetAttribute("class", "form-group col-6");

            var modelExplorer = ViewContext.ViewData.ModelExplorer.GetExplorerForProperty(For);
            var labelTag = _htmlGenerator.GenerateLabel(
                ViewContext,
                modelExplorer,
                For,
                labelText: null,
                htmlAttributes: new { @class = "" }
            );

            var listaDeSelectListItems = Items.OfType<SelectListItem>().ToList();
            var selectTag = _htmlGenerator.GenerateSelect(
                ViewContext,
                modelExplorer,
                optionLabel: "Selecione...",
                expression: For,
                selectList: listaDeSelectListItems,
                allowMultiple: false,
                htmlAttributes: new { @class = "form-control" }
            );

            TagBuilder? anchorTag = null;
            if (!string.IsNullOrWhiteSpace(QuickCreate))
            {
                var urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);
                var createUrl = urlHelper.Action("Create", QuickCreate);

                anchorTag = new TagBuilder("a");
                anchorTag.Attributes["href"] = createUrl ?? "#";
                anchorTag.AddCssClass("btn btn-link ms-2 text-secondary border");
                anchorTag.Attributes["target"] = "_blank";

                var iTag = new TagBuilder("i");
                iTag.AddCssClass("bi bi-box-arrow-up-right me-2");
                anchorTag.InnerHtml.AppendHtml(iTag);
            }

            var selectWrapper = new TagBuilder("div");
            selectWrapper.AddCssClass("d-flex");
            selectWrapper.InnerHtml.AppendHtml(selectTag);

            if (anchorTag != null)
            {
                selectWrapper.InnerHtml.AppendHtml(anchorTag);
            }

            var validationTag = _htmlGenerator.GenerateValidationMessage(
                ViewContext,
                modelExplorer,
                For,
                message: null,
                tag: null,
                htmlAttributes: new { @class = "text-danger mt-1" }
            );

            output.Content.AppendHtml(labelTag);
            output.Content.AppendHtml(selectWrapper);
            output.Content.AppendHtml(validationTag);
        }
    }
}
