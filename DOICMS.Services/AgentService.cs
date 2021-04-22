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
        public IEnumerable<AgentListItem> GetAgents()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Agents
                    .Select(
                        e =>
                        new AgentListItem
                        {
                            AgentID = e.AgentID,
                            LicenseNumber = e.LicenseNumber,
                            Name = e.Name,
                            Email = e.Email,
                            Address = e.Address,
                            PhoneNumber = e.PhoneNumber
                        }
                        );

                return query.ToArray();
            }
        }
        public AgentDetail GetAgentByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Agents
                        .Single(e => e.AgentID == id);
                return
                    new AgentDetail
                    {
                        AgentID = entity.AgentID,
                        LicenseNumber = entity.LicenseNumber,
                        Name = entity.Name,
                        Email = entity.Email,
                        Address = entity.Address,
                        PhoneNumber = entity.PhoneNumber
                    };

            }
        }
        public bool UpdateAgent (AgentEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Agents
                        .Single(e => e.AgentID == model.AgentID);
                entity.LicenseNumber = model.LicenseNumber;
                entity.Name = model.Name;
                entity.Email = model.Email;
                entity.Address = model.Email;
                entity.PhoneNumber = model.PhoneNumber;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteAgent(int agentID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Agents
                        .Single(e => e.AgentID == agentID);

                ctx.Agents.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
