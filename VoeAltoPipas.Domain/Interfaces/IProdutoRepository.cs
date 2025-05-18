using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoeAltoPipas.Domain.Entities;

namespace VoeAltoPipas.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produtos>> GetAllAsync();
        Task<Produtos> GetByIdAsync(int id);
        Task AddAsync(Produtos produto);
        Task UpdateAsync(Produtos produto);
        Task DeleteAsync(int id);
    }
}
