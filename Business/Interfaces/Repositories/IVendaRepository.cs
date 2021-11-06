using Business.DTO_S.Vendas;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Repositories
{
    public interface IVendaRepository : IRepository<Venda>
    {
        Task<List<ReadVendaDTO>> getVendas();
        List<Produto> retornaProdutosDaVenda(List<int> produtos);
        Task AddVenda(int venda, int produto);

    }
}
