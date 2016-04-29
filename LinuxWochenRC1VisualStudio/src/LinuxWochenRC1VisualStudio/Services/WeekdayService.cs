using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinuxWochenRC1VisualStudio.Services
{
    public class WeekdayService : IWeekdayService
    {
        public string GetDay() => DateTime.Today.ToString("D");
    }
}
