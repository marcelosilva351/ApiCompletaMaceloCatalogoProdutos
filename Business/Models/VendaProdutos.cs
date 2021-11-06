namespace Business.Models
{
    public class VendaProdutos
    {
        public int IdProduto { get; set; }
        public Produto Produto { get; set; }
        public int idVenda { get; set; }
        public Venda vendas { get; set; }
    }
}