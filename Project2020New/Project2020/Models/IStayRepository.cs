using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2020.Models
{
    public interface IStayRepository
    {
       //need a method to select stayid within guestid for details/staycontroller
        Stay GetStay(int StayId);
        //need a method that gets all stays for a certain guest for index/staycontroller
        IEnumerable<Stay> GetAllStays();
        Stay Add(Stay stay);
        Stay Update(Stay stayChanges);
        Stay Delete(int stayid);
    }
}
