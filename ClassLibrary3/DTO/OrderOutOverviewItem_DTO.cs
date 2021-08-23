using Microsoft.AspNetCore.Mvc.Rendering;
using MTCmodel;
using MTCmodel.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MTCrepository.DTO
{
    //public class OrderOutOverview_DTO    //OrderOutOverviewItem_DTO
    public class OrderOutOverview_DTO
    {
        //================================================inner class
        public class OrderOutOverviewItem
        {
            public int OrderOutId { get; set; }
            public DateTime OrderOutDate { get; set; }

            //public int LineCount { get; set; }

            public string FullNameOfClient { get; set; }
            public string EmailClient { get; set; }


            public bool IsChecked { get; set; } = false;  // for the checkbox

            public string TransporterId { get; set; }
            public string TransporterName { get; set; }
        }

        //-------------------------------------------------------------------props of OrderOutOverview_DTO
        public List<OrderOutOverviewItem> OrderOutOverviewItems { get; set; }
        public List<SelectListItem> AvaillableTransproters { get; set; } // = new List<SelectListItem>();

        public string AvaillableTransprotersHidden
        {
            get => AvaillableTransproters.SerializeForHidden();
            set => AvaillableTransproters = value.DeserializeForHidden(AvaillableTransproters);
        }

    }

    public class OrderOutOverview_with_transporterSelection_DTO : OrderOutOverview_DTO
    {
        //public List<SelectListItem> AvaillableTransproters { get; set; } = new List<SelectListItem>();
    }


}
