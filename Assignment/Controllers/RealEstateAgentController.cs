using Assignment.Manager.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Assignment.Controllers
{
    public class RealEstateAgentController : Controller
    {
        private IRealEstateAgentManager realEstateAgentManager;
        public RealEstateAgentController(IRealEstateAgentManager realEstateAgentManager)
        {
            this.realEstateAgentManager = realEstateAgentManager;
           
        }
        // GET: RealEstateAgent
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> GetRealEstateAgentsJson(int top, string city,string type,bool hasGarden, bool isForSale)
        {
            var result = await realEstateAgentManager.GetTopRealEstateAgentsByFilter(1, "Amsterdam", true, true);
            return Json(result);
        }

        [HttpPost]
        public async Task<ActionResult> GetRealEstateAgents(int top, string city, string type, bool hasGarden, bool isForSale)
        {
            var result = await realEstateAgentManager.GetTopRealEstateAgentsByFilter(top, city,isForSale,hasGarden);
            return PartialView("_Agents", result);
        }

        // GET: RealEstateAgent/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RealEstateAgent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RealEstateAgent/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RealEstateAgent/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RealEstateAgent/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RealEstateAgent/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RealEstateAgent/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}