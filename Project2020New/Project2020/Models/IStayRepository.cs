using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2020.Models
{
    public interface IStayRepository
    {
        Stay GetStay(int StayId);        
    }
}
