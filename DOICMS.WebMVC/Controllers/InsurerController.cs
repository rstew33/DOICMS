using DOICMS.Models;
using DOICMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOICMS.WebMVC.Controllers
{
    public class InsurerController : Controller
    {
        [Authorize]
        // GET: Agent
        public ActionResult Index()
        {
            var service = new InsurerService();
            var model = service.GetInsurers();

            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InsurerCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new InsurerService();

            if (service.CreateInsurer(model))
            {
                TempData["SaveResult"] = "The insurer was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "The insurer could not be created.");
            return View(model);
        }
    }
}