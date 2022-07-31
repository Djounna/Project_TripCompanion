using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.APIEntity
{
    public class GeoapifyResult
    {
        public class Result
        {
            public double lon { get; set; }
            public double lat { get; set; }
        }


        public Result[] results { get; set; }

    }
}
