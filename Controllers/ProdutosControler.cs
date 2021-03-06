using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rest_API_with_ASP.NET_Core_Part_1.Data;
using Rest_API_with_ASP.NET_Core_Part_1.Models;

namespace Rest_API_with_ASP.NET_Core_Part_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutosControler : ControllerBase
    {

        private ApplicationDbContext _database;
        public ProdutosControler(ApplicationDbContext database)
        {
            this._database = database;
        }

        [HttpGet]
        public  IActionResult getProdutos(){
            var produtos = this._database.Produtos.ToList(); // Recuperando do BD a lista todos os registros da tabela (Entidade) Produtos
            Response.StatusCode  = 200;

            return new JsonResult(produtos); // Retornando a lista com todos os produtos.
        }


        [HttpGet ("{id}")]
        public IActionResult getProduto(Guid id){
            try
            {
                var produto = this._database.Produtos.First(produto => produto.Id == id);
                Response.StatusCode  = 200;
                return new JsonResult(produto);
            }
            catch (System.Exception)
            {
                Response.StatusCode  = 404;
                return new JsonResult(new {menssage="Teste"});
            }
        }

        [HttpPost] 
        public IActionResult postProduto([FromBody] Produto produto) {  
            /* 
            Action que recebe a requisição através do verbo "POST",
            Nela estamos usando o decorador "[FromBody]" nos parametros,
            que significa que queremos receber dados do Body da requisição como parametro,
            ao lado do [FromBody] estamos tipando esses dados,
            passando o tipo "ProdutoTemp" (uma classe),
            portanto os dados passados no json tem que ser ou atender os atributos da classe ProdutoTemp,
            ao receber os dados o ASP.NET consegue validar se os dados de fato são referente a classe (tipagem),
            caso seja ele transforma os dados passados em um objeto da classe manipulavel,
            caso não seja ele retorna o erro (o retorno do erro é devido ao decorator na classe do controler [apiControler])
             */
            try
            {
                this._database.Add(produto); // Salvando o registro (Objeto recebido no parametro (corpo da requisição)) no Banco de Dados
                this._database.SaveChanges(); // Commitando insert
                Response.StatusCode = 201;
                return new JsonResult(new {menssage="Produto criado com sucesso: " + produto.Id}); // Retornando a mensagem após salvar o registro.
            }
            catch (System.Exception)
            {
                Response.StatusCode = 404;
                return new ObjectResult("");
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id){
            try{
                Produto produto = this._database.Produtos.First(produto => produto.Id == id);
                this._database.Produtos.Remove(produto);
                this._database.SaveChanges();
                return new JsonResult(new {menssage="Produto removido com sucesso: " + produto.Id});
            }catch(Exception e){
                Response.StatusCode = 404;
                return new ObjectResult("");
            }
        }
    }
}