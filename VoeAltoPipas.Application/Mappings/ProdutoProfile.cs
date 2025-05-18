using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoeAltoPipas.Application.DTO;
using VoeAltoPipas.Domain.Entities;

namespace VoeAltoPipas.Application.Mappings
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<Produtos, ProdutoDTO>().ReverseMap();
        }
    }
}
