using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2020.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            string dateInput = "01/01/1998";
            string contactNumber = "07411111111";

            DateTime myDateTime = DateTime.Parse(dateInput);
            modelBuilder.Entity<Guest>().HasData(
            new Guest
                {
                    Id = 1,
                    Forename = "John",
                    Surname = "Doe",
                    Date_Of_Birth = myDateTime,
                    PhotoPath = null  
                    
                }
            
            
            );

            modelBuilder.Entity<Stay>().HasData(
            new Stay
                {
                    StayId = 1,
                    StartDate = myDateTime,
                    EndDate = myDateTime,
                    EmergencyContactNumber = contactNumber,
                    GuestID = 1
                });

            modelBuilder.Entity<Guest>()
                .HasMany(id => id.Stays).WithOne(id => id.Guest);



        }
     }
}
