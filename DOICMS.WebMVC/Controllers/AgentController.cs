using DOICMS.Models;
using DOICMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOICMS.WebMVC.Controllers
{
    public class AgentController : Controller
    {
        [Authorize]
        // GET: Agent
        public ActionResult Index()
        {
            var service = new AgentService();
            var model = service.GetAgents();

            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AgentCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new AgentService();

            if (service.CreateAgent(model))
            {
                TempData["SaveResult"] = "The agent was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "The agent could not be created.");
            return View(model);
        }
        public ActionResult AgentDetails(int id)
        {
            var svc = new AgentService();
            var model = svc.GetAgentByID(id);

            return View(model);
        }
        public ActionResult AgentEdit(int id)
        {
            var svc = new AgentService();
            var detail = svc.GetAgentByID(id);
            var model =
                new AgentEdit
                {
                    AgentID = detail.AgentID,
                    LicenseNumber = detail.LicenseNumber,
                    Name = detail.Name,
                    Email = detail.Email,
                    Address = detail.Address,
                    PhoneNumber = detail.PhoneNumber
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgentEdit(int id, AgentEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.AgentID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var svc = new AgentService();

            if (svc.UpdateAgent(model))
            {
                TempData["SaveResult"] = "The Agent was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The agent could not be updated");
            return View(model);
        }
    }
}