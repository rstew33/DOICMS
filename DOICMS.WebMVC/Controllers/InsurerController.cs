using DOICMS.Data;
using DOICMS.Models;
using DOICMS.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOICMS.WebMVC.Controllers
{
    public class InsurerController : Controller
    {
        [Authorize]
        // GET: Insurer
        public ActionResult Index()
        {
            var service = new InsurerService();
            var model = service.GetInsurers();
            ViewBag.TotalCount = model.ToList().Count();
            return View(model);
        }
        public ActionResult InsurerCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsurerCreate(InsurerCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new InsurerService();
            if (service.InsurerCreate(model))
            {
                TempData["SaveResult"] = "The insurer was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "The insurer could not be created.");
            return View(model);
        }
        public ActionResult InsurerDetails(int id)
        {
            var svc = new InsurerService();
            var model = svc.GetInsurerByID(id);

            return View(model);
        }
        public ActionResult InsurerEdit(int id)
        {
            var svc = new InsurerService();
            var detail = svc.GetInsurerByID(id);
            var model =
                new InsurerEdit
                {
                    InsurerID = detail.InsurerID,
                    Name = detail.Name,
                    Email = detail.Email,
                    Address = detail.Address,
                    PhoneNumber = detail.PhoneNumber,
                    Type = detail.Type
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsurerEdit(int id, InsurerEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.InsurerID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var svc = new InsurerService();

            if (svc.UpdateInsurer(model))
            {
                TempData["SaveResult"] = "The insurer was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The insurer could not be updated");
            return View(model);
        }
        [ActionName("InsurerDelete")]
        public ActionResult InsurerDelete(int id)
        {
            var svc = new InsurerService();
            var model = svc.GetInsurerByID(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("InsurerDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteInsurer (int id)
        {
            var service = new InsurerService();

            service.DeleteInsurer(id);

            TempData["Save Result"] = ("The insurer was removed");
            return RedirectToAction("Index");
        }
    }
}