using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTC_WebServerCore.ViewModels.Administration
{
    public class EditAdministratorViewModel
    {

        public string Email { get; set; }

        public string Id { get; set; }

        public List<UserClaim> Claims { get; set; }

        //===============================================inner class
        public class UserClaim
        {
            public string ClaimType { get; set; }
            public bool IsSelected { get; set; }
        }
        //=====================================================ctor
        public EditAdministratorViewModel()
        {
            //nullreferences tegengaan
            Claims = new List<UserClaim>();
        }
    }
}
