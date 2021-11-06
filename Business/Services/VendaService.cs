using AutoMapper;
using Business.DTO_S.Vendas;
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
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _repository;
        private readonly IMapper _mapper;

        public VendaService(IVendaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AdicionarVenda(CreateVendaDTO venda)
        {
            try
            {
                var vendaAdd = new Venda
                {
                    DataVenda = DateTime.Now,
                    ClienteId = venda.ClienteId
                };
                
                foreach (var item in venda.produtosids)
                {
                    var vendaProduto = new VendaProdutos
                    {
                        IdProduto = item
                    };
                    vendaAdd.Produtos.Add(vendaProduto);
                }
                 await _repository.Create(vendaAdd);
                



            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<List<ReadVendaDTO>> getVendas()
        {
            var vendas = _repository.getVendas();
            return vendas;
        }
    }
}
