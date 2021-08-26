using MTCmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTC_WebServerCore.ViewModels.Home
{
    public class CommentViewModel
    {
        public string Text { get; set; }
        public string ClientId { get; set; }
        public Client Client { get; set; }
        public string EAN { get; set; }
        public int Rating { get; set; }
    }
}
