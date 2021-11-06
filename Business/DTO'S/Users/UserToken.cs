using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO_S.Users
{
    public class UserToken
    {
        public LoginUser User { get; set; }
        public string Token { get; set; }
    }
}
