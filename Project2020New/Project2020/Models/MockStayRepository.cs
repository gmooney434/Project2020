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

            _stayList = new List<Stay>() { };
            
        }

        public Stay Add(Stay stay)
        {          
            stay.StayId = _stayList.Max(s => s.StayId) + 1;
            _stayList.Add(stay);
            return stay;
        }
        public Stay GetStay(int StayId)
        {
            return _stayList.FirstOrDefault(e => e.StayId == StayId);
        }

        public IEnumerable<Stay> GetAllStays()
        {
            return _stayList;
        }

        public Stay Update(Stay stayChanges)
        {
            throw new NotImplementedException();
        }

        public Stay Delete(int stayid)
        {
            throw new NotImplementedException();
        }

        public Stay GetStay(string stayid)
        {
            throw new NotImplementedException();
        }
    }
}
