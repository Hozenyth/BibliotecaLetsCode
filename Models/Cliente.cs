using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaLetsCode.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Informar o endereço é obrigatório")]
        public string Endereço { get; set; }

        [Required(ErrorMessage = "A idade é obrigatório")]
        public int Idade { get; set; }
       
        [Required(ErrorMessage = "A categoria de livro favorito é obrigatório")]
        public int CategoriaId { get; set; }
        [DisplayName("Categoria favorita")]
        public Categoria Categoria { get; set; }

      
    }
}

