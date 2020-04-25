using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2020.Models
{
    public class MockStayRepository : IStayRepository
    {
        private List<Stay> _stayList;
        readonly string dateInput = "01/01/1998";
        

        public MockStayRepository()
        {
            DateTime myDateTime = DateTime.Parse(dateInput);

            _stayList = new List<Stay>() {
                new Stay() {GuestID = 1, StayId = 1, StartDate = myDateTime, EndDate = myDateTime }
                
            };
        }

        public Stay Add(Stay stay)
        {
            stay.StayId = _stayList.Max(s => s.StayId) + 1;
            _stayList.Add(stay);
            return stay;
        }

        public IEnumerable<Stay> GetAllStays()
        {
            return _stayList;
        }

        public Stay GetStay(int StayId)
        {
            return _stayList.FirstOrDefault(e => e.StayId == StayId);
        }
    }
}
