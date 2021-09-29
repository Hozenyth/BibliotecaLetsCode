using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaLetsCode.Models
{
    public class Context :DbContext
    {
        public DbSet<Categoria> Categorias { get; set; } //Uma tabela chamada Categorias

        public DbSet<Livro> Livros { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //Método responsável por configurar o Entity Framework
        {
            optionsBuilder.UseSqlServer(@"Server= localhost\SQLEXPRESS01;Database=BibliotecaLetsCode;Trusted_Connection=True;");// coloca a string de conexão. 
        }

        public void SetModified(Categoria categoria)
        {
            throw new NotImplementedException();
        }
    }
}
