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
        public string? Controller { get; set; } = null;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "table";
            output.Attributes.Add("class", "table table-bordered table-sm table-striped compact-grid");

            var props = GetItemProperties();

            TableHeader(output, props);
            TableBody(output, props);
        }

        private void TableHeader(TagHelperOutput output, PropertyInfo[] props)
        {
            output.Content.AppendHtml("<thead class=\"table-dark align-middle\">");
            output.Content.AppendHtml("<tr>");
            foreach (var prop in props)
            {
                if (!prop.PropertyType.ToString().Contains("System.Collection") &&
                !prop.IsDefined(typeof(HiddenInGridAttribute)))
                {
                    var name = GetPropertyName(prop);
                    output.Content.AppendHtml(!name.Equals("Id")
                        ? $"<th class=\"py-2 px-3\">{name}</th>"
                        : "<th class=\"text-center py-2 px-3\">Ações</th>");
                }
            }
            output.Content.AppendHtml("</tr>");
            output.Content.AppendHtml("</thead>");
        }

        private void TableBody(TagHelperOutput output, PropertyInfo[] props)
        {
            output.Content.AppendHtml("<tbody>");
            foreach (var item in Items)
            {
                output.Content.AppendHtml("<tr class=\"align-baseline\">");
                foreach (var prop in props)
                {
                    if (!prop.PropertyType.ToString().Contains("Collection") &&
                        !prop.IsDefined(typeof(HiddenInGridAttribute)))
                    {
                        var value = GetPropertyValue(prop, item);
                        if (prop.Name.Equals("Id"))
                        {
                            var controller = Controller ?? prop.ReflectedType.Name;
                            output.Content.AppendHtml("<td class=\"text-center py-1 px-2\">");
                            output.Content.AppendHtml($"<div class=\"btn-group btn-group-sm\" role=\"group\">");
                            output.Content.AppendHtml($"<a href='/{controller}/Details/{value}' class='btn btn-primary'>Detalhes</a>");
                            output.Content.AppendHtml($"<a href='/{controller}/Delete/{value}' class='btn btn-danger'>Excluir</a>");
                            output.Content.AppendHtml("</div></td>");
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
            var attribute = property.GetCustomAttribute<DisplayAttribute>();
            if (attribute != null)
                return attribute.Name;

            return property.Name;
        }

        private object GetPropertyValue(PropertyInfo property, object instance)
        {
            return property.GetValue(instance);
        }

        private PropertyInfo[] GetItemProperties()
        {
            var listType = Items.GetType();
            if (listType.IsGenericType)
            {
                Type itemType = listType.GetGenericArguments().First();
                return itemType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            }
            return Array.Empty<PropertyInfo>();
        }
    }
}