using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaLetsCode.Models
{
    public class Repositorio : IRepositorio
    {
        private readonly Context _context;

        public Repositorio(Context context)
        {
            _context = context;
        }

        public IQueryable<Emprestimo> Emprestimos { get => _context.Emprestimos; }

        public void AdicionaEmprestimo(Emprestimo emprestimo)
        {

            _context.Emprestimos.Add(emprestimo);

            if (string.IsNullOrEmpty(emprestimo.Nome))
                emprestimo.Nome = "Sem Nome";

            _context.SaveChanges();
        }

        public void Update(Emprestimo emprestimo)
        {
            _context.Emprestimos.Update(emprestimo);
            _context.SaveChanges();
        }

        public void Remove(Emprestimo emprestimo)
        {
            _context.Emprestimos.Remove(emprestimo);
            _context.SaveChanges();
        }
    }
}
