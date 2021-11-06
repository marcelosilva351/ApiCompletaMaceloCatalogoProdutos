using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public double PrecoVenda { get; set; }
        public DateTime DataVenda { get; set; }
        public List<VendaProdutos> Produtos { get; set; } = new List<VendaProdutos>();
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
    }
}
