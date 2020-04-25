using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2020.Models
{
    public class SQLGuestRepository : IGuestRepository
    {
        private readonly AppDbContext context;

        public SQLGuestRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Guest Add(Guest guest)
        {
            context.Guests.Add(guest);
            context.SaveChanges();
                return guest;
        }

        public Guest Delete(int id)
        {
            Guest guest = context.Guests.Find(id);
            if (guest != null)
            {
                context.Guests.Remove(guest);
                context.SaveChanges();
            }
            return guest;

        }

        public IEnumerable<Guest> GetAllGuests()
        {
            return context.Guests;
        }

        public Guest GetGuest(int Id)
        {
            return context.Guests.Find(Id);
        }

        public Guest Update(Guest guestChanges)
        {
            var guest = context.Guests.Attach(guestChanges);
            guest.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return guestChanges;
        }
    }
}
