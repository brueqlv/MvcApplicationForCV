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
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Index()
        {
            List<CV> allCVs = _cvDataService.GetAllCVs();
            return View(allCVs);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CV model)
        {
            _cvDataService.AddCV(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            CV cv = await _cvDataService.GetCVFromIdAsync(id);
            return View(cv);
        }

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

        public ActionResult Delete(int id)
        {
            _cvDataService.DeleteCV(id);
            return RedirectToAction("Index");
        }
    }
}