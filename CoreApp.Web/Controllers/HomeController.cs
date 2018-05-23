using CoreApp.DataService.Abstraction.Interfaces;
using CoreApp.Web.Controllers.Api;
using CoreApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DTO = CoreApp.Models.DataTransfer;
using VM = CoreApp.Models.ViewModels;

namespace CoreApp.Web.Controllers
{
    public class HomeController : EntityBaseApiController<VM.EmployeeViewModel, DTO.Employee>
    {
        private readonly IEmployeeService _entityService;

        public HomeController(IEmployeeService entityService): base(entityService)
        {
            _entityService = entityService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
