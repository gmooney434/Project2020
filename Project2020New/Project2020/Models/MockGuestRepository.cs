using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2020.Models
{
    public class MockGuestRepository : IGuestRepository
    {
        private List<Guest> _guestList;

        public MockGuestRepository()
        {
            _guestList = new List<Guest>()
            {
                new Guest() {Id = 1, Forename = "John", Surname = "Smith" },
                new Guest() {Id = 2, Forename = "Jane", Surname = "Doe" }
            };
        }

        public IEnumerable<Guest> GetAllGuests()
        {
            return _guestList;
        }

        public Guest GetGuest(int Id)
        {
            return _guestList.FirstOrDefault(e => e.Id == Id);
        }
    }
}
