using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
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


        //=============================== navigation property's =================================


        ICollection<Address> Addresses { get; set; }

        //================================ Extra's ==============================================
    }
}
