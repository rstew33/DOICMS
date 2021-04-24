using DOICMS.Models;
using DOICMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOICMS.WebMVC.Controllers
{
    public class InvestigatorController : Controller
    {
        [Authorize]
        // GET: Investigator
        public ActionResult Index()
        {
            var service = new InvestigatorService();
            var model = service.GetInvestigators();
            ViewBag.TotalCount = model.ToList().Count();
            return View(model);
        }
        public ActionResult InvestigatorCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InvestigatorCreate(InvestigatorCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new InvestigatorService();
            if (service.InvestigatorCreate(model))
            {
                TempData["SaveResult"] = "The Investigator was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "The Investigator could not be created.");
            return View(model);
        }
        public ActionResult InvestigatorDetails(int id)
        {
            var svc = new InvestigatorService();
            var model = svc.GetInvestigatorByID(id);

            return View(model);
        }
        public ActionResult InvestigatorEdit(int id)
        {
            var svc = new InvestigatorService();
            var detail = svc.GetInvestigatorByID(id);
            var model =
                new InvestigatorEdit
                {
                    InvestigatorID = detail.InvestigatorID,
                    Name = detail.Name,
                    Email = detail.Email,
                    Address = detail.Address,
                    PhoneNumber = detail.PhoneNumber,
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InvestigatorEdit(int id, InvestigatorEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.InvestigatorID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var svc = new InvestigatorService();

            if (svc.UpdateInvestigator(model))
            {
                TempData["SaveResult"] = "The Investigator was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The Investigator could not be updated");
            return View(model);
        }
        [ActionName("InvestigatorDelete")]
        public ActionResult InvestigatorDelete(int id)
        {
            var svc = new InvestigatorService();
            var model = svc.GetInvestigatorByID(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("InvestigatorDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteInvestigator(int id)
        {
            var service = new InvestigatorService();

            service.DeleteInvestigator(id);

            TempData["Save Result"] = ("The Investigator was removed");
            return RedirectToAction("Index");
        }
    }
}