using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2020.Models
{
    public class GuestContext : DbContext
    {
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Stay> Stays { get; set; }
    }
}
