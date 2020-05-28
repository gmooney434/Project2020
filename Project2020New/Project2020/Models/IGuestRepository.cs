using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2020.Models
{
    public interface IGuestRepository
    {
        Guest GetGuest(int Id);
        IEnumerable<Guest> GetAllGuests();
        Guest Add(Guest guest);
        Guest Update(Guest guestChanges);
        Guest Delete(int id);
        Guest GetGuest(object value);
        void Delete(Guest guest);
        void Save();
    }
}
