using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaLetsCode.Models
{
    public class Context : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; } //Uma tabela chamada Categorias

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) // Ja insere dados no banco ao inicar
        {
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria[]
                {
                    new Categoria {Id=1, Descricao= "A",},
                    new Categoria {Id=2, Descricao= "B"},
                     new Categoria {Id=3,  Descricao= "C"}
                }
                );

            modelBuilder.Entity<Livro>().HasData(
               new Livro[]
               {
                    new Livro {Id=1, Nome= "A", Autor ="B", Editora="C", Ano=2021, CategoriaId=1},
                    new Livro {Id=2, Nome= "AB", Autor ="BB", Editora="CB", Ano=2022, CategoriaId=2},
                     new Livro {Id=3, Nome= "AC", Autor ="BC", Editora="CC", Ano=2023, CategoriaId=3}
               }
               );
            base.OnModelCreating(modelBuilder);
        }

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
