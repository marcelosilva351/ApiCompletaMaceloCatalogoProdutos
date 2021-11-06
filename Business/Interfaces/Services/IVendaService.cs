using Business.DTO_S.Vendas;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Services
{
    public interface IVendaService
    {
        Task AdicionarVenda(CreateVendaDTO venda);
        Task<List<ReadVendaDTO>> getVendas();

    }
}
