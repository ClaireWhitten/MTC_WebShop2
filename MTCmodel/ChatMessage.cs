using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MTCmodel
{
    public class ChatMessage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(256, ErrorMessage = "de maximum lengte van de username is 256")]
        public string UsernameSender { get; set; }

        [Required]
        [MaxLength(256, ErrorMessage = "de maximum lengte van de username is 256")]
        public string UserNameReceiver { get; set; }


        [Required]
        [MaxLength(256, ErrorMessage = "de maximum lengte van de message is 256")]
        public string Message { get; set; }


        public DateTime DateTime { get; set; } = DateTime.Now;


        public bool IsReaded { get; set; } = false;
        public bool IsFromAdmin { get; set; } = false;


        //=================================================================================
        [MaxLength(450)]
        public string CliendId{ get; set; }
        public virtual Client Client { get; set; }
        ////--------------------------------------------------------------------------------
        

        //[MaxLength(450)]
        //public string SenderId { get; set; }
        //public virtual ApplicationUser Sender { get; set; }
    }
}
