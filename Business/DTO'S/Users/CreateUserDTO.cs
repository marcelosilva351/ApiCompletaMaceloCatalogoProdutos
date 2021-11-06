using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO_S.Users
{
    public class CreateUserDTO
    {
        [Required]
        [MinLength(5)]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }

        [MinLength(6, ErrorMessage ="Senha no minimo com 6 caracteres")]
        public string Senha { get; set; }
        [Required]
        [Compare("Senha", ErrorMessage ="Senhao não são iguais")]
        public string CompararSenha { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
