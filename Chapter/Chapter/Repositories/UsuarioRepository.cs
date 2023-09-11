using Chapter.Contexts;
using Chapter.Interfacies;
using Chapter.Models;

namespace Chapter.Repositories
{    //O controller não pode comunicar com o BD
    //O front (controller) comunica com a repository => context => bd
    //IUsuarioRepository devido está chamando uma interface devemos usar todos os atributos da interface IUsuarioRepository
    public class UsuarioRepository : IUsuarioRepository //Entrou no metodo UsuarioRepository para nao acessa o banco direto, por questao de segurança dos dados. Enplementou os metos da  interface IUsuarioRepository
    {
        //metodos
        public readonly ChapterContext _context; //Criando uma variavel de nome _contex do tipo ChapterContext

        public UsuarioRepository(ChapterContext context) //Construtor sem retorno
        {
            _context = context; //A variavel _contex vai receber a contex que é do tipo ChapterContext que nela tem as colunas das tabelas livros e usuario

        }


        //ATUALIZAÇÃO
        public void Atualizar(int id, Usuario usuario)  //A classe Usuario=> é a classe usuario que está em models que irá passa as informações por parametro para a variavel usuario(a variavel usuario pode ser banana). o id=> que foi passado irá ser atualizado, livro=> as mudança que irá fazer no livro
        {
            Usuario usuarioEncontrado = _context.Usuarios.Find(id);  //pega as informações do banco de acordo com o id passado no parametro acima

            if (usuarioEncontrado != null) // se for diferete de nullo 
            {
                usuarioEncontrado.Email = usuario.Email;
                usuarioEncontrado.Senha = usuario.Senha;
                usuarioEncontrado.Tipo = usuario.Tipo;
            }

            _context.Usuarios.Update(usuarioEncontrado); //atualiza as informaçoes do Usuario
            _context.SaveChanges(); //salva as informaçõpes do Usuario
        }

        //PESQUISA
        public Usuario BuscarPorId(int id)
        {
            return _context.Usuarios.Find(id); //pega o id no banco na tabela usuario
        }


        //CADASTRO
        public void Cadastrar(Usuario usuario) //cadastrar o livro que recebe como parametro do json
        {
            _context.Usuarios.Add(usuario); //Adiciona o usuario no banco
            _context.SaveChanges(); //salva a alteraçao
        }

        //metodo Listar que retorna o contexto do banco
        public List<Models.Usuario> Listar()

        {
            return _context.Usuarios.ToList();
        }


        //DELETA
        public void Deletar(int id)
        {

            Usuario usuario = _context.Usuarios.Find(id); //deleta o usuario pelo id
            _context.Usuarios.Remove(usuario); //remove o usuario selecionado
            _context.SaveChanges();

        }

        public Usuario Login(string email, string senha)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Email == email && x.Senha == senha); //verifica email e senha se sao iguais, se forem iguais loga
        }

    }
}
