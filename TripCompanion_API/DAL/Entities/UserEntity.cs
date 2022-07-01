using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class UserEntity
    {
        public int IdUser { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        //Public int IdRole {get; set} // TODO advanced; Role management

    }
}
