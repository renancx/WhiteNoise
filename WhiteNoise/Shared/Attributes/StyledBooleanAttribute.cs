using System;

namespace WhiteNoise.Shared.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class StyledBooleanAttribute : Attribute
    {
        public string TrueClass { get; set; } = "bg-success text-white";
        public string FalseClass { get; set; } = "bg-secondary text-white";
        public string TrueText { get; set; } = "Ativo";
        public string FalseText { get; set; } = "Inativo";
    }
}