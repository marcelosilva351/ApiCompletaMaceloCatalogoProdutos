using AutoMapper;
using Business.DTO_S.Categoria;
using Business.Interfaces.Repositories;
using Business.Interfaces.Services;
using Business.Models;
using Data.DTO_S.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _Repository;
        private readonly IMapper _mapper;

        public CategoriaService(ICategoriaRepository repository, IMapper mapper)
        {
            _Repository = repository;
            _mapper = mapper;
        }

        public async Task CriarCategoria(CreateCategoriaDTO categoriaDTO)
        {
            try
            {
                var categoriaAdd = _mapper.Map<Categoria>(categoriaDTO);
                await _Repository.Create(categoriaAdd);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<ReadCategoriaDTO>> ObterCategorias()
        {
            var categorias = await _Repository.GetCategoriasInclude();
            var categoriasReturn = _mapper.Map<List<ReadCategoriaDTO>>(categorias);
            return categoriasReturn;
        }

        public async Task<List<ReadProdutoDTO>> ObterProdutosCategoria(int id)
        {
            var produtos = await _Repository.GetProdutosDaCategoria(id);
            var produtosReturn = _mapper.Map<List<ReadProdutoDTO>>(produtos);
            return produtosReturn;
        }
    }
}
