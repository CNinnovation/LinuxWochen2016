using LinuxWochenRC1VisualStudio.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinuxWochenRC1VisualStudio.Controllers
{
    public class SaturdayController
    {
        private readonly IWeekdayService _service;
        public SaturdayController(IWeekdayService service)
        {
            _service = service;
        }
        public string Index() => _service.GetDay();
    }
}
