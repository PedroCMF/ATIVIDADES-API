using Chapter.Contexts;
using Chapter.Models;

namespace Chapter.Repositories
{
    //CLASSE PARA CRIAR METODOS
    //depois que foi feita a classe chapterContext, faz se a classe LivroRepository para fazer os metodos que vou usar na classe controlers
    public class LivroRepository

    {
        //Chama o contexto e faz uma instancia para trabalhar com o que vier do banco de dados
        //o banco de dados passou para Context depois para Repository
        private readonly ChapterContext _context;

        public LivroRepository(ChapterContext context) 
        {
            _context = context;  //_context recebe o contexto do parametro passado
        }

        //metodo que retorna o contexto do banco
        public List<Models.Livro> Listar()

        {
            return _context.Livros.ToList();
        }


        //PESQUISA
        public Livro BuscarPorId(int id) 
        {
        return _context.Livros.Find(id); //pega o id no banco na tabela L ivros
        }


        //CADASTRO
        public void Cadastrar(Livro livro) //cadastrar o livro que recebe como parametro do json
        { 
            _context.Livros.Add(livro); //Adiciona o livro
            _context.SaveChanges(); //salva a alteraçao
        }

        //ATUALIZAÇÃO
        public void Atualizar(int id, Livro livro)  //o id=> que irá ser atualizado, livro=> as mudança que irá fazer no livro
        {
            Livro livroBuscado = _context.Livros.Find(id);  //pega as informações do banco

            if (livroBuscado != null) // se for diferete de nullo 
            {
                //passa as informaçoes do livro para a variavel livroBuscado
                livroBuscado.Titulo = livro.Titulo;
                livroBuscado.QuantidadePaginas = livro.QuantidadePaginas;
                livroBuscado.Disponivel = livro.Disponivel;
            }

            _context.Livros.Update(livroBuscado); //atualiza as informaçoes do livro
            _context.SaveChanges(); //salva as informaçõpes do livro
        }

        //DELETA
        public void Deletar(int id)
        {

            Livro livro = _context.Livros.Find(id); //deleta o livro pelo id
            _context.Livros.Remove(livro); //remove o liovro selecionado
            _context.SaveChanges();
            
        }

    }

}
