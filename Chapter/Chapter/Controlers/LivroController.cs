using Chapter.Models;
using Chapter.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

//CONTROLADOR PARA GERENCIAR OS METODOS DA CLASSE livroRepository
//cria se um controlador para usar oa metodos que foram criados no LivroRepository
namespace Chapter.Controlers 
{
    [Produces("application/json")] //para se comunicar com o json
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly LivroRepository _livroRepository; //cria uma instancia do livrorepository
        public LivroController(LivroRepository livroRepository) //na classe LivroController passa por parametro livroRepository

        {

            _livroRepository = livroRepository; //a classe _livroRepository recebe o parametro livroRepository

        }

        //Metodo Get PESQUISA
        //=============================================================================
        [HttpGet]
        public IActionResult Listar()
        {
            try
            { 
                //carrega os livros
                return Ok(_livroRepository.Listar());
            }

            catch (Exception ex) //tratamento do erro
            {
                throw new Exception(ex.Message);
            }

        }


        //Metodo Get. PESQUISA
        //=============================================================================

        [HttpGet("{id}")] //Faz o metodo Get para pesquisar o livro. Digita o id

        public IActionResult BuscaPorId(int id)
        {
            try

            {
                Livro livro = _livroRepository.BuscarPorId(id); //instancia a classe livro para receber o id

                if (livro == null) //se o objeto livro nao estiver nada retorna NotFound
                {
                    return NotFound();
                }


                return Ok(livro); //responde OK e o livro

            }

            catch (Exception) //tratamento do erro
            {
                throw;
            }

        }

        //Metodo Post do livro. CADASTRO
        //=====================================================================================

        [HttpPost] //Faz o metodo post para cadastrar o livro
        public IActionResult Cadastrar(Livro livro)
        {
            try

            {

                _livroRepository.Cadastrar(livro); //ira passa o livro por parametro

                return StatusCode(201); //responde OK e o livro

            }

            catch (Exception) //tratamento do erro
            {
                throw;
            }

        }

        //Metodo Put. ATUALIZAÇÃO
        //==========================================================================================
        [HttpPut("{id}")] //digita o id
        public IActionResult Atualizar(int id, Livro livro) //int id=> passa o id do livro para ser atualizado. Livro livro=> passa as informaçoes do livro
        {
            try

            {

                _livroRepository.Atualizar(id, livro); //ira passa o livro por parametro

                return StatusCode(204); //responde OK e o livro

            }

            catch (Exception) //tratamento do erro

            {
                throw;
            }
        }


        //Metodo DELETAR
        //=================================================================================================
        [HttpDelete("id")] //digita o id

        public IActionResult Deletar(int id) 
        {

            try

            {

                _livroRepository.Deletar(id); //ira passa o livro por parametro

                return StatusCode(204); //responde OK e o livro

            }

            catch (Exception) //tratamento do erro

            {
                throw;
            }

        }


    }
}
