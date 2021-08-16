using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTC_WebServerCore.Models
{
    public class PageInProgressViewModel
    {
        public string ControllerBack { get; set; }
        public string ActionMethodeBack { get; set; }

        public string Message { get; set; }
    }
}
