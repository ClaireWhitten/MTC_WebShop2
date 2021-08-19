using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MTCmodel
{
    public class ClaimsStore
    {
        public static List<Claim> AllClaims = new List<Claim>()
        {
            new Claim("Products", "Products"),
            new Claim("ProductCategories","ProductCategories"),

            //new added on 19aug2021
            new Claim("PreparingOrderOUT","PreparingOrderOUT"),
            new Claim("SentOrderOUT","SentOrderOUT"),

            new Claim("ReservedOrderIn","ReservedOrderIn"),
            new Claim("DeliveredOrderIn","DeliveredOrderIn"),


        };
    }
}
