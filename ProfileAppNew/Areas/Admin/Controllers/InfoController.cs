using Microsoft.AspNetCore.Mvc;
using ProfileAppNew.Models;
using ProfileAppNew.Repository;

namespace ProfileAppNew.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InfoController : Controller
    {
        private readonly IinfoRepo repo;

        public InfoController(IinfoRepo repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            return View(repo.GetAllInformation());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Create( Information information ,List<IFormFile> Files)
        {
            if(ModelState.IsValid)
            {
                foreach (var file in Files)
                {
                    if (file.Length > 0)
                    {
                        string image = Guid.NewGuid().ToString() + ".jpg";
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", image);
                        using (var stream = System.IO.File.Create(filePath))
                        {
                            await file.CopyToAsync(stream);
                        }
                        information.Image = image;
                    }
                }
                
                repo.Add(information);
                return RedirectToAction("Index");
            }
            else
            {

                return View(information);

            }

        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                return View(repo.GetById(Convert.ToInt32(id)));
                
            }
            else
            {
                return View();
            }

           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Information information, List<IFormFile> Files)
        {
            if (ModelState.IsValid)
            {
                foreach (var file in Files)
                {
                    if (file.Length > 0)
                    {
                        string image = Guid.NewGuid().ToString() + ".jpg";
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", image);
                        using (var stream = System.IO.File.Create(filePath))
                        {
                            await file.CopyToAsync(stream);
                        }
                        information.Image = image;
                    }
                }

                repo.Update(information);
                return RedirectToAction("Index");
            }
            else
            {

                return View(information);

            }

        }

        public IActionResult Delete(int id)
        {

            return View(repo.GetById(id));
        }
        [HttpPost]
        public IActionResult Delete(Information info)
        {
            repo.Delete(info);
            return RedirectToAction(nameof(Index));
        }

    }
}
