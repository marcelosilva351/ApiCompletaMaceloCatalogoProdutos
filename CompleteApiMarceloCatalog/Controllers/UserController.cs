using Business.DTO_S.Users;
using Business.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompleteApiMarceloCatalog.Controllers
{
    [ApiController]
    [Route("v1/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }


        [HttpPost("registrar")]
        public async Task<ActionResult> RegistrarUser([FromBody]CreateUserDTO userCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.CadastrarUsuario(userCreate);
            if (!result.Succeeded)
            {
                return BadRequest("Não foi possivel cadastrar usuario");
            }
            return Created("Usuario criado com sucesso", userCreate);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserToken>> Login([FromBody]LoginUser loginUser)
        {
           var userToken = await _service.Login(loginUser);
           if(userToken == null)
            {
                return NotFound("Usuario não cadastrado");
            }
            return Ok(userToken);
        }
    }

}
