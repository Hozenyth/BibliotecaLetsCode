using BibliotecaLetsCode.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaLetsCode.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorio _repositorio;

        public HomeController(ILogger<HomeController> logger, IRepositorio repositorio)
        {
            _logger = logger;
            _repositorio = repositorio;
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

        public IActionResult Emprestar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Emprestar(Emprestimo emprestimo)
        {

            if (ModelState.IsValid)
            {
                _repositorio.AdicionaEmprestimo(emprestimo);
                return RedirectToAction("Index");
            }

            return View(emprestimo);
        }

    }
}
