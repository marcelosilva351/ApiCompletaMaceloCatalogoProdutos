namespace Business.Models
{
    public class Endereco
    {
        public int Id { get; set; }
        public string Quadra { get; set; }
        public string Lote { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public Cliente Cliente { get; set; }
    }
}