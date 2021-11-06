﻿using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Repositories
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        public Task AdicionarVendaCliente(int idcliente, int idVenda);
    }
}
