using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO_S.Vendas
{
    public class CreateVendaDTO
    {
        public int Id { get; set; }
        public double PrecoVenda { get; set; }
        public DateTime DataVenda { get; set; }
        public int ClienteId { get; set; }
        public List<int> produtosids { get; set; } = new List<int>();
    }
}
