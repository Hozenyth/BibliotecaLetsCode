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
                Emprestados = _context.Emprestimos.Include(x=> x.Livro).Include(x=> x.Nome),
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

        // GET: Livros/Edit/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emprestimo = await _context.Emprestimos.FindAsync(id);
            if (emprestimo == null)
            {
                return NotFound();
            }
            ViewData["LivroId"] = new SelectList(_context.Livros, "Id", "Nome");
            return View(emprestimo);
        }

        // POST: Editar/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("Id, Nome, Telefone, Confirmado, LivroId")] Emprestimo emprestimo)
        {
            if (id != emprestimo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emprestimo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmprestimoExists(emprestimo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["LivroId"] = new SelectList(_context.Emprestimos, "Id", "Nome", emprestimo.LivroId);
            return View(emprestimo);
        }
      
      
        private bool EmprestimoExists(int id)
        {
            return _context.Emprestimos.Any(e => e.Id == id);
        }


        // GET: Deletar/Delete/5
        public async Task<IActionResult> Deletar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emprestimo = await _context.Emprestimos
                .Include(p => p.Livro)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        // POST: Deletar/Delete/5
        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var emprestimo = await _context.Emprestimos.FindAsync(id);
            _context.Emprestimos.Update(emprestimo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



    }
}
