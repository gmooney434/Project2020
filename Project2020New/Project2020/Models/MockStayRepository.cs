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
                new Stay() {StayId = 1, StartDate = myDateTime, EndDate = myDateTime }
                
            };
        }

        public Stay GetStay(int StayId)
        {
            return _stayList.FirstOrDefault(e => e.StayId == StayId);
        }
    }
}
