using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2020.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string B_Code { get; set; }
        public string FullName { get; set; }
    }
}
