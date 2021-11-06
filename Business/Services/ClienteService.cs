using Business.DTO_S.Clientes;
using Business.Interfaces.Repositories;
using Business.Interfaces.Services;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task AdicionarCliente(Cliente clienteADD)
        {
            await _repository.Create(clienteADD);
        }

        public async Task AdicionarVendaCliente(int idcliente, int idVenda)
        {
            await _repository.AdicionarVendaCliente(idcliente, idVenda);
        }
    }
}
