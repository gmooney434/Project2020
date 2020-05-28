using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2020.Models
{
    public class SQLGuestRepository : IGuestRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<SQLGuestRepository> logger;

        public SQLGuestRepository(AppDbContext context, ILogger<SQLGuestRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public object[] Id { get; private set; }

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

        public void Delete(Guest guest) => GetGuest(Id);

        public IEnumerable<Guest> GetAllGuests()
        {
            return context.Guests;
        }

        public Guest GetGuest(int Id)
        {
            logger.LogTrace("Trace Log");
            logger.LogDebug("Debug Log");
            logger.LogInformation("Information Log");
            logger.LogWarning("Warning Log");
            logger.LogError("Error Log");
            logger.LogCritical("Critical Log");
            return context.Guests.Find(Id);
        }

        public Guest GetGuest(object value)
        {
            return context.Guests.Find(Id);
        }

        public void Save()
        {
            throw new NotImplementedException();
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
