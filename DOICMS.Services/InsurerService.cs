using DOICMS.Data;
using DOICMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOICMS.Services
{
    public class InsurerService
    {
        public bool InsurerCreate(InsurerCreate model)
        {
            var entity =
                new Insurer()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Address = model.Address,
                    PhoneNumber = model.PhoneNumber,
                    Type = (Data.InsurerTypes)model.Type
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Insurers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<InsurerListItem> GetInsurers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Insurers
                    .Select(
                        e =>
                        new InsurerListItem
                        {
                            InsurerID = e.InsurerID,
                            Name = e.Name,
                            Email = e.Email,
                            Address = e.Address,
                            PhoneNumber = e.PhoneNumber,
                            Type = (Models.InsurerTypes)e.Type
                        }
                        );

                return query.ToArray();
            }
        }
        public InsurerDetail GetInsurerByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Insurers
                        .Single(e => e.InsurerID == id);
                return
                    new InsurerDetail
                    {
                        InsurerID = entity.InsurerID,
                        Name = entity.Name,
                        Email = entity.Email,
                        Address = entity.Address,
                        PhoneNumber = entity.PhoneNumber,
                        Type = (Models.InsurerTypes)entity.Type
                    };

            }
        }
        public bool UpdateInsurer(InsurerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Insurers
                        .Single(e => e.InsurerID == model.InsurerID);
                entity.Name = model.Name;
                entity.Email = model.Email;
                entity.Address = model.Email;
                entity.PhoneNumber = model.PhoneNumber;
                entity.Type = (Data.InsurerTypes)model.Type;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteInsurer(int insurerID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Insurers
                        .Single(e => e.InsurerID == insurerID);

                ctx.Insurers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
