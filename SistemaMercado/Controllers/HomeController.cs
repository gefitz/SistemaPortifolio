using MercadoFitz.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaMercado.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //Define uma instância de IHostingEnvironment       
        private IHostingEnvironment _appEnvironment;

        //Injeta a instância no construtor para poder usar os recursos

        public HomeController(ILogger<HomeController> logger, IHostingEnvironment env)
        {
            _logger = logger;
            _appEnvironment = env;
        }

        public IActionResult Index()
        {
            return View();
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
