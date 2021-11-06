using Business.DTO_S.Categoria;
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
    [Route("v1/categorias")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _service;

        public CategoriaController(ICategoriaService service)
        {
            _service = service;
        }

        [HttpGet("ObterCategorias")]
        public async Task<ActionResult<List<ReadCategoriaDTO>>> ObterCategorias()
        {
            var categoriasReturn = await _service.ObterCategorias();
            if(categoriasReturn == null)
            {
                return NotFound("Não foram encontradas categoriass cadastradas");
            }
            return categoriasReturn;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<ReadProdutoDTO>>> ObterProdutosDaCategoria(int id)
        {
            var produtosDaCategoria = await _service.ObterProdutosCategoria(id);
            if(produtosDaCategoria == null)
            {
                return NotFound("Não foi encontrado produtos para esta categoria");
            }
            return Ok(produtosDaCategoria);
        }

        [HttpPost("CriarCategoria")]
        public async Task<ActionResult> CriarCategoria([FromBody] CreateCategoriaDTO categoriaDTO)
        {
            try
            {
                if (!ModelState.IsValid) {
                    return BadRequest(ModelState);
                }

                await _service.CriarCategoria(categoriaDTO);
                return Created("Criado com sucesso", categoriaDTO);
            }
            catch (Exception)
            {

                return StatusCode(500, "Banco de dados falhou a criar categoria");
            }
        }
    }
}
