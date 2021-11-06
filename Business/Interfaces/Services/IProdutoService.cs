using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Models;
using Data.DTO_S.Produtos;

namespace Business.Interfaces.Services
{
    public interface IProdutoService
    {
        Task criarProduto(CreateProdutoDTO produtoDTO);

        Task<Produto> atualizarProduto(int id,UpdateProduto produtoDTO);

        Task<Produto> excluirProduto(int id);

        Task<List<ReadProdutoDTO>> ObterProdutos();
        Task<ReadProdutoDTO> ObterProduto(int id);



    }
}
