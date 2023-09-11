using Chapter.Models;
using Microsoft.EntityFrameworkCore;

namespace Chapter.Contexts
{
    public class ChapterContext : DbContext //herda do DbContext do banco de dados da estençao noget que foi baixada

    {
        public ChapterContext() { } //contrutor

        public ChapterContext(DbContextOptions<ChapterContext> options) : base(options) { }

        //Vamos utilizar esse metoddo para configurar o banco de dados
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) 

            {
                //cada provedor tem sua sintaxe para especificação
                // PEDRO\\SQLEXPRESS => fonte de dados copiado do banco sqlserver que é o data source
                //catalog = Chapter2=> o nome do banco 
                //Integrated Security = true => é a segurança do banco para que usar a segurança do windows para logar no sql server
                //quen nao usa a segurança do windows usar o usuario e senha. user id = seu user; password = sua senha
      
                optionsBuilder.UseSqlServer("Data Source = PEDRO\\SQLSERVER2022; initial catalog = Chapter2 ; Integrated Security = true ; TrustServerCertificate = True");
            
            }
           

        }

        // dbset representa as entidades que serao utilizadas nas operaçoes de leitura, criaçao, atualização e deleçao
        public DbSet<Livro> Livros { get; set; } //A classe livro pega as informações da tabela Livros no banco de dados. Linka a tabela com a classe da API
        public DbSet<Usuario> Usuarios { get; set; }//carrega a tabela usuario
    }
    
    
}
