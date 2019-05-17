using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class RoomReservation
    {
        //Déclare les champs présents sur la base de donnée
        public int IdRoomReservation { get; set; }
        public int IdReservation { get; set; }
        public int IdRoom { get; set; }
        public int PriceIncreased { get; set; }

        public override string ToString()
        {
            //Retourne en String tous les champs
            return
                " IdReservationRoom: " + IdRoomReservation.ToString() +
                " IdReservation: " + IdReservation.ToString() +
                " IdRoom: " + IdRoom.ToString() +
                " PriceIncreased" + PriceIncreased.ToString() ;
        }
    }
}
