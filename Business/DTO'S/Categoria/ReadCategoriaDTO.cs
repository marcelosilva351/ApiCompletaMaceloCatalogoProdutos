using Business.Models;
using Data.DTO_S.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO_S.Categoria
{
    public class ReadCategoriaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<ReadProdutoDTO> Produtos { get; set; } = new List<ReadProdutoDTO>();
    }
}
