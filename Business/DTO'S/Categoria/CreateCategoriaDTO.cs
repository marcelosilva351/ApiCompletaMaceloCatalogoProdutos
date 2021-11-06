using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO_S.Categoria
{
    public class CreateCategoriaDTO
    {
        [Required]
        public string Nome { get; set; }
    }
}
