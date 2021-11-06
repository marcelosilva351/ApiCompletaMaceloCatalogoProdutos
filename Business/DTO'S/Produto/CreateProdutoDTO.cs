using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO_S.Produtos
{
    public class CreateProdutoDTO
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Nome { get; set; }
        [Required]
        public double Preco { get; set; }
        [Required]
        public int CategoriaId { get; set; }
  
    }
}
