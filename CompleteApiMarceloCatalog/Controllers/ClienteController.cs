using AutoMapper;
using Business.DTO_S.Clientes;
using Business.Interfaces.Services;
using Business.Models;
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
    [Route("v1/clientes")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _service;
        private readonly IMapper _mapper;

        public ClienteController(IClienteService service, IMapper mapper)
        {
            _mapper = mapper;

            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> CriarCliente([FromBody] CreateClienteDTO clienteDTO)
        {
            try
            {
                var clienteAdd = _mapper.Map<Cliente>(clienteDTO);
                await  _service.AdicionarCliente(clienteAdd);
                return Created("Cliente criado", clienteAdd);
            }
            catch (Exception)
            {

                return StatusCode(500, "Não foi possivel criar cliente");
            }
         
        }

        [HttpPut("AdicionarVenda/{idcliente}/{idvenda}")]
        public async Task<ActionResult> adicionarVendaCliente(int idcliente, int idvenda)
        {
            try
            {
                await _service.AdicionarVendaCliente(idcliente, idvenda);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}
