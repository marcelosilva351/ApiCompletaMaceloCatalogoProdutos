using Business.Interfaces.Repositories;
using Business.Models;
using Data.DTO_S.Produtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(AplicationContext context) : base(context)
        {
        }

        public async Task<List<ReadProdutoDTO>> GetProdutos()
        {
            var produtos = await _context.Produtos.Include(c => c.Categoria).Select(x => 
            new ReadProdutoDTO { 
            Nome = x.Nome,
            Preco = x.Preco,
            Categoria = x.Categoria.Nome
            }).ToListAsync();
            return produtos;
        }

        public async Task<Produto> produtoById(int id)
        {
            return await  _context.Produtos.Include(c => c.Categoria).FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
