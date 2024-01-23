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

        public ActionResult Show()
        {
            List<CV> allCVs = _cvDataService.GetAllCVs();
            return View(allCVs);
        }

        public async Task<IActionResult> Details(int id)
        {
            CV? cv = await _cvDataService.GetCVByIdAsync(id);
            return View(cv);
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
            return RedirectToAction("Show");
        }

        public async Task<IActionResult> Edit(int id)
        {
            CV? cv = await _cvDataService.GetCVByIdAsync(id);
            return View(cv);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CV model)
        {
            try
            {
                await _cvDataService.EditCV(id, model);
                return RedirectToAction("Show");
            }
            catch
            {
                return View(model);
            }
        }

        public ActionResult Delete(int id)
        {
            _cvDataService.DeleteCV(id);
            return RedirectToAction("Show");
        }
    }
}