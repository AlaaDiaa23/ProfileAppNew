using Microsoft.AspNetCore.Mvc;
using ProfileAppNew.Models;
using ProfileAppNew.Repository;

namespace ProfileAppNew.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly IAboutRepo repo;

        public AboutController(IAboutRepo repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {

            return View(repo.GetAbouts());
        } 
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult >Create(About about,List<IFormFile> Files)
        {
            if(ModelState.IsValid)
            {
                foreach (var file in Files)
                {
                    if (file.Length > 0)
                    {
                        string image = Guid.NewGuid().ToString() + ".jpg";
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\AboutUploads", image);
                        using(var stream = System.IO.File.Create(filePath))
                        {
                            await file.CopyToAsync(stream);

                        }
                        about.Image = image;
                    }
                }


                repo.AddAbout(about);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(about);

            }
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                return View(repo.GetAboutById(Convert.ToInt32(id)));

            }
            else
            {
                return View();
            }


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(About about, List<IFormFile> Files)
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
                        about.Image = image;
                    }
                }

                repo.UpdateAbout(about);
                return RedirectToAction("Index");
            }
            else
            {

                return View(about);

            }

        }
        public IActionResult Delete(int ?id)
        {
            var item=repo.GetAboutById(Convert.ToInt32(id));
            if (item != null)
            {
                repo.DeleteAbout(item);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(item);
            }
        }
    }
}
