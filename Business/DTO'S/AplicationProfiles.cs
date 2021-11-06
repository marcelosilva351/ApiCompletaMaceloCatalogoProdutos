using AutoMapper;
using Business.DTO_S.Categoria;
using Business.DTO_S.Clientes;
using Business.DTO_S.Vendas;
using Business.Models;
using Data.DTO_S.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO_S
{
   public class AplicationProfiles : Profile
    {
        public AplicationProfiles()
        {
            //Produto
            CreateMap<List<Produto>, List<ReadProdutoDTO>>();
            CreateMap<Produto, ReadProdutoDTO>();
            CreateMap<CreateProdutoDTO, Produto>();
            CreateMap<UpdateProduto, Produto>();
            CreateMap<List<ReadProdutoDTO>, List<Produto>>();
            CreateMap<ReadProdutoDTO, Produto>();

            //Categoria
            CreateMap<List<Categoria>, List<ReadCategoriaDTO>>();
            CreateMap<CreateCategoriaDTO, Categoria>();

            //Cliente
            CreateMap<CreateClienteDTO, Cliente>();

            //Venda
            CreateMap<CreateVendaDTO, Venda>();
        }
    }

}
