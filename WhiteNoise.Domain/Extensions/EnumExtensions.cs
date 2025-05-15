using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace WhiteNoise.Domain.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());

            if (fi is null)
                return value.ToString();

            var attributes = (DisplayAttribute[])fi.GetCustomAttributes(typeof(DisplayAttribute), false);

            if (attributes.Length > 0 && !string.IsNullOrEmpty(attributes[0].Name))
                return attributes[0].Name;

            return value.ToString();
        }

        public static string GetEnumDescription(this Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());

            var descriptionAttr = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute));
            if (descriptionAttr.Length > 0)
                return descriptionAttr[0].Description;

            return value.ToString();
        }
    }
}
