using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO_S.Vendas
{
    public class ReadVendaDTO
    {
        public int Id { get; set; }
        public double PrecoVenda { get; set; }
        public DateTime DataVenda { get; set; }
        public List<Produto> Produtos { get; set; } = new List<Produto>();
        public Cliente Cliente { get; set; }
    }
}
