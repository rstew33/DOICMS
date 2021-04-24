using DOICMS.Models;
using DOICMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOICMS.WebMVC.Controllers
{
    public class AdminActionController : Controller
    {
        [Authorize]
        // GET: AdminAction
        public ActionResult Index()
        {
            var service = new AdminActionService();
            var model = service.GetAdminActions();
            ViewBag.TotalCount = model.ToList().Count();
            return View(model);
        }
        public ActionResult AdminActionCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminActionCreate(AdminActionCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new AdminActionService();
            if (service.AdminActionCreate(model))
            {
                TempData["SaveResult"] = "The AdminAction was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "The AdminAction could not be created.");
            return View(model);
        }
        public ActionResult AdminActionDetails(int id)
        {
            var svc = new AdminActionService();
            var model = svc.GetAdminActionByID(id);

            return View(model);
        }
        public ActionResult AdminActionEdit(int id)
        {
            var svc = new AdminActionService();
            var detail = svc.GetAdminActionByID(id);
            var model =
                new AdminActionEdit
                {
                    AdminActionID = detail.AdminActionID,
                    OrderType = detail.OrderType,
                    InvestigatorID = detail.InvestigatorID,
                    AgentID = detail.AgentID,
                    InsurerID = detail.InsurerID
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminActionEdit(int id, AdminActionEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.AdminActionID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var svc = new AdminActionService();

            if (svc.UpdateAdminAction(model))
            {
                TempData["SaveResult"] = "The AdminAction was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The AdminAction could not be updated");
            return View(model);
        }
        [ActionName("AdminActionDelete")]
        public ActionResult AdminActionDelete(int id)
        {
            var svc = new AdminActionService();
            var model = svc.GetAdminActionByID(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("AdminActionDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAdminAction(int id)
        {
            var service = new AdminActionService();

            service.DeleteAdminAction(id);

            TempData["Save Result"] = ("The AdminAction was removed");
            return RedirectToAction("Index");
        }
    }
}