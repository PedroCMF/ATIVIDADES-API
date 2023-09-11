using Chapter.Models;

namespace Chapter.Interfacies
{
    public interface IUsuarioRepository
    {
        //Obrigatoriedade das propriedades da iinterface 
        List<Usuario> Listar();    //assinatura do metodo. Obs: nao tem o corpo do metodo
        Usuario BuscarPorId(int id);
        void Cadastrar(Usuario usuario);
        void Atualizar(int id, Usuario usuario);
        void Deletar(int id);
        Usuario Login(string email, string senha);

    }
}
