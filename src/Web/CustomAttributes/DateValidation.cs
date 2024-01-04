using System.ComponentModel.DataAnnotations;
using System;
using System.Globalization;

namespace hshmedstats.Web.CustomAttributes
{
    public class DateValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime myDatetime;
            if ((string)value == "") return true;
            bool isParsed = DateTime.TryParseExact((string)value, new[] { "dd/MM/yyyy", "dd/M/yyyy", "d/M/yyyy", "d/MM/yyyy" },CultureInfo.InvariantCulture, DateTimeStyles.None, out myDatetime);

            if (!isParsed)
                return false;
            return true;
        }
    }

}
