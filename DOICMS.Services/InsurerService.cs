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
        public bool CreateInsurer(InsurerCreate model)
        {
            var entity =
                new Insurer()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Address = model.Address,
                    PhoneNumber = model.PhoneNumber,
                    Type = (Insurer._Type)model.Type
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
                            Type = (InsurerListItem._Type)(Insurer._Type)e.Type
                        }
                        );

                return query.ToArray();
            }
        }
    }
}
