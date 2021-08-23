using MTCmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTC_WebServerCore.ViewModels.OrderOut_VM
{
    public class OrderOutOverviewViewModel
    {
        public int OrderOutId { get; set; }
        public DateTime OrderOutDate { get; set; }

        public int LineCount { get; set; }

        public string NameOfClient { get; set; }
    }
}
