using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using VoeAltoPipas.Application.DTO;
using VoeAltoPipas.Application.Interfaces;
using VoeAltoPipas.Domain.Entities;
using VoeAltoPipas.Domain.Interfaces;

namespace VoeAltoPipas.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProdutoDTO>> GetAllAsync()
        {
            var produtos = await _produtoRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);
        }

        public async Task<ProdutoDTO> GetByIdAsync(int id)
        {
            var produto = await _produtoRepository.GetByIdAsync(id);
            return _mapper.Map<ProdutoDTO>(produto);
        }

        public async Task AddAsync(ProdutoDTO produtoDto)
        {
            var produto = _mapper.Map<Produtos>(produtoDto);
            await _produtoRepository.AddAsync(produto);
        }

        public async Task UpdateAsync(int id, ProdutoDTO produtoDto)
        {
            var produto = await _produtoRepository.GetByIdAsync(id);
            if (produto != null)
            {
                _mapper.Map(produtoDto, produto);
                await _produtoRepository.UpdateAsync(produto);
            }
        }

        public async Task DeleteAsync(int id)
        {
            await _produtoRepository.DeleteAsync(id);
        }
    }
}
