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
            var model = new AgentListItem[0];
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

            service.CreateAgent(model);
            return RedirectToAction("Index");
        }
    }
}