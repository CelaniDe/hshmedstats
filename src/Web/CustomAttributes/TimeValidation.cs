using hshmedstats.Application.Helpers;
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace hshmedstats.Web.CustomAttributes
{
    public class TimeValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null) return true;
            DateTime myDatetime;
            var time = (string)value;
            bool isParsed = DateTime.TryParseExact(DateTime.Now.ToString(Format.DATE_FORMAT) + " " + time, Format.DATE_TIME_FORMAT, System.Globalization.CultureInfo.InvariantCulture, DateTimeStyles.None, out myDatetime);
            if (!isParsed)
                return false;
            return true;
        }
    }
}
