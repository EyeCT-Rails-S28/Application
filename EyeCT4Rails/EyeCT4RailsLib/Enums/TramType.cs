using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace EyeCT4RailsLib.Enums
{
    /// <summary>
    /// Types of a tram.
    /// </summary>
    public enum TramType
    {
        [Description("Combino")] Combino = 1,
        [Description("11G")] ElevenG = 2,
        [Description("Dubbel Combino")] DCombino = 3,
        [Description("12G")] TwelveG = 4,
        [Description("Opleidingstram")] Trainer = 5
    }

    /// <summary>
    /// Gets the description of the TramType.
    /// </summary>
    public static class TramTypeExt
    {
        public static string GetDescription(this TramType value)
        {
            return ((DescriptionAttribute) Attribute.GetCustomAttribute(
                value.GetType().GetFields(BindingFlags.Public | BindingFlags.Static)
                    .Single(x => x.GetValue(null).Equals(value)),
                typeof (DescriptionAttribute)))?.Description ?? value.ToString();
        }
    }
}