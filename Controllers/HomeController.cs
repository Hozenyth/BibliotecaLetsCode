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

        // GET: Emprestar/Create
        public IActionResult Emprestar()
        {
            ViewData["LivroId"] = new SelectList(_context.Livros, "Id", "Nome");
            return View();
        }

        // POST: Emprestar/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Emprestar([Bind("Id, Nome, Telefone, Confirmado, LivroId")] Emprestimo emprestimo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emprestimo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Emprestimos, "Id", "Nome", emprestimo.LivroId);
            return View(emprestimo);
        }

        public IActionResult Emprestados()
        {
            var viewModel = new EmprestadosViewModel()
            {
                Emprestados = _context.Emprestimos,
                Search = string.Empty
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Emprestados(EmprestadosViewModel viewModel)
        {
            viewModel.Emprestados = _context.Emprestimos;

            return View(viewModel);
        }

        public IActionResult Editar(int id)
        {
            var editando = _context.Emprestimos.FirstOrDefault(x => x.Id == id);
            if (editando == null)
                return RedirectToAction("Emprestados");

            return View(editando);
        }

        [HttpPost]
        public IActionResult Editar(Emprestimo emprestimo)
        {
            _context.Update(emprestimo);

            return RedirectToAction("Emprestados");
        }





    }
}
