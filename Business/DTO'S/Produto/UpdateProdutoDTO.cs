using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO_S.Produtos
{
    public class UpdateProduto
    {

        public string Nome { get; set; }
        public double Preco { get; set; }
        public int CategoriaId { get; set; }

    }
}
