using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTCmodel
{
    public class ApplicationRole : IdentityRole
    {
        public bool IsRemovable { get; set; } = true;
    }
}
