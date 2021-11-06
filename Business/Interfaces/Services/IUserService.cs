using Business.DTO_S.Users;
using Business.Interfaces.Services;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Services
{
    public interface IUserService
    {
         Task<IdentityResult> CadastrarUsuario(CreateUserDTO createUser);
         Task<UserToken> Login(LoginUser loginUser);
         string generateToken(LoginUser loginUser);

    }
}
