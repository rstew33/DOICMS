using DOICMS.Data;
using DOICMS.Models;
using DOICMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOICMS.WebMVC.Controllers
{
    public class ComplaintController : Controller
    {
        [Authorize]
        // GET: Complaint
        public ActionResult Index()
        {
            var service = new ComplaintService();
            var model = service.GetComplaints();
            ViewBag.TotalCount = model.ToList().Count();
            return View(model);
        }
        public ActionResult ComplaintCreate()
        {
            var service = new ComplaintService();
            var model = new ComplaintCreate
            {
                InvestigatorList = service.GetAllInvestigators(),
                AdminList = service.GetAllAdmin(),
                AgentList = service.GetAllAgents(),
                InsurerList = service.GetAllInsurer(),
                ConsumerList = service.GetAllConsumer()
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ComplaintCreate(ComplaintCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new ComplaintService();
            if (service.ComplaintCreate(model))
            {
                TempData["SaveResult"] = "The Complaint was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "The Complaint could not be created.");
            return View(model);
        }
        public ActionResult ComplaintDetails(int id)
        {
            var svc = new ComplaintService();
            var model = svc.GetComplaintByID(id);

            return View(model);
        }
        public ActionResult ComplaintEdit(int id)
        {
            var svc = new ComplaintService();
            var detail = svc.GetComplaintByID(id);
            var model =
                new ComplaintEdit
                {
                    ComplaintID = detail.ComplaintID,
                    InvestigatorID = detail.InvestigatorID,
                    AdminActionID = detail.AdminActionID,
                    AgentID = detail.AgentID,
                    InsurerID = detail.InsurerID,
                    ConsumerID = detail.ConsumerID,
                    ComplaintDesc = detail.ComplaintDesc,
                    Resolved = detail.Resolved,
                    DateSubmitted = detail.DateSubmitted,
                    DateCompleted = detail.DateCompleted
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ComplaintEdit(int id, ComplaintEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ComplaintID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var svc = new ComplaintService();

            if (svc.UpdateComplaint(model))
            {
                TempData["SaveResult"] = "The Complaint was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The Complaint could not be updated");
            return View(model);
        }
        [ActionName("ComplaintDelete")]
        public ActionResult ComplaintDelete(int id)
        {
            var svc = new ComplaintService();
            var model = svc.GetComplaintByID(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("ComplaintDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteComplaint(int id)
        {
            var service = new ComplaintService();

            service.DeleteComplaint(id);

            TempData["Save Result"] = ("The Complaint was removed");
            return RedirectToAction("Index");
        }
    }
}