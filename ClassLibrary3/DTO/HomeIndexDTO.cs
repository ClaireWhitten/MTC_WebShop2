using MTCmodel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MTCrepository.DTO
{
    public class HomeIndexDTO
    {
        public List< Product> Products { get; set; }

        
        public List< ProductCategorie> FullPathReversed { get; set; }
    }
}
