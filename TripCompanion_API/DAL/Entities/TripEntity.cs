using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class TripEntity
    {
        public int IdTrip { get; set; }
        public string Name { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public int? Budget { get; set; }
        public string? Comments { get; set; }
        //FK
        public int IdUser { get; set; }
    }
}
