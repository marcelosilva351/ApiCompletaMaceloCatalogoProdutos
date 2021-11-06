using AutoMapper;
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
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _Repository;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepository repository, IMapper mapper)
        {
            _Repository = repository;
            _mapper = mapper;
        }

        public async Task<Produto> atualizarProduto(int id,UpdateProduto produtoDTO)
        {
            var Produto = await _Repository.GetById(id);
            if(Produto == null)
            {
                return null;
            }
            var produtoAtualizar = _mapper.Map(produtoDTO, Produto);

           
            await _Repository.Update(produtoAtualizar);
            return Produto;
        }

        public async Task criarProduto(CreateProdutoDTO produtoDTO)
        {
            var ProdutoAdd = _mapper.Map<Produto>(produtoDTO);
            try
            {
               await _Repository.Create(ProdutoAdd);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Produto> excluirProduto(int id)
        {
            var produtoRemove = await _Repository.produtoById(id);
            if(produtoRemove == null)
            {
                return null;
            }
            try
            {
                await _Repository.Delete(produtoRemove);
                return produtoRemove;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task<ReadProdutoDTO> ObterProduto(int id)
        {
            var produto = await _Repository.produtoById(id);
            var produtoReturn = _mapper.Map<ReadProdutoDTO>(id);
            return produtoReturn;
        
        }

        public async Task<List<ReadProdutoDTO>> ObterProdutos()
        {
            var produtos = await  _Repository.GetProdutos();
            return produtos;
        }
    }
}
