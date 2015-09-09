using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpOut.Domain
{
    public interface ITimeConverter
    {
        DateTime ToLocalTime(DateTime time, string timezone);
    }

    public class TimeConverter : ITimeConverter
    {
        public DateTime ToLocalTime(DateTime time, string timezone)
        {
            return TimeZoneInfo.ConvertTimeToUtc(
                time, 
                TimeZoneInfo.FindSystemTimeZoneById(timezone))
                .ToLocalTime();
        }
    }

}
