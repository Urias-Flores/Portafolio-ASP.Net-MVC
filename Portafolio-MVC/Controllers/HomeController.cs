using Microsoft.AspNetCore.Mvc;
using Portafolio_MVC.Models;
using System.Diagnostics;
using Portafolio_MVC.Services;

namespace Portafolio_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServicesRepository services;
        private readonly ISendGridService sendGridService;

        public HomeController(ILogger<HomeController> logger, IServicesRepository services, ISendGridService sendGridService)
        {
            _logger = logger;
            this.services = services;
            this.sendGridService = sendGridService;
        }


        #region
        //Region principal de controladores
        [HttpGet]
        public IActionResult Index()
        {
            var proyectos = services.getProyects().Take(3).ToList();
            var model = new HomeIndexDTO { Proyects = proyectos };
            return View(model);
        }

        [HttpGet]
        public IActionResult Proyects()
        {
            var proyectos = services.getProyects();
            return View("Proyectos", proyectos);
        }

        [HttpGet]
        public IActionResult Contact() {
            return View("Contacto");
        }

        [HttpPost]
        public async Task<IActionResult> Contact(ContactoDTO contacto)
        {
            await sendGridService.Send(contacto);
            _logger.LogError("Pase por aqui");
            return RedirectToAction("Thanks", contacto);
        }

        [HttpGet]
        public IActionResult Thanks(ContactoDTO contacto) {
            return View("Gracias", contacto);
        }

        #endregion


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}