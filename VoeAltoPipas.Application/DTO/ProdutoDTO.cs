using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoeAltoPipas.Application.DTO
{
    public class ProdutoDTO
    {
            
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Descricao { get; set; }
        public IFormFile Imagem { get; set; }

        public string? ImagemUrl { get; set; }

    }
}
