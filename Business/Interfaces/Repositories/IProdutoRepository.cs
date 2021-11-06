using Business.Models;
using Data.DTO_S.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Repositories
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<List<ReadProdutoDTO>> GetProdutos();
        Task<Produto> produtoById(int id);
    }
}
