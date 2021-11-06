using Business.Interfaces.Services;
using Data.DTO_S.Produtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompleteApiMarceloCatalog.Controllers
{
    [ApiController]
    [Authorize]
    [Route("v1/produtos")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _service;

        public ProdutoController(IProdutoService service)
        {
            _service = service;
        }


        [HttpGet("ObterProdutos")]
        public async Task<ActionResult<List<ReadProdutoDTO>>> GetProdutos()
        {
            var produtos = await _service.ObterProdutos();
            if(produtos == null)
            {
                return NotFound("Lista de produtos vazia");
            }
            return produtos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadProdutoDTO>> ObterProdutoId(int id)
        {
            var produto = await _service.ObterProduto(id);
            if(produto == null)
            {
                return NotFound("Produto não encontrado");
            }
            return produto;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> AtualiarProduto(int id, [FromBody] UpdateProduto updateProduto)
        {
            try
            {
                var resultadoAtualizarProduto = await _service.atualizarProduto(id, updateProduto);
                if (resultadoAtualizarProduto == null)
                {
                    return NotFound("este produto não existe no banco de dados");
                }
                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(500, "Banco de dados falhou ao atualizar produto");
            }
          
        }

        [HttpPost("CriarProduto")]
        public async Task<ActionResult> CriarProduto([FromBody] CreateProdutoDTO produtoDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                await _service.criarProduto(produtoDTO);
                return Created("Produto criado com sucesso", produtoDTO);
            }
            catch (Exception)
            {

                return StatusCode(500, "Banco de dados falhou");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletarProduto(int id)
        {
            try
            {
                var resultDeleteProduto = await _service.excluirProduto(id);
                if(resultDeleteProduto == null)
                {
                    return NotFound("Este produto não existe no banco de dados");
                }
                return NoContent();

            }
            catch (Exception)
            {

                return StatusCode(500, "Banco de dados falhou ao criar produto");
            }

        }

    }
}
