using DOICMS.Data;
using DOICMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOICMS.Services
{
    public class InvestigatorService
    {
        public bool InvestigatorCreate(InvestigatorCreate model)
        {
            var entity =
                new Investigator()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Address = model.Address,
                    PhoneNumber = model.PhoneNumber,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Investigators.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<InvestigatorListItem> GetInvestigators()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Investigators
                    .Select(
                        e =>
                        new InvestigatorListItem
                        {
                            InvestigatorID = e.InvestigatorID,
                            Name = e.Name,
                            Email = e.Email,
                            Address = e.Address,
                            PhoneNumber = e.PhoneNumber,
                        }
                        );

                return query.ToArray();
            }
        }
        public InvestigatorDetail GetInvestigatorByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Investigators
                        .Single(e => e.InvestigatorID == id);
                return
                    new InvestigatorDetail
                    {
                        InvestigatorID = entity.InvestigatorID,
                        Name = entity.Name,
                        Email = entity.Email,
                        Address = entity.Address,
                        PhoneNumber = entity.PhoneNumber,
                    };

            }
        }
        public bool UpdateInvestigator(InvestigatorEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Investigators
                        .Single(e => e.InvestigatorID == model.InvestigatorID);
                entity.Name = model.Name;
                entity.Email = model.Email;
                entity.Address = model.Email;
                entity.PhoneNumber = model.PhoneNumber;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteInvestigator(int InvestigatorID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Investigators
                        .Single(e => e.InvestigatorID == InvestigatorID);

                ctx.Investigators.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
