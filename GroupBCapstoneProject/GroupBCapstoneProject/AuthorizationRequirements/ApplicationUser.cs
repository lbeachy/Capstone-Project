using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupBCapstoneProject.AuthorizationRequirements
{
    public class ApplicationUser : IdentityUser
    {
        public string RoleInSchool { get; set; }

        public ApplicationUser()
        {

        }

        public ApplicationUser(string roleInSchool)
        {
            RoleInSchool = roleInSchool;
        }

    }

}
