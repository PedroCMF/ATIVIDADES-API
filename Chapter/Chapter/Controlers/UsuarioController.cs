using Chapter.Interfacies;
using Chapter.Models;
using Chapter.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Chapter.Controlers
{

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]


    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioRepository _IusuarioRepository; //Variavel _IusuarioRepository declarada do tipo IUsuarioRepository 

        public UsuarioController(IUsuarioRepository usuarioRepository)//contrutor poque nao tem retorno. Tem mesmo nome da classe(UsuarioController). Depois do public não tem tipo de retorno(void, string, list, void). Tendo estes retornos é um metodo. O metodo nunca terá o nome igual o da classe
        { 
            _IusuarioRepository = usuarioRepository;
                
        }

        //PESQUISA
        [HttpGet]
        public IActionResult Listar() //Implementando o metodo Listar(com corpo) que foi definido na interface IUsuarioRepository somente com assinatura     
        {
            try
            {
                //Carrega os usuarios
                return Ok(_IusuarioRepository.Listar()); //responde OK e o usuario

            }

            catch (Exception) //tratamento do erro

            {
                throw;
            }

        }

        //PESQUISA GET
        [HttpGet("{id}")] //Digita o Id
        
            public IActionResult BuscaPorId(int id)
            {
                try

                {
                    Usuario usuario = _IusuarioRepository.BuscarPorId(id); //instancia a classe livro para receber o id

                    if (usuario == null) //se o objeto livro nao estiver nada retorna NotFound
                    {
                        return NotFound();
                    }

                    return Ok(usuario); //responde OK e o livro

                }

                catch (Exception) //tratamento do erro
                {
                    throw;
                }

            }
         
        //CADASTRAR POST
        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario) 

        {
            try

            {
                 _IusuarioRepository.Cadastrar(usuario);

                return StatusCode(201);
               
            }

            catch (Exception) //tratamento do erro
            {
                throw;
            }

        }

        //ATUALIZAR PUT
        [HttpPut("{id}")] //Digit o id para aletrar o usuario
        public IActionResult Alterar(int id, Usuario usuario)
        {
            try

            {
                _IusuarioRepository.Atualizar(id, usuario);

                return Ok("Usuario Alterado");

            }

            catch (Exception) //tratamento do erro
            {
                throw;
            }

        }

        //Deleta o usuario pelo Id
        [HttpDelete("id")]
        public IActionResult Delete(int id) 
        {

            try

            {
                _IusuarioRepository.Deletar(id); //ira passa o livro por parametro

                return StatusCode(204); //responde OK e o livro

            }

            catch (Exception) //tratamento do erro

            {
                throw;
            }


        }
    }
}
