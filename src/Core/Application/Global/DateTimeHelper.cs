using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hshmedstats.Application.Global
{
    public static class DateTimeHelper
    {
        public static DateTime Now => DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);
    }
}
