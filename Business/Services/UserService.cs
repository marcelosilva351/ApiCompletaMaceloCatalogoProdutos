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

namespace Business.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _usuario;
        private readonly SignInManager<IdentityUser> _login;
        private readonly RoleManager<IdentityRole> _role;

        public UserService(UserManager<IdentityUser> usuario, SignInManager<IdentityUser> login, RoleManager<IdentityRole> role)
        {
            _usuario = usuario;
            _login = login;
            _role = role;
        }

        public async Task<IdentityResult> CadastrarUsuario(CreateUserDTO createUser)
        {

            IdentityUser userAdd = new IdentityUser
            {
                UserName = createUser.UserName,
                Email = createUser.Email,
                EmailConfirmed = true
            };

      
            if (!await _role.RoleExistsAsync(createUser.Role))
            {
                IdentityRole role = new IdentityRole
                {
                    Name = createUser.Role
                };
                await _role.CreateAsync(role);
            }
            var result = await _usuario.CreateAsync(userAdd, createUser.Senha);

            await _usuario.AddToRoleAsync(userAdd, createUser.Role);
            return result;

          
        }

        public string generateToken(LoginUser loginUser)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(settingskey.Settings.SecretKey);
            var claims = new List<Claim>();

            var TokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
               {
                   new Claim(ClaimTypes.Name, loginUser.UserName.ToString()),

                   new Claim(ClaimTypes.Role, loginUser.Roles[0])

               }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(TokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<UserToken> Login(LoginUser loginUser)
        {
          var user = await  _usuario.FindByEmailAsync(loginUser.Email);
          if(user == null)
            {
                return null;
            }
          var result = await _login.PasswordSignInAsync(user.UserName, loginUser.Senha, false, false);
            loginUser.Roles.AddRange(await _usuario.GetRolesAsync(user));
            if(result.Succeeded)
            {
                UserToken userToken = new UserToken();
                userToken.User = loginUser;
                userToken.Token = generateToken(loginUser);
                return userToken;           
            }
            return null;
           
        }

    }
}
