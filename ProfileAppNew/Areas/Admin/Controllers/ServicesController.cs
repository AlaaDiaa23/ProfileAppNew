using Microsoft.AspNetCore.Mvc;
using ProfileAppNew.Models;
using ProfileAppNew.Repository;

namespace ProfileAppNew.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServicesController : Controller
    {
        private readonly IServicesRepo repo;

        public ServicesController(IServicesRepo repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            return View(repo.GetServices());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Service service)
        {
            if (ModelState.IsValid)
            {
                repo.AddService(service);
                return RedirectToAction(nameof(Index));

            }
            else
            {

                return View(service);
            }
        }
        public IActionResult Edit(int? id)
        {
            var item=repo.GetServiceById(Convert.ToInt32(id));
            if (item != null)
            {
                return View(item);
            }
            else
            {
                return View();
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Service service)
        {
            if (ModelState.IsValid)
            {
                repo.UpdateService(service);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(service);
            }
        }
        public IActionResult Delete(int id)
        {
            var item = repo.GetServiceById(id);
            if (item != null)
            {
                repo.RemoveService(item);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(item);
            }
        }

    }
}
