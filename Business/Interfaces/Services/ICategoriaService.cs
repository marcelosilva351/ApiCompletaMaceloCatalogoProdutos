using Business.DTO_S.Categoria;
using Business.Models;
using Data.DTO_S.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Services
{
    public interface ICategoriaService
    {
        Task CriarCategoria(CreateCategoriaDTO categoriaDTO);
        Task<List<ReadProdutoDTO>> ObterProdutosCategoria(int id);
        Task<List<ReadCategoriaDTO>> ObterCategorias();
    }
}
