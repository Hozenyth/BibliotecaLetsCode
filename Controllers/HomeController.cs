using BibliotecaLetsCode.Models;
using BibliotecaLetsCode.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
       
        private readonly Context _context;


        public HomeController(ILogger<HomeController> logger, IRepositorio repositorio, Context context)
        {
            _logger = logger;
            _repositorio = repositorio;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            

            var context = _context.Emprestimos.Include(p => p.Livro);
            return View(await context.ToListAsync());
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

        public IActionResult Emprestados()
        {
            var viewModel = new EmprestadosViewModel()
            {
                Emprestados = _repositorio.Emprestimos,
                Search = string.Empty
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Confirmados(EmprestadosViewModel viewModel)
        {
           // viewModel.Confirmados = _repositorio.Confirmacoes;

            return View(viewModel);
        }



    }
}
