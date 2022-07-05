using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class UserDTO
    {
        public int IdUser { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //Public int IdRole {get; set} // TODO advanced; Role management
    }
}
