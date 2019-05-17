using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Hotel
    {
        //Déclare les champs présents sur la base de donnée
        public int IdHotel { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String Location { get; set; }
        public int Category { get; set; }
        public Boolean HasWifi { get; set; }
        public Boolean HasParking { get; set; }
        public String Phone { get; set; }
        public String Email { get; set; }
        public String Website { get; set; }

        public override string ToString()
        {
            //Renvoie en String tous les champs
            return 
                " IdHotel: " + IdHotel.ToString() +
                " Name: " + Name +
                " Description: " + Description +
                " Location: " + Location +
                " Category: " + Category.ToString() +
                " HasWifi: " + HasWifi.ToString() +
                " HasParking: " + HasParking.ToString() +
                " Phone: " + Phone +
                " Email: " + Email +
                " Website: " + Website;
        }
    }
}
