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
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(AplicationContext context) : base(context)
        {
        }

        public Task<List<Categoria>> GetCategoriasInclude()
        {
            return _context.Categorias.Include(p => p.Produtos).ToListAsync();
        }

        public Task<List<Produto>> GetProdutosDaCategoria(int id)
        {
            return _context.Produtos.Include(c => c.Categoria).Where(c => c.CategoriaId == id).ToListAsync();
        }
    }
}
