using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaLetsCode.Models
{
    public class Categoria
    {
        public int Id { get; set; } //Chave primária da tabela no BD


        [Display(Name = "Descrição")]
        [RequiredAttribute(ErrorMessage = "O campo descrição é obrigatório")]




        public string Descricao { get; set; }

    }
}
