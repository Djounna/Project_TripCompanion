using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class StepDTO
    {
        public int IdStep { get; set; }
        public string Name { get; set; }
        public int? Budget { get; set; }
        public double? Time { get; set; }
        public string? Comments { get; set; }
        //FK
        public int IdTrip { get; set; }
    }
}
