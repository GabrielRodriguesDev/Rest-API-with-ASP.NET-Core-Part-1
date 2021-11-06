using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest_API_with_ASP.NET_Core_Part_1.Models
{
    public class Produto

    {
        public int Id { get; set; }
        public int Nome { get; set; }
        public float Preco { get; set; }
    }
}