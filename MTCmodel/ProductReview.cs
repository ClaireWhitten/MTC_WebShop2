using MTCmodel.CustomAnnotationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MTCmodel
{
    public class ProductReview
    {

        //-------------------------------------------------------------------
        [Key]
        public int Id { get; set; }

        //------------------------------------------------------------------- required toegevoegd??? is dit nodig?
        [MaxLength(500)]
        [Required]
        public string Comment { get; set; }

        //-------------------------------------------------------------------
        [Required]
        [Range(0,5)]
        public int Rating { get; set; }

        //-------------------------------------------------------------------
        [Required]
        public DateTime DateTime { get; set; } //default?


        //=============================== foreign key's =========================================

        //[ForeignKey("Product")]
        [Required(ErrorMessage = "Product cannot be empty")]
        //[EAN]
        public string ProductEAN { get; set; }

        public Product Product { get; set; }

        //-------------------------------------------------------------------

        [Required(ErrorMessage = "User cannot be empty")]
        [MaxLength(450)]
        public string ClientId { get; set; }

        public Client Client { get; set; }

        //public User User { get; set; } //ff in commentaar om te debuggen


        //=============================== navigation property's =================================


        //================================ Extra's ==============================================




    }
}
