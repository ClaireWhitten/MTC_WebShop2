using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace MTCmodel.Identity
{
    public class UserFactory
    {
        public ApplicationUser Create(ClaimsPrincipal aApplicationUser)
        {
            if (aApplicationUser.IsInRole("Client")){
                return new Client();
            }
            if (aApplicationUser.IsInRole("Supplier"))
            {
                return new Supplier();
            }
            if (aApplicationUser.IsInRole("Supplier"))
            {
                return new Supplier();
            }

            throw new NotImplementedException("Critical error, the Role for the user not found");
        }
    }
}
