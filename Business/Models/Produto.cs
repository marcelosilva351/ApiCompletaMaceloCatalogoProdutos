using System.Collections.Generic;

namespace Business.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public List<VendaProdutos> Vendas { get; set; } = new List<VendaProdutos>();
    }
}