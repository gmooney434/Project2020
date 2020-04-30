using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2020.Models
{
    public class SQLStayRepository : IStayRepository
    {
        private readonly AppDbContext context;

        public SQLStayRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Stay Add(Stay stay)
        {
            context.Stays.Add(stay);
            context.SaveChanges();
            return stay;
        }
        public Stay GetStay(int StayId)
        {
            
            return context.Stays.Find(StayId);

        }

        public IEnumerable<Stay> GetAllStays()
        {
            return context.Stays;
        }

        
    }
}
