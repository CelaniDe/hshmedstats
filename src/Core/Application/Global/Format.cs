using System;

namespace hshmedstats.Application.Helpers
{
    public static class Format
    {
        public static readonly string DATE_FORMAT = "dd'/'MM'/'yyyy";
        public static readonly string DAY_MONTH_FORMAT = "dd'/'MM";
        public static readonly string TIME_FORMAT = "HH:mm";
        public static readonly string DATE_TIME_FORMAT = "dd'/'MM'/'yyyy HH:mm";
        public static readonly string DATE_TIME_S_FORMAT = "dd'/'MM'/'yyyy HH:mm:ss";
        public static readonly string DATE_FORMAT_PORTAL = "MM'/'dd'/'yyyy";
        public static readonly string YEAR_FORMAT = "yyyy";
        public static readonly string[] CSV_DATE_FORMAT = new string[] { "dd'/'MM'/'yyyy", "d'/'MM'/'yyyy", "dd'/'M'/'yyyy", "d'/'M'/'yyyy" };


        public static string EmailFormat(string emails) => string.Join(", ", emails.Split(',', StringSplitOptions.RemoveEmptyEntries));
    }
}
