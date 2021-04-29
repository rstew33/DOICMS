using DOICMS.Data;
using DOICMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOICMS.Services
{
    public class AdminActionService
    {
        public bool AdminActionCreate(AdminActionCreate model)
        {
            var entity =
                new AdminAction()
                {
                    OrderType = model.OrderType,
                    InvestigatorID = model.InvestigatorID,
                    AgentID = model.AgentID,
                    InsurerID = model.InsurerID
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.AdminActions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<AdminActionListItem> GetAdminActions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .AdminActions
                    .Select(
                        e =>
                        new AdminActionListItem
                        {
                            AdminActionID = e.AdminActionID,
                            OrderType = e.OrderType,
                            InvestigatorID = e.InvestigatorID,
                            InvestigatorName = e.Investigator.Name,
                            AgentID = e.AgentID,
                            InsurerID = e.InsurerID
                        }
                        ); ;

                return query.ToArray();
            }
        }
        public AdminActionDetail GetAdminActionByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .AdminActions
                        .Single(e => e.AdminActionID == id);
                return
                    new AdminActionDetail
                    {
                        AdminActionID = entity.AdminActionID,
                        OrderType = entity.OrderType,
                        InvestigatorID = entity.InvestigatorID,
                        AgentID = entity.AgentID,
                        InsurerID = entity.InsurerID
                    };

            }
        }
        public bool UpdateAdminAction(AdminActionEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .AdminActions
                        .Single(e => e.AdminActionID == model.AdminActionID);
                entity.OrderType = model.OrderType;
                entity.InvestigatorID = model.InvestigatorID;
                entity.AgentID = model.AgentID;
                entity.InsurerID = model.InsurerID;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteAdminAction(int AdminActionID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .AdminActions
                        .Single(e => e.AdminActionID == AdminActionID);

                ctx.AdminActions.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
