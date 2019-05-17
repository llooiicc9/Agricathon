using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Room
    {
        //Déclare les champs présents sur la base de donnée
        public int IdRoom { get; set; }
        public int Number { get; set; }
        public String Description { get; set; }
        public int Type { get; set; }
        public Decimal Price { get; set; }
        public Boolean HasTV { get; set; }
        public Boolean HasHairDryer { get; set; }
        public int IdHotel { get; set; }

        public override string ToString()
        {
            //Renvoie en String tous les champs
            return
                " IdRoom: " + IdRoom.ToString() +
                " Number: " + Number.ToString() +
                " Description: " + Description +
                " Type: " + Type.ToString() +
                " Price: " + Price.ToString() +
                " HasTV: " + HasTV.ToString() +
                " HasHairDryer: " + HasHairDryer.ToString() +
                " IdHotel: " + IdHotel;
        }
    }
}
