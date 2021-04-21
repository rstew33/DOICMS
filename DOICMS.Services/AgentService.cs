using DOICMS.Data;
using DOICMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOICMS.Services
{
    public class AgentService
    {
        public bool CreateAgent(AgentCreate model)
        {
            var entity =
                new Agent()
                {
                    LicenseNumber = model.LicenseNumber,
                    Name = model.Name,
                    Email = model.Email,
                    Address = model.Address,
                    PhoneNumber = model.PhoneNumber
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Agents.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
