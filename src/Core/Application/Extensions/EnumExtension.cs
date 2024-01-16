
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;


namespace hshmedstats.Application.Extensions
{
   public static class EnumExtension
    {
        public static string GetEnumDisplayAttribute<T>(this T enumValue)
        {
            return enumValue
                .GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>().Name;
        }

        public static int ToInt<T>(this T enumValue)
        {
            return (int)(object)enumValue;
        }

        public static SelectListItem GetSelectListItem<T>(this T enumValue)
        {
            return new SelectListItem { Value = enumValue.ToInt().ToString(), Text = enumValue.GetEnumDisplayAttribute() };
        }
    }
}
