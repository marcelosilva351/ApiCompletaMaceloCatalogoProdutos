using Business.DTO_S.Vendas;
using Business.Interfaces.Repositories;
using Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class VendaRepository : Repository<Venda>, IVendaRepository
    {
        public VendaRepository(AplicationContext context) : base(context)
        {
        }

        public async Task AddVenda(int venda, int produto)
        {
            var VendaProduto = new VendaProdutos
            {
                IdProduto = produto,
                idVenda = venda
            };
             _context.VendaProdutos.Add(VendaProduto);
            await _context.SaveChangesAsync();

        }

        public async Task<List<ReadVendaDTO>> getVendas()
        {
            var vendaQuery =  _context.Vendas.Include(c => c.Cliente).Include(p => p.Produtos).ThenInclude(p => p.Produto).
                Select(p => new ReadVendaDTO
                {
                    Id = p.Id,
                    DataVenda = p.DataVenda,
                    Cliente = p.Cliente,
                    Produtos = p.Produtos.Select(x => x.Produto).ToList().ToList()
                });
            var vendareturn = vendaQuery.ToListAsync().Result;
            return vendareturn;
        }

        public   List<Produto> retornaProdutosDaVenda(List<int> produtosIds)
        {
            var produtos = new List<Produto>();

            foreach (var item in produtosIds)
            {
                var produto = _context.Produtos.Find(item);
                produtos.Add(produto);
            }
            return produtos;
        }
    }
}
