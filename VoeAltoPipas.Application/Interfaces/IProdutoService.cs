using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoeAltoPipas.Application.DTO;

namespace VoeAltoPipas.Application.Interfaces
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoDTO>> GetAllAsync();
        Task<ProdutoDTO> GetByIdAsync(int id);
        Task AddAsync(ProdutoDTO produto);
        Task UpdateAsync(int id, ProdutoDTO produto);
        Task DeleteAsync(int id);
    }
}
