using Lab6StorageCalc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab6StorageCalc.Controllers
{
    public class StorageController : Controller
    {
        public ActionResult Calculate()
        {
            ViewBag.Redundancy = new SelectList(AzureStorage.Redundancy);
            return View(new AzureStorage());
        }

        [HttpPost]
        public ActionResult Calculate(AzureStorage azs)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Confirm", azs); 
            }
            else
            {
                ViewBag.Redundancy = new SelectList(AzureStorage.Redundancy);
                return View();
            }

        }

        public ActionResult Confirm(AzureStorage service)
        {
            return View(service);
        }
    }
}
