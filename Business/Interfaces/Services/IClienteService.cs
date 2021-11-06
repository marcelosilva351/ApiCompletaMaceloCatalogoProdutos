using Business.DTO_S.Clientes;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Services
{
    public interface  IClienteService
    {
        Task AdicionarCliente(Cliente clienteADD);
        Task AdicionarVendaCliente(int idcliente, int idVenda);

    }
}
