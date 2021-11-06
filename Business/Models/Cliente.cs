using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public List<Venda> Vendas { get; set; } = new List<Venda>();
        public Endereco Endereco { get; set; }
        public int EnderecoID { get; set; }
    }
}
