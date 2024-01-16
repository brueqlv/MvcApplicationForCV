using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcApplicationForCV.Models;

namespace MvcApplicationForCV.Controllers
{
    public class CVController : Controller
    {
        private CvDataService _cvDataService;

        public CVController(CvDataService cvDataService)
        {
            _cvDataService = cvDataService;
        }

        public ActionResult Index()
        {
            List<CV> allCVs = _cvDataService.GetAllCVs();
            return View(allCVs);
        }

        // GET: CVController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CVController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CVController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CVController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CVController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CVController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CVController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
