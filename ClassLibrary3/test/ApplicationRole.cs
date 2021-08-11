using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTCrepository.test
{
    public class ApplicationRole : IdentityRole
    {
        public bool IsRemovable { get; set; } = true;
    }
}
