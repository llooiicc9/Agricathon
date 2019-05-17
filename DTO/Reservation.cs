using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Reservation
    {
        //Déclare les champs présents sur la base de donnée
        public int IdReservation { get; set; }
        public String ClientLastName { get; set; }
        public String ClientFirstName { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

               
        public override string ToString()
        {
            //Retourne en String tous les champs
            return
                " IdReservation: " + IdReservation.ToString() +
                " ClientLastName: " + ClientLastName +
                " ClientFirstName: " + ClientFirstName +
                " CheckIn: " + CheckIn.ToString() +
                " CheckOut: " + CheckOut.ToString();
        }
    }
}
