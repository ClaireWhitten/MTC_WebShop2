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
            new Claim("Users","Users"),

            //new Claim("Create Book", "Create Book"),
            //new Claim("Edit Book","Edit Book"),
            //new Claim("Delete Book","Delete Book")
        };
    }
}
