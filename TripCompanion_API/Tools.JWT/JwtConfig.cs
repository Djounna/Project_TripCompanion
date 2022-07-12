using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.JWT
{
    public class JwtConfig
    {
        public string Signature { get; set; }
        public int Duration { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
