using DOICMS.Data;
using DOICMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOICMS.Services
{
    public class ConsumerService
    {
        public bool ConsumerCreate(ConsumerCreate model)
        {
            var entity =
                new Consumer()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Address = model.Address,
                    PhoneNumber = model.PhoneNumber,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Consumers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ConsumerListItem> GetConsumers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Consumers
                    .Select(
                        e =>
                        new ConsumerListItem
                        {
                            ConsumerID = e.ConsumerID,
                            Name = e.Name,
                            Email = e.Email,
                            Address = e.Address,
                            PhoneNumber = e.PhoneNumber,
                        }
                        );

                return query.ToArray();
            }
        }
        public ConsumerDetail GetConsumerByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Consumers
                        .Single(e => e.ConsumerID == id);
                return
                    new ConsumerDetail
                    {
                        ConsumerID = entity.ConsumerID,
                        Name = entity.Name,
                        Email = entity.Email,
                        Address = entity.Address,
                        PhoneNumber = entity.PhoneNumber,
                    };

            }
        }
        public bool UpdateConsumer(ConsumerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Consumers
                        .Single(e => e.ConsumerID == model.ConsumerID);
                entity.Name = model.Name;
                entity.Email = model.Email;
                entity.Address = model.Email;
                entity.PhoneNumber = model.PhoneNumber;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteConsumer(int ConsumerID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Consumers
                        .Single(e => e.ConsumerID == ConsumerID);

                ctx.Consumers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
