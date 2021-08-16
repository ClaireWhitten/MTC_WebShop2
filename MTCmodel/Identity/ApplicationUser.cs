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

        public bool IsActive { get; set; } = true;

        //=============================== foreign key's =========================================
        [MaxLength(450)]

        //public string ClientId { get; set; }
        public Client Client { get; set; }

        //-------------------------------------------------------------
        [MaxLength(450)]
        //public string TransporterId { get; set; }
        public Transporter Transporter { get; set; }
        //-----------------------------------------------------------
        [MaxLength(450)]
        //public string SupplierId { get; set; }
        public Supplier Supplier { get; set; }



        //=============================== navigation property's =================================


        public ICollection<Address> Addresses { get; set; }



        //================================ Extra's ==============================================
    }
}
