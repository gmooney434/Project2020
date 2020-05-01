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
        //needs to get guestid/stayid
        //in stay controller and istayrepository
        //stay/Details.cshtml view
        public Stay GetStay(int StayId)
        {
            
            return context.Stays.Find(StayId);

        }
        //needs to get all stays related to the guest id
        //on staycontroller and stayrepository
        //stay/index.cshtml view
        public IEnumerable<Stay> GetAllStays()
        {
            return context.Stays;
        }

        public Stay Delete(int stayid)
        {
            Stay stay = context.Stays.Find(stayid);
            if (stay != null)
            {
                context.Stays.Remove(stay);
                context.SaveChanges();
            }
            return stay;

        }
        public Stay Update(Stay stayChanges)
        {
            var stay = context.Stays.Attach(stayChanges);
            stay.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return stayChanges;
        }
    }

}

