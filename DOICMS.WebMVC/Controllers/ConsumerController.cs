using DOICMS.Models;
using DOICMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOICMS.WebMVC.Controllers
{
    public class ConsumerController : Controller
    {
        [Authorize]
        // GET: Consumer
        public ActionResult Index()
        {
            var service = new ConsumerService();
            var model = service.GetConsumers();
            ViewBag.TotalCount = model.ToList().Count();
            return View(model);
        }
        public ActionResult ConsumerCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConsumerCreate(ConsumerCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new ConsumerService();
            if (service.ConsumerCreate(model))
            {
                TempData["SaveResult"] = "The Consumer was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "The Consumer could not be created.");
            return View(model);
        }
        public ActionResult ConsumerDetails(int id)
        {
            var svc = new ConsumerService();
            var model = svc.GetConsumerByID(id);

            return View(model);
        }
        public ActionResult ConsumerEdit(int id)
        {
            var svc = new ConsumerService();
            var detail = svc.GetConsumerByID(id);
            var model =
                new ConsumerEdit
                {
                    ConsumerID = detail.ConsumerID,
                    Name = detail.Name,
                    Email = detail.Email,
                    Address = detail.Address,
                    PhoneNumber = detail.PhoneNumber,
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConsumerEdit(int id, ConsumerEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ConsumerID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var svc = new ConsumerService();

            if (svc.UpdateConsumer(model))
            {
                TempData["SaveResult"] = "The Consumer was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The Consumer could not be updated");
            return View(model);
        }
        [ActionName("ConsumerDelete")]
        public ActionResult ConsumerDelete(int id)
        {
            var svc = new ConsumerService();
            var model = svc.GetConsumerByID(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("ConsumerDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConsumer(int id)
        {
            var service = new ConsumerService();

            service.DeleteConsumer(id);

            TempData["Save Result"] = ("The Consumer was removed");
            return RedirectToAction("Index");
        }
    }
}