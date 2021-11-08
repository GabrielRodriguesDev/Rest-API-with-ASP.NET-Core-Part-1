using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest_API_with_ASP.NET_Core_Part_1.Models
{
    public class Produto

    {


        public Produto()
        {
            this.Id = Guid.NewGuid(); // Gerando um ID automatico ao criar um objeto da classe, assim ao mandar um POST referente a essa classe, não é necessário mandar o ID na requisição o próprio sistema cuida de gerar
        }
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }
    }
}
