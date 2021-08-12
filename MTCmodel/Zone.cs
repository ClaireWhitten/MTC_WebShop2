using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MTCmodel
{
    public class Zone
    {
        //-------------------------------------------------------------------
        [Key]
        public int Id { get; set; }

        //-------------------------------------------------------------------
        [Required(ErrorMessage = "Zone name cannot be empty")]
        [MaxLength(60)]
        public string Name { get; set;}


        //=============================== foreign key's =========================================

        [Required]
        [MaxLength(450)]
        public string TransporterID { get; set; }
        public Transporter Transporter { get; set; }

        //=============================== navigation property's =================================


        //================================ Extra's ==============================================
    }
}
