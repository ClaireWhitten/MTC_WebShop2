using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MTCmodel
{
    //public enum TypeOfUser
    //{
    //    Client,
    //    Transporter,
    //    Supplier,
    //}

    public class ApplicationUser : IdentityUser
    {
        public bool IsRemovable { get; set; } = true;

        //[Required]
        //[MinLength(2, ErrorMessage = "Gemeente moet minstens 2 tekens lang zijn")]
        //[MaxLength(30, ErrorMessage = "Gemeente mag maximum 30 tekens lang zijn")]
        //public string City { get; set; }


        //[Required]
        //[MinLength(4, ErrorMessage = "Postcode moet minstens 4 tekens lang zijn")]
        //[MaxLength(9, ErrorMessage = "Postcode mag maximum 9 tekens lang zijn")]
        //public string Zipcode { get; set; }


        //TypeOfUser TypeOfUser { get; set; }

        //=============================== foreign key's =========================================
        [MaxLength(450)]

        public string? ClientId { get; set; }
        public Client Client { get; set; }

        //-------------------------------------------------------------
        [MaxLength(450)]
        public string TransporterId { get; set; }
        public Transporter Transporter { get; set; }
        //-----------------------------------------------------------
        [MaxLength(450)]
        public string SupplierId { get; set; }
        public Supplier Supplier { get; set; }



        //=============================== navigation property's =================================


        public ICollection<Address> Addresses { get; set; }

        //=========================

        //================================ Extra's ==============================================
    }
}
