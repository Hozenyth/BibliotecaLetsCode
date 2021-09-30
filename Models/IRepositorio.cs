using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaLetsCode.Models
{
   public interface IRepositorio
    {
        IQueryable<Emprestimo> Emprestimos { get; }
        void AdicionaEmprestimo(Emprestimo emprestimo);
        void Update(Emprestimo emprestimo);
        void Remove(Emprestimo emprestimo);
    }
}
