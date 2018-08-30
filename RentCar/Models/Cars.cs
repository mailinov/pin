using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCar.Models
{
    public class Cars
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Model { get; set; }
        public decimal Cijena { get; set; }

        public int MarkaID { get; set; }
        public Marka Marka { get; set; }
    }
}
