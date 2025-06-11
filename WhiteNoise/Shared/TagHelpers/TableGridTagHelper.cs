using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Razor.TagHelpers;
using WhiteNoise.Shared.Attributes;

namespace WhiteNoise.Shared.TagHelpers
{
    [HtmlTargetElement("table-grid")]
    public class TableGridTagHelper : TagHelper
    {
        [HtmlAttributeName("items")]
        public IEnumerable<object> Items { get; set; }

        [HtmlAttributeName("controller")]
        public string? Controller { get; set; }

        [HtmlAttributeName("allow-sorting")]
        public bool AllowSorting { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "table";

            var css = "table table-bordered table-sm compact-grid bg-light text-dark shadow-sm";
            if (AllowSorting)
            {
                css += " datatable";
            }
            output.Attributes.SetAttribute("class", css);

            var props = GetItemProperties();
            TableHeader(output, props);
            TableBody(output, props);
        }

        private void TableHeader(TagHelperOutput output, PropertyInfo[] props)
        {
            output.Content.AppendHtml("<thead class=\"table-dark align-middle\"><tr>");
            foreach (var prop in props)
            {
                if (!prop.PropertyType.FullName!.Contains("Collection") &&
                    !prop.IsDefined(typeof(HiddenInGridAttribute)))
                {
                    var name = GetPropertyName(prop);
                    if (name.Equals("Id", StringComparison.OrdinalIgnoreCase))
                    {
                        output.Content.AppendHtml("<th class=\"text-center\">Ações</th>");
                    }
                    else
                    {
                        output.Content.AppendHtml($"<th>{name}</th>");
                    }
                }
            }
            output.Content.AppendHtml("</tr></thead>");
        }

        private void TableBody(TagHelperOutput output, PropertyInfo[] props)
        {
            output.Content.AppendHtml("<tbody>");
            foreach (var item in Items)
            {
                output.Content.AppendHtml("<tr class=\"align-baseline\">");
                foreach (var prop in props)
                {
                    if (!prop.PropertyType.FullName!.Contains("Collection") &&
                        !prop.IsDefined(typeof(HiddenInGridAttribute)))
                    {
                        var value = GetPropertyValue(prop, item);
                        if (prop.Name.Equals("Id", StringComparison.OrdinalIgnoreCase))
                        {
                            var controller = Controller ?? prop.ReflectedType!.Name;
                            output.Content.AppendHtml(
                                "<td class=\"text-center py-1 px-2\"><div class=\"btn-group btn-group-sm\" role=\"group\">"
                                + $"<a href=\"/{controller}/Details/{value}\" class=\"btn btn-outline-secondary btn-light\"><i class=\"bi bi-search me-1\"></i></a>"
                                + $"<a href=\"/{controller}/Delete/{value}\" class=\"ml-1 btn btn-danger\"><i class=\"bi bi-trash me-1\"></i></a>"
                                + "</div></td>"
                            );
                        }
                        else
                        {
                            output.Content.AppendHtml($"<td class=\"py-1 px-2\">{value}</td>");
                        }
                    }
                }
                output.Content.AppendHtml("</tr>");
            }
            output.Content.AppendHtml("</tbody>");
        }

        private string GetPropertyName(PropertyInfo property)
        {
            var disp = property.GetCustomAttribute<DisplayAttribute>();
            return disp?.Name ?? property.Name;
        }

        private object? GetPropertyValue(PropertyInfo property, object instance)
            => property.GetValue(instance);

        private PropertyInfo[] GetItemProperties()
        {
            var listType = Items.GetType();
            if (listType.IsGenericType)
            {
                var itemType = listType.GetGenericArguments().First();
                return itemType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            }
            return Array.Empty<PropertyInfo>();
        }
    }
}