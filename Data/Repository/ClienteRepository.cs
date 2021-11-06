using Business.Interfaces.Repositories;
using Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(AplicationContext context) : base(context)
        {
        }

        public async Task AdicionarVendaCliente(int idcliente, int idVenda)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == idcliente);
            var venda = await _context.Vendas.FirstOrDefaultAsync(v => v.Id == idVenda);

            cliente.Vendas.Add(venda);
            await Update(cliente);
        }
    }
}
