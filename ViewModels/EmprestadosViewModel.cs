using BibliotecaLetsCode.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaLetsCode.ViewModels
{
    public class EmprestadosViewModel
    {
        [DisplayName("Digite o Nome para Busca")]
        public string Search { get; set; }

        public IEnumerable<Emprestimo> Emprestados { get; set; }
    }
}
