using Business.DTO_S.Vendas;
using Business.Interfaces.Services;
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
    [Route("v1/vendas")]
    public class VendaController : ControllerBase
    {
        private readonly IVendaService _service;

        public VendaController(IVendaService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> AddVenda([FromBody] CreateVendaDTO vendaDTO)
        {
            try
            {
                await _service.AdicionarVenda(vendaDTO);
                return Created("Venda criada", vendaDTO);
            }
            catch (Exception e)
            {

                return StatusCode(500, e);
            }
        }

        [HttpGet]

        public async Task<ActionResult<List<ReadVendaDTO>>> getVendas()
        {
            var vendas = await _service.getVendas();
            if(vendas.Count == 0)
            {
                return NotFound("Lista de vendas vazia");
            }
            return vendas;
        }
    }
}
