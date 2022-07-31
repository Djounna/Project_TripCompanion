using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.APIEntity
{
    public class OpenWeatherMapResult
    {
        public class Main
        {
            public double Temp { get; set; }
            public double Humidity { get; set; }
        }

        public Main main { get; set; }
    }
}
