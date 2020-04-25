using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2020.Models
{
    public class MockGuestRepository : IGuestRepository
    {
        private List<Guest> _guestList;
        readonly string dateInput = "01/01/1998";


        public MockGuestRepository()
        {
            DateTime myDateTime = DateTime.Parse(dateInput);

            _guestList = new List<Guest>()
            {
                new Guest() {Id = 1, Forename = "John", Surname = "Smith", Date_Of_Birth = myDateTime, PhotoPath = "files" },
                new Guest() {Id = 2, Forename = "Jane", Surname = "Doe", Date_Of_Birth = myDateTime, PhotoPath = "files" }
            };
        }

        public Guest Add(Guest guest)
        {
            guest.Id = _guestList.Max(g => g.Id) + 1;
            _guestList.Add(guest);
            return guest;
        }

        public IEnumerable<Guest> GetAllGuests()
        {
            return _guestList;
        }

        public Guest GetGuest(int Id)
        {
            return _guestList.FirstOrDefault(e => e.Id == Id);
        }

        public Guest Update(Guest guestChanges)
        {
            Guest guest = _guestList.FirstOrDefault(g => g.Id == guestChanges.Id);
            if (guest != null)
            {
                guest.Forename = guestChanges.Forename;
                guest.Surname = guestChanges.Surname;
                guest.Date_Of_Birth = guestChanges.Date_Of_Birth;
                guest.PhotoPath = guestChanges.PhotoPath;

            }
            return guest;
        }

        public Guest Delete(int Id)
        {
            Guest guest = _guestList.FirstOrDefault(g => g.Id == Id);
            if(guest != null)
            {
                _guestList.Remove(guest);

            }
            return guest;
        }
    }
}
