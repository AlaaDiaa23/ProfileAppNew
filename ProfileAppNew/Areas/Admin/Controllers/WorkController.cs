using Microsoft.AspNetCore.Mvc;
using ProfileAppNew.Models;
using ProfileAppNew.Repository;

namespace ProfileAppNew.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WorkController : Controller
    {
        private readonly IWorkRepo workRepo;

        public WorkController(IWorkRepo workRepo)
        {
            this.workRepo = workRepo;
        }
        public IActionResult Index()
        {
            return View(workRepo.GetWorks());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create(Work work,List<IFormFile>Files)
        {
            if (ModelState.IsValid)
            {
                foreach (var file in Files)
                {
                    if (file.Length > 0)
                    {
                        string image = Guid.NewGuid().ToString() + ".jpg";
                        var FilePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\WorkUploads", image);
                        using (var stream = System.IO.File.Create(FilePath))
                        {
                            await file.CopyToAsync(stream);
                        }
                        work.Image = image;

                    }
                }

                workRepo.Add(work);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(work);
            }
         
        }

        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                return View(workRepo.GetWorkById(Convert.ToInt32(id)));

            }
            else
            {
                return View();
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Work work, List<IFormFile> Files)
        {
            if (ModelState.IsValid)
            {
                foreach (var file in Files)
                {
                    if (file.Length > 0)
                    {
                        string image = Guid.NewGuid().ToString() + ".jpg";
                        var FilePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\WorkUploads", image);
                        using (var stream = System.IO.File.Create(FilePath))
                        {
                            await file.CopyToAsync(stream);
                        }
                        work.Image = image;

                    }
                }

                workRepo.Update(work);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(work);
            }

        }
        public IActionResult Delete(int id)
        {
            var item = workRepo.GetWorkById(id);
            if (item != null)
            {
                workRepo.Delete(item);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(item);
            }
        }

    }
}


