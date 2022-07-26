using Microsoft.AspNetCore.Mvc;
using ProfileAppNew.Models;
using ProfileAppNew.Repository;
using System.Diagnostics;

namespace ProfileAppNew.Controllers
{
    public class HomeController : Controller
    {
        private readonly IinfoRepo repo;
        private readonly IAboutRepo aboutRepo;
        private readonly IServicesRepo services;
        private readonly IWorkRepo workRepo;

        public HomeController(IinfoRepo repo,IAboutRepo aboutRepo,IServicesRepo services,IWorkRepo workRepo)
        {
            this.repo = repo;
            this.aboutRepo = aboutRepo;
            this.services = services;
            this.workRepo = workRepo;
        }

        public IActionResult Index()
        {
            ViewModel model = new ViewModel();
            model.Information=repo.GetAllInformation();
            model.Information = model.Information.Take(1);
            model.About = aboutRepo.GetAbouts();
            model.About = model.About.Take(1);
            model.Service = services.GetServices();
            model.Service = model.Service;
            model.Work = workRepo.GetWorks();
            model.Work = model.Work;
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}